using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public void LoadMainMenu() => ScenesManager.Instance.LoadScene("Main Menu");
    public void LoadDroughtPaint() => ScenesManager.Instance.LoadScene("Drought Game");
    public void LoadScanCrops() => ScenesManager.Instance.LoadScene("Scan Crops");
    public void LoadHarvestHero() => ScenesManager.Instance.LoadScene("Harvest Hero");
    public void LoadARSimulator() => ScenesManager.Instance.LoadScene("AR Simulator");
}
