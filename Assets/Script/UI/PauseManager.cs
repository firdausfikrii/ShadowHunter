using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel;

    [Header("Camera")]
    public VisionTracker visionTracker;

    private bool isPaused = false;

    private void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("PAUSE BERHASIL");

        if (isPaused) return;

        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;

        if (visionTracker != null)
            visionTracker.UnlockMouse();
    }

    public void ResumeGame()
    {
        if (!isPaused) return;

        isPaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1f;

        if (visionTracker != null)
            visionTracker.LockMouse();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MenuUtama");
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}