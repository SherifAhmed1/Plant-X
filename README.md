# Plant-X: NASA Farm Navigators — AR & AI Farming Education

**Plant-X** is a mobile + AR educational app built with Unity that blends **NASA-supported satellite data**, **AI crop scanning**, and **interactive simulations** to teach sustainable farming and hazard awareness (drought, flood, heat, and more). It’s designed for **farmers, students, and researchers**—with **audio guidance** for non-literate users.

---

## Executive Summary

**What did we build?**  
A mobile and AR game that uses real NASA datasets, computer vision, and predictive modeling. Users explore how **temperature, humidity, soil moisture**, and hazards shape crop outcomes. Point a phone at leaves for **AI health checks**; simulate choices like **irrigation and fertilization**; and learn via **mini-games** and **AR scenes**.

**Why it matters**  
Plant-X turns complex Earth data into hands-on learning—**demystifying satellite data**, encouraging **better decisions**, and inspiring **climate-resilient agriculture**.

---

## Features

### 1) Mini-games
- **Drought Print** – Match regions to drought intensity colors to reveal distribution and patterns across the U.S.  
- **Harvest Hero** – A time-bound game where you pick the right action for each hazard, guiding a plant from seed to flower.

### 2) Scan Crops (AI)
Use your camera to analyze a leaf. The AI (MobileNetV2 + TensorFlow) predicts **healthy**, **rust**, or **powdery mildew**, and can provide a severity score.

![Scan Crops](path_to_image/scan_crops.png)

### 3) AR Simulation
Visualize a farm field in augmented reality under different hazard settings (e.g., **drought**, **flood**, **heat**). See how hazards affect plant growth and field layout.

![AR Simulation](path_to_image/ar_simulation.png)

### 4) Visualize Data
Explore **real drought intensity** across U.S. states via an interactive map, powered by NASA-supported datasets.

![Data Visualization](path_to_image/data_visualization.png)

### 5) Accessibility
- **Audio instructions** for users who prefer listening over reading.  
- Clear UI with simple flows for quick actions in the field.

---

## How It Works

- **Data Layer**  
  Pulls NASA-supported datasets (e.g., **soil moisture**, **vegetation indices**, **precipitation**, **temperature**) via APIs.

- **AI Computer Vision**  
  A **MobileNetV2** model (TensorFlow, Python) classifies crop leaf health (healthy, rust, powdery mildew).

- **Simulation Engine**  
  Blends NASA data with **predictive models** to simulate how irrigation, fertilization, and crop choices affect yields and sustainability.

- **AR Interface**  
  **Unity** + **ARKit/ARCore/Vuforia** render interactive fields and overlays (hazards, growth stages, tips).

- **User Interaction**  
  Crop scanning, AR overlays, hazard maps, and mini-games—plus **audio guidance** for accessibility.

---

## Benefits

**For Farmers**
- Quick, phone-based plant health checks.
- Better decisions on water, fertilizer, and crop care.
- Reduced waste → higher yields.

**For Students & Educators**
- Gamified, hands-on learning about climate–farming links.
- Real NASA data for authentic exploration.

**For Researchers & Policymakers**
- Practical demos of NASA datasets in agriculture.
- Raises awareness of climate resilience strategies.

---

## NASA Data Used

**U.S. Drought Monitor** (NASA-supported)  
Source: https://droughtmonitor.unl.edu/DmData/DataDownload/ComprehensiveStatistics.aspx

- Combines satellite-derived products (e.g., **SMAP** for soil moisture, **MODIS** for vegetation stress, **GRACE** for groundwater) with other climate inputs.  
- **In Plant-X:**  
  - **Data Visualization:** Interactive U.S. drought maps and stats.  
  - **AR Scenarios:** See drought/flood impacts on crops and soil moisture.  
  - **Mini-game Integration:** *Drought Print* uses intensity coloring to teach patterns.  
  - **Decision Simulation:** Shows how hazards impact yield and soil conditions.

---

## Tech Stack

- **App / Game:** Unity (C#), Vuforia SDK, ARKit/ARCore  
- **AI / Backend:** TensorFlow, MobileNetV2, Python, FastAPI  
- **Data Pipelines:** Cloud APIs for NASA-supported datasets  
- **Design:** Adobe; assets from Behance / Freepik / Flaticon  
- **Hardware:** Smartphones (Android; iOS AR supported via ARKit)

---

## Datasets & Resources

- **U.S. Drought Monitor (NASA-supported):**  
  https://droughtmonitor.unl.edu/DmData/DataDownload/ComprehensiveStatistics.aspx  
- **Plant Disease Recognition (training data):**  
  https://www.kaggle.com/datasets/rashikrahmanpritom/plant-disease-recognition-dataset  
- **Other data/resources:**  
  https://www.kaggle.com • https://www.behance.net/ • https://www.freepik.com/ • https://www.flaticon.com/

---

## Installation

- **APK:**  
  [Download Plant-X APK](#)

---

## How to Use

1. **Mini-games** – From the main menu, choose **Drought Print** or **Harvest Hero** and follow on-screen instructions.  
2. **Scan Crops** – Open **Scan**, point the camera at a leaf; get instant AI feedback.  
3. **AR Simulation** – Open **AR**, pick a hazard (drought/flood/heat), and view overlays in your space.  
4. **Visualize Data** – Open **Data** to browse drought intensity across U.S. states.

---

## Roadmap

1. **Automated AI Data Engine**  
   - Auto-fetch data by user location and generate visualizations.  
   - Add **forecasting** and **what-if** scenario projections.

2. **VR Modules**  
   - Immersive scenarios for users who prefer audio/visual learning without text.

3. **Community & Sharing**  
   - Compare scores, share scans (with privacy controls), and collaborate.

4. **Crop Suggestions**  
   - Contextual tips and recommended actions based on scans + local data.

---

