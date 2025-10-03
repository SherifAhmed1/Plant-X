using System.Collections;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;

    WaitForSeconds waitTime = new(0.3f);

    public void ScrollToNext(GameObject nextPanel)
    {
        nextPanel.SetActive(true);
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        transform.SetAsLastSibling();
        transform.LeanMoveLocalX(-1500, speed);

        yield return waitTime;
        transform.LeanSetLocalPosX(0);
        gameObject.SetActive(false);
    }

}
