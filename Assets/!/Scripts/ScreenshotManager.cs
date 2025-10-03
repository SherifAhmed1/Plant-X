using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenshotManager : MonoBehaviour
{
    public RawImage screenshotImage;
    byte[] imageBytesArray;

    string imagePath;

    [SerializeField] UnityEvent OnCapture;
    [SerializeField] UnityEvent OnStartCapture;

    WaitForSeconds waitForSec = new(0.5f);

    private void Awake()
    {
        imagePath = Path.Combine(Application.persistentDataPath, "/image.jpg");
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

        ScreenCapture.CaptureScreenshot("image.jpg");

        yield return waitForSec;

        LoadImage();

        yield return waitForSec;

        OnCapture?.Invoke();
    }

    void LoadImage()
    {
        Texture2D sampleTexture = new(0, 0);

        imageBytesArray = File.ReadAllBytes(imagePath);

        bool isLoaded = sampleTexture.LoadImage(imageBytesArray);

        if (!isLoaded)
        {
            Debug.LogError("Failed to load image from bytes.");
            return;
        }

        screenshotImage.texture = sampleTexture;
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
