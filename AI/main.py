# Block: Deploy trained MobileNetV2 model for predictions in production
import tensorflow as tf
import numpy as np
from keras.preprocessing.image import load_img, img_to_array
from keras.models import load_model
from fastapi import FastAPI, File, UploadFile, HTTPException
from fastapi.responses import JSONResponse
import io
from PIL import Image

# Parameters (match training setup)
IMG_SIZE = 224
NUM_CLASSES = 3
CLASS_NAMES = ['Healthy', 'Powdery', 'Rust'] # Replace with your actual class names

# Load the trained model
model = load_model('best_model.keras')

# Function to preprocess a single image
def preprocess_image(image: Image.Image):
    # Resize to match training input
    img = image.resize((IMG_SIZE, IMG_SIZE))
    # Convert to array and normalize
    img_array = img_to_array(img) / 255.0
    # Expand dimensions to match model input (1, IMG_SIZE, IMG_SIZE, 3)
    img_array = np.expand_dims(img_array, axis=0)
    return img_array

# Function to predict class for a single image
def predict_image(image: Image.Image):
    # Preprocess the image
    img_array = preprocess_image(image)
    # Make prediction
    predictions = model.predict(img_array)
    # Get predicted class and confidence
    predicted_class_idx = np.argmax(predictions[0])
    predicted_class = CLASS_NAMES[predicted_class_idx]
    confidence = float(predictions[0][predicted_class_idx] * 100)
    # All probabilities
    probabilities = {CLASS_NAMES[i]: float(predictions[0][i]) for i in range(NUM_CLASSES)}
    return predicted_class, confidence, probabilities

# FastAPI app
app = FastAPI(title="NASA AI Model Prediction API", description="API for predicting using the trained Keras model", version="1.0.0")

@app.post("/predict")
async def predict(file: UploadFile = File(...)):
    """
    Predict the class of an uploaded image using the trained model.
    
    - **file**: Image file to predict (JPEG, PNG, etc.)
    
    Returns:
    - **prediction**: Predicted class name
    - **confidence**: Confidence score (0-100)
    - **probabilities**: Dictionary of all class probabilities
    """
    if not file.filename:
        raise HTTPException(status_code=400, detail="No file provided")
    
    # Check file type (basic check)
    if not file.content_type.startswith("image/"):
        raise HTTPException(status_code=400, detail="File must be an image")
    
    try:
        # Read file content
        contents = await file.read()
        # Open image with PIL
        image = Image.open(io.BytesIO(contents))
        # Ensure it's RGB
        if image.mode != 'RGB':
            image = image.convert('RGB')
        
        # Predict
        predicted_class, confidence, probabilities = predict_image(image)
        
        # Return JSON response
        return JSONResponse(content={
            "prediction": predicted_class,
            "confidence": confidence,
            "probabilities": probabilities
        })
    
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Prediction failed: {str(e)}")

# Run the app with uvicorn when executed directly
if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, port=8000)