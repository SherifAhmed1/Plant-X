using System;
using UnityEngine;
using UnityEngine.UI;

public class VisualizationManager : MonoBehaviour
{
    [SerializeField] Image visualizationImage;
    [SerializeField] Sprite[] dataImages;

    [SerializeField] Button visualizationButton;

    Sprite currentSprite;

    private void Start()
    {
        visualizationButton.onClick.AddListener(ApplySprite);
    }

    public void ChangeData(Int32 dataIndex)
    {
        currentSprite = dataImages[dataIndex];
        visualizationImage.sprite = null;
    }

    public void ApplySprite()
    {
        visualizationImage.sprite = currentSprite;
    }
}
