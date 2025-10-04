Plant-X
NASA Farm Navigators: Using NASA Data Exploration in Agriculture

Executive Summary 
What did we develop?
 Our proposed solution, Plant X, is a mobile and AR educational game built with Unity that combines real-time NASA satellite data with computer vision and predictive modeling. Players—whether farmers, students, or researchers—can explore farming scenarios where temperature, humidity, and soil conditions shape crop outcomes. Even farmers who cannot read or write can listen to vocal instructions. Using the mobile camera, the app will analyze plant health (leaf color, dryness, disease indicators) through AI-powered vision, cross-referenced with NASA data. The system then simulates farming decisions such as irrigation, fertilization, and crop selection—showing both immediate impacts and future scenarios. AR Model makes learning interactive and immersive with two games and simulation for farming scenarios. The first game allows you to choose parameters like drought or rain to watch scenarios and the second allows you to match drought parameters with map and watch areas with drought for USA states. Additionally, with computer vision, farmers can point their phone camera at crops to see live overlays of plant health or hear vocal info.
How does it address the challenge?
 By integrating cutting-edge technologies with accessible game design, Plant X empowers a broad audience to understand how satellite data can revolutionize agriculture.
Why is it important?
 It not only entertains but also educates, inspiring a new generation of sustainable farming practices.




Project Details

What exactly does it do?
Plant-X is a mobile and AR educational app that uses NASA’s open climate and satellite data plus AI crop scanning to help farmers, students, and researchers understand and practice sustainable farming.
It scans plant leaves with a phone camera to diagnose health (healthy, rust, mildew, etc.).

It simulates hazards (drought, flood, heat) in augmented reality to show how farms are affected.

It provides mini-games to teach about hazards and correct farming decisions.

It visualizes real NASA drought and climate data in an easy, interactive way.

How does it work?
Data Layer: NASA datasets (soil moisture, vegetation indices, precipitation, temperature) are collected via APIs.

AI Computer Vision: A trained deep learning model (MobileNetV2 on TensorFlow) analyzes crop images to detect plant diseases and stress.

Simulation Engine: NASA data + predictive models simulate how farming decisions (irrigation, fertilization, crop choice) affect yields and sustainability.

AR Interface: Unity + ARKit/ARCore/Vuforia render an interactive field in AR, showing hazards and plant growth under real data conditions.

User Interaction: Farmers and learners interact through crop scanning, AR overlays, data maps, and mini-games. Audio instructions make it accessible to non-literate users.


What benefits does it have?
For Farmers:


Quick plant health diagnosis using just a smartphone camera.


Better decision-making on irrigation, fertilizer, and crop care.


Reduced waste of water and chemicals, leading to higher yields.
For Students & Educators:


Gamified, interactive way to learn how climate and farming are connected.


Hands-on experience with real NASA data.


For Researchers & Policymakers:


Demonstrates practical applications of NASA datasets.


Raises awareness of climate resilience and sustainable farming practices.









What do you hope to achieve?

1- Automated (AI) Engine that produces data visualization based on the location of the user. They ONLY need to enter location and our model, using AI, will get the data and visualize it.

It will also make future predictions using this data.

2- Virtual Reality models for farming scenarios to enhance it and to be easier for those who cannot read or write. 















What tools, coding languages, hardware, or software did you use?

App/Game Development: Unity (C#), Vuforia SDK, ARKit/ARCore.

AI Development: TensorFlow, MobileNetV2 architecture, Python.

Backend & API: FastAPI, cloud data pipelines.


Datasets: 
NASA Drought Monitor 
https://droughtmonitor.unl.edu/DmData/DataDownload/ComprehensiveStatistics.aspx
https://www.kaggle.com/datasets/rashikrahmanpritom/plant-disease-recognition-dataset


Other resources 
https://www.behance.net/
https://www.freepik.com/
https://www.flaticon.com/

Hardware: Smartphones (Android)
Design Tools: Adobe/Behance/Freepik/Flaticon for graphics and UI assets.















NASA Data Used in Plant-X
For our project, Plant-X, we integrated open NASA data resources directly from NASA-supported datasets to build the visualization and simulation components of the app. Specifically:
U.S. Drought Monitor (NASA-supported dataset)

Source: https://droughtmonitor.unl.edu/DmData/DataDownload/ComprehensiveStatistics.aspx

This dataset provides comprehensive drought intensity levels across U.S. states and regions, derived from NASA’s Earth observation satellites (SMAP for soil moisture, MODIS for vegetation stress, GRACE for groundwater, and other climate products).




How We Used the Data:
Data Visualization: We imported drought intensity maps and statistics into the app to create an interactive map, allowing users to explore drought severity across U.S. states.
AR Scenarios: The drought data powered our AR field simulations, where players could visualize the effect of drought or flood conditions on crops and soil moisture.
Mini-Game Integration: mini-game was built on this dataset — players match drought severity colors to the correct regions on the U.S. map, learning how droughts spread and affect farming.
Decision-Making Simulation: By integrating the drought intensity index with our farming scenarios, the app can show how different hazards impact crop yield and soil conditions.


Other Data
https://www.kaggle.com
https://www.behance.net/
https://www.freepik.com/
https://www.flaticon.com/



 Use of Artificial Intelligence (AI)
We utilized Artificial Intelligence in our project in the following ways:
Computer Vision for Plant Health: We trained and applied AI-based computer vision models to analyze plant images and classify their health status as healthy, rust-infected, or powdery mildew-infected. This capability supports early detection of plant stress and improves decision-making in drought management.

Idea exploration: AI tools helped us brainstorm user interactions and scenario-building features.

Technologies Used
AI Development:
TensorFlow for model development
MobileNetV2 for model architecture
FastAPI for the backend




# Plant-X: Farming & Hazard Awareness App

**Plant-X** is an innovative mobile app designed to assist farmers, students, and researchers in analyzing and learning about farming techniques, environmental factors, and weather hazards such as drought, flood, heat, and more. It provides interactive features like mini-games, crop scanning with AI, augmented reality (AR) simulations, and data visualization to create a hands-on learning experience for users.

![App Screenshot](path_to_image/plant_x_screenshot.png)
 
---

## Features

### 1. **Mini-games**
   Plant-X includes educational mini-games to help users better understand and raise awareness about environmental hazards affecting farming. 

   - **Drought Print**: Match areas with the corresponding drought intensity color to reveal the distribution of data and map it. This game helps players learn about how droughts impact different regions.
   
   - **Harvest Hero**: In this time-bound game, choose the correct action according to the hazard that occurs, guiding the plant from seed to flower. This interactive experience helps players understand the necessary actions to protect crops from hazards.

### 2. **Scan Crops**
   Using AI-powered technology, users can scan a crop leaf and get an instant diagnosis of its health. The app predicts whether the leaf is healthy, infected with rust, or affected by powdery mildew, along with the percentage of severity. This feature provides quick insights for farmers and researchers working with crops.

   ![Scan Crops Feature](path_to_image/scan_crops.png)

### 3. **AR Simulation**
   This feature allows users to simulate a farm field using augmented reality. You can visualize the shape and structure of a field under different hazard conditions (e.g., drought, flood). The AR simulation helps farmers and students see how specific hazards affect farm layouts and plant growth.

   ![AR Simulation](path_to_image/ar_simulation.png)

### 4. **Visualize Data**
   Plant-X includes a data visualization tool that allows users to view real-time drought intensity data for various states in America. By presenting drought data on an easy-to-understand map, users can quickly analyze regional impacts and patterns.

   ![Data Visualization](path_to_image/data_visualization.png)

---

## How to Use the App

1. **Mini-games**: Access the mini-games from the main menu. Select a game and follow the on-screen instructions to play and learn.
   
2. **Scan Crops**: Open the "Scan" feature and point your phone camera at a plant leaf. The AI will analyze the leaf and display the result, indicating the health status of the crop.

3. **AR Simulation**: Go to the AR section of the app, select the hazard you'd like to simulate, and use the camera to view the simulated farm field in real-time.

4. **Visualize Data**: Navigate to the "Data" tab where you can explore and view interactive maps showcasing the drought intensity across various states in the USA.

---

## Installation

You can download the app by following the link to the APK below:

[Download Plant-X APK](#)

---

## Technologies Used

- **App Development**:  
   - **Unity** for game development  
   - **Vuforia SDK** for Augmented Reality (AR)

- **AI Development**:  
   - **MobileNetV2** for model architecture  
   - **TensorFlow** for model development  
   - **FastAPI** for the backend

---

## Future Updates

- **Expand Hazard Awareness**: Add more types of environmental hazards to educate users.
- **Community Features**: Add the ability to share findings and progress in the mini-games with others.
- **Crop Suggestions**: Provide personalized crop health tips based on the scan data.

---

## Demo Video

Watch the demo video to see how the app works and experience its features in action:

[Watch the demo video on YouTube](https://www.youtube.com/watch?v=your_video_id)
