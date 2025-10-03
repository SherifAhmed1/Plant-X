using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestGameManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI alertText, timerText;

    [Header("Actions")]
    public Button waitButton, harvestButton, waterButton;

    [Header("Crop Images")]
    // Crop visual
    public Image cropImage;
    private enum CropState { Seed, Sprout, Small, Mature, Harvestable, Dead }
    private CropState cropState = CropState.Seed;

    // Sprites
    public Sprite seedSprite;
    public Sprite sproutSprite;
    public Sprite smallSprite;
    public Sprite matureSprite;
    public Sprite harvestableSprite;
    public Sprite deadSprite;

    [Header("Alert Images")]
    public Image alertImage;
    public Sprite droughtSprite;
    public Sprite floodSprite;
    public Sprite normalSprite;

    private bool gameOver = false;
    private int turnCount = 0;

    private string currentAlert;

    [Header("Settings")]
    public GameObject gameOverCanvas;
    // Timer
    public float turnTime = 5f;   // seconds per turn
    private float currentTime;

    void Start()
    {
        UpdateUI();

        waitButton.onClick.AddListener(OnWait);
        harvestButton.onClick.AddListener(OnHarvest);
        waterButton.onClick.AddListener(OnWater);

        NextTurn();
    }

    void Update()
    {
        if (gameOver) return;

        currentTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0f)
        {
            WrongAction(); // if no choice in time → wrong
        }
    }

    void NextTurn()
    {
        if (gameOver) return;

        string[] alerts = { "Flood", "Drought", "Normal" };
        currentAlert = alerts[Random.Range(0, alerts.Length)];
        alertText.text = currentAlert;

        switch (currentAlert)
        {
            case "Flood": alertImage.sprite = floodSprite; break;
            case "Drought": alertImage.sprite = droughtSprite; break;
            case "Normal": alertImage.sprite = normalSprite; break;
        }

        currentTime = turnTime; // reset timer
    }

    void OnWait()
    {
        if (gameOver) return;
        if (currentAlert == "Normal") CorrectAction(); else WrongAction();
    }

    void OnHarvest()
    {
        if (gameOver) return;
        if (currentAlert == "Flood") CorrectAction(); else WrongAction();
    }

    void OnWater()
    {
        if (gameOver) return;
        if (currentAlert == "Drought") CorrectAction(); else WrongAction();
    }

    void CorrectAction()
    {
        turnCount++;

        // Every 2 correct turns → crop grows
        if (turnCount % 2 == 0)
        {
            if (cropState == CropState.Seed) cropState = CropState.Sprout;
            else if (cropState == CropState.Sprout) cropState = CropState.Small;
            else if (cropState == CropState.Small) cropState = CropState.Mature;
            else if (cropState == CropState.Mature)
            {
                cropState = CropState.Harvestable;
                EndGame();
                return;
            }
        }

        UpdateUI();
        NextTurn();
    }



    void WrongAction()
    {
        if (cropState == CropState.Seed) cropState = CropState.Dead;
        else if (cropState == CropState.Sprout) cropState = CropState.Seed;
        else if (cropState == CropState.Small) cropState = CropState.Sprout;
        else if (cropState == CropState.Mature) cropState = CropState.Small;

        if (cropState == CropState.Dead)
        {
            EndGame();
            return;
        }

        UpdateUI();
        NextTurn();
    }



    void UpdateUI()
    {
        switch (cropState)
        {
            case CropState.Seed: cropImage.sprite = seedSprite; break;
            case CropState.Sprout: cropImage.sprite = sproutSprite; break;
            case CropState.Small: cropImage.sprite = smallSprite; break;
            case CropState.Mature: cropImage.sprite = matureSprite; break;
            case CropState.Harvestable: cropImage.sprite = harvestableSprite; break;
            case CropState.Dead: cropImage.sprite = deadSprite; break;
        }
    }


    void EndGame()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true);
        timerText.text = "Time: 0";
        UpdateUI();
    }
}
