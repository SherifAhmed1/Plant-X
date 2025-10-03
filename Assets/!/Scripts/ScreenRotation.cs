using UnityEngine;
using UnityEngine.Events;

public class ScreenRotation : MonoBehaviour
{

    [SerializeField] ScreenOrientation orientation;

    void Start()
    {
        RotateScreen(orientation);
    }

    private void RotateScreen(ScreenOrientation orientation)
    {
        if (Screen.orientation != orientation)
        {
            Screen.orientation = orientation;
        }
    }
}
