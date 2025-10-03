using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRotateScreen : MonoBehaviour
{
    Animator animator;
    [SerializeField] string sceneName;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        animator.SetTrigger("Start");

        Invoke(nameof(LoadScene), 3.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
