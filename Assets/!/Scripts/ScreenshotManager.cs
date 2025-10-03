using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenshotManager : MonoBehaviour
{
    public RawImage screenshotImage;
    byte[] imageBytesArray;

    [SerializeField] UnityEvent OnCapture;
    [SerializeField] UnityEvent OnStartCapture;

    WaitForSeconds waitForSec = new(0.5f);

    ScannerManager scannerManager;

    private void Awake()
    {
        scannerManager = FindFirstObjectByType<ScannerManager>();
    }

    void Start()
    {
        RectTransform rt = screenshotImage.rectTransform;
        float currentHeight = rt.rect.height;
        float screenAspect = (float)Screen.width / Screen.height;
        float targetWidth = currentHeight * screenAspect;

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentHeight);
    }

    public void Capture()
    {
        StartCoroutine(CaptureRoutine());
    }

    IEnumerator CaptureRoutine()
    {
        OnStartCapture?.Invoke();

        yield return waitForSec;

        Texture2D imageTexture = ScreenCapture.CaptureScreenshotAsTexture();

        screenshotImage.texture = imageTexture;

        yield return waitForSec;

        scannerManager.StartUpload(imageTexture);

        OnCapture?.Invoke();
    }

    //public void SaveToGallery()
    //{
    //    // Save to gallery
    //    NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(imageBytesArray, "Magic Letters", $"coloring_{currentDate}.png");

    //    // Log the result
    //    switch (permission)
    //    {
    //        case NativeGallery.Permission.Granted:
    //            Debug.Log("Screenshot successfully saved to gallery!");
    //            break;
    //        case NativeGallery.Permission.Denied:
    //            Debug.LogError("Permission denied to save image to gallery.");
    //            break;
    //        default:
    //            Debug.LogError("Failed to save image to gallery due to an unknown issue.");
    //            break;
    //    }
    //}
}
