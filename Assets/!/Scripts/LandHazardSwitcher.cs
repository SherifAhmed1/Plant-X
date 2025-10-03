using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandHazardSwitcher : MonoBehaviour
{
    [Header("Textures")]
    // Textures for the grass Base Map
    public Texture healthyGrassTexture;
    public Texture healthySoilTexture;

    public Texture droughtSoilTexture;

    public Texture floodTexture;

    public Texture heatGrassTexture;

    [Header("Materials")]

    // Reference to the land mesh/plane
    public Material soilMaterial;
    public Material grassMaterial;

    [Header("Text")]

    // UI text for description
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        // Start with healthy land
        SetHealthy();
    }

    public void SetHealthy()
    {
        grassMaterial.mainTexture = healthyGrassTexture;
        soilMaterial.mainTexture = healthySoilTexture;

        titleText.text = "Healthy";
        descriptionText.text = "The land is green and fertile. Crops can grow normally when soil moisture and temperature are balanced.";
    }

    public void SetDrought()
    {
        grassMaterial.mainTexture = heatGrassTexture;
        soilMaterial.mainTexture = droughtSoilTexture;

        titleText.text = "Drought";
        descriptionText.text = "Drought reduces water in the soil. Without enough irrigation or rain, plants wilt and growth slows or stops completely.";
    }

    public void SetFlood()
    {
        soilMaterial.mainTexture = floodTexture;
        titleText.text = "Flood";
        descriptionText.text = "Flooding covers land with excess water. Roots can suffocate, soil erodes, and farmland may be unusable for weeks.";
    }

    public void SetHeat()
    {
        grassMaterial.mainTexture = heatGrassTexture;
        soilMaterial.mainTexture = healthySoilTexture;

        titleText.text = "Heatwave";
        descriptionText.text = "Extreme heat stresses plants, reduces soil moisture, and can damage yields. Longer heatwaves increase the risk of crop failure.";
    }
}
