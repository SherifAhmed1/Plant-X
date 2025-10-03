using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PaintGameManager : MonoBehaviour
{
    public ToggleGroup group;
    public GameObject[] areas;

    public UnityEvent OnFinishGame;
    public AudioSource sfxSource;

    private int counter = 0;

    public void CheckToggleWithArea(TextMeshProUGUI areaIntensityText)
    {
        Toggle selectedToggle = group.GetFirstActiveToggle();

        if (selectedToggle.name == areaIntensityText.text)
        {
            areaIntensityText.transform.parent.gameObject.SetActive(false);
            counter++;
            sfxSource.Play();
        }

        if (counter >= 40)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        foreach (var area in areas)
        {
            area.SetActive(false);
        }

        OnFinishGame?.Invoke();
    }
}
