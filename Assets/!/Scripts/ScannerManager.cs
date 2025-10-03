using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScannerManager : MonoBehaviour
{

    [SerializeField] UnityEvent OnPredict;

    [SerializeField] Image healthyBar, rustyBar, powderyBar;

    [SerializeField] TextMeshProUGUI healthyText, rustyText, powderyText, description;

    // Change this to your server endpoint
    private string uploadUrl = "https://plantx.replit.app/predict";

    public void StartUpload(Texture2D texture)
    {
        StartCoroutine(Upload(texture));
    }

    private IEnumerator Upload(Texture2D texture)
    {
        Debug.Log("Start Uploading...");

        // Convert Texture2D to PNG or JPG
        byte[] imageBytes = texture.EncodeToJPG(); // or EncodeToPNG()

        // Create multipart form
        WWWForm form = new();
        form.AddBinaryData("file", imageBytes, "screenshot.jpg", "image/jpeg");

        using UnityWebRequest www = UnityWebRequest.Post(uploadUrl, form);
        www.SetRequestHeader("accept", "application/json");

        // Send the request
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Upload complete! Response: " + www.downloadHandler.text);
            UpdateUI(www.downloadHandler.text);
            OnPredict?.Invoke();
        }
        else
        {
            Debug.LogError("Upload failed: " + www.error);
        }
    }


    private void UpdateUI(string result)
    {
        ApiResponse response = JsonUtility.FromJson<ApiResponse>(result);

        // Update UI
        switch (response.prediction)
        {
            case "Healthy":
                description.text = "Healthy plant shows normal growth, green leaves, no disease symptoms.\r\n";
                break;

            case "Rust":
                description.text = "A fungal disease causing yellow/orange/brown spots or pustules on leaves.";
                break;

            case "Powdery":
                description.text = "Usually refers to powdery mildew, a fungal disease that looks like white/gray powder on leaves/stems.\r\n";
                break;
        }

        healthyText.text = Mathf.RoundToInt(response.probabilities.Healthy * 100f).ToString() + "%";
        powderyText.text = Mathf.RoundToInt(response.probabilities.Powdery * 100f).ToString() + "%";
        rustyText.text = Mathf.RoundToInt(response.probabilities.Rust * 100f).ToString() + "%";

        healthyBar.fillAmount = response.probabilities.Healthy;
        powderyBar.fillAmount = response.probabilities.Powdery;
        rustyBar.fillAmount = response.probabilities.Rust;

    }


}


[System.Serializable]
public class ApiResponse
{
    public string prediction;
    public float confidence;
    public Probabilities probabilities;
}

[System.Serializable]
public class Probabilities
{
    public float Healthy;
    public float Powdery;
    public float Rust;
}
