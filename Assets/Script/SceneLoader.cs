using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene")]
    public string nextSceneName;
    public string mainMenuSceneName;

    [Header("Shortcut")]
    public bool enableRetryKey = true;
    public KeyCode retryKey = KeyCode.R;

    private void Update()
    {
        if (!enableRetryKey)
            return;

        if (UIManager.Instance != null && UIManager.Instance.IsUIOpen)
            return;

        if (Input.GetKeyDown(retryKey))
        {
            RetryLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }

    public void BackToMenu()
    {
        if (!string.IsNullOrEmpty(mainMenuSceneName))
            SceneManager.LoadScene(mainMenuSceneName);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
