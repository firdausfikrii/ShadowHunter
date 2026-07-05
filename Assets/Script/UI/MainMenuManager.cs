using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject creditPanel;

    [Header("Scene")]
    [SerializeField] private string firstLevelScene = "QRTrapLevel";

    private bool isLoading = false;

    private void Start()
    {
        AudioManager.Instance.PlayMenuMusic();
        Time.timeScale = 1f;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (creditPanel != null)
            creditPanel.SetActive(false);
    }

    //=====================
    // PLAY
    //=====================
    public void PlayGame()
    {
        if (isLoading)
            return;

        isLoading = true;

        Time.timeScale = 1f;
        SceneManager.LoadScene(firstLevelScene);
    }

    //=====================
    // CREDITS
    //=====================
    public void OpenCredits()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (creditPanel != null)
            creditPanel.SetActive(true);
    }

    //=====================
    // BACK
    //=====================
    public void BackToMenu()
    {
        if (creditPanel != null)
            creditPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }

    //=====================
    // EXIT
    //=====================
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}