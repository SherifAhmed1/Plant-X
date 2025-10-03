using UnityEngine;

public class FaceCameraOnStart : MonoBehaviour
{

    public void LookAtCamera()
    {
        Camera arCamera = Camera.main;
        if (arCamera != null)
        {
            Vector3 lookPos = arCamera.transform.position - transform.position;
            lookPos.y = 0; // keeps object upright (no tilting)
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }
}
