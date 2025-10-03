using TMPro;
using UnityEngine;

public class PasswordVisibility : MonoBehaviour
{

    TMP_InputField passwordField;

    private void Awake()
    {
        passwordField = GetComponent<TMP_InputField>();
    }


    public void PasswordReveal(bool isOn)
    {
        if (isOn)
        {
            passwordField.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordField.contentType = TMP_InputField.ContentType.Password;
        }

        passwordField.ForceLabelUpdate(); // Important to refresh the display
    }
}
