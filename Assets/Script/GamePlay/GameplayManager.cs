using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text evidenceText;
    public TMP_Text timerText;

    [Header("Focus")]
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    [Header("Timer")]
    public float investigationTime = 180f;

    private float currentTime;
    private bool timerRunning = false;
    private bool timerStarted = false;

    [Header("Failure")]
    public GameObject failurePanel;
    public TMP_Text failureText;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    private int score = 0;
    private int evidence = 0;
    private int focus = 3;

    void Start()
    {
        AudioManager.Instance.PlayGameplayMusic();
        currentTime = investigationTime;

        if (failurePanel != null)
            failurePanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (timerText != null)
            timerText.text = "--:--";

        UpdateUI();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerRunning = false;

            TimeOut();
        }

        UpdateTimerUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        if (evidenceText != null)
            evidenceText.text = evidence + "/4";

        if (heart1 != null)
            heart1.SetActive(focus >= 1);

        if (heart2 != null)
            heart2.SetActive(focus >= 2);

        if (heart3 != null)
            heart3.SetActive(focus >= 3);

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText == null)
            return;

        if (!timerStarted)
        {
            timerText.text = "--:--";
            return;
        }

        int minute = Mathf.FloorToInt(currentTime / 60);
        int second = Mathf.FloorToInt(currentTime % 60);

        timerText.text = minute.ToString("00") + ":" + second.ToString("00");
    }

    //================================================
    // TIMER
    //================================================

    public void StartTimer()
    {
        currentTime = investigationTime;
        timerRunning = true;
        timerStarted = true;

        UpdateTimerUI();

        Debug.Log("Timer Started");
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    void TimeOut()
    {
        ShowFailure(
            "MISSION FAILED\n\n" +
            "Waktu investigasi telah habis.\n\n" +
            "Seorang investigator harus\n" +
            "bekerja cepat dan tetap teliti."
        );
    }

    //================================================
    // SCORE
    //================================================

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
    }

    //================================================
    // EVIDENCE
    //================================================

    public void AddEvidence()
    {
        if (evidence < 4)
        {
            evidence++;
            UpdateUI();
        }
    }

    //================================================
    // FOCUS
    //================================================

    public void LoseFocus()
    {
        if (focus <= 0)
            return;

        focus--;

        UpdateUI();

        if (focus <= 0)
        {
            ShowFailure(
                "MISSION FAILED\n\n" +
                "Fokus investigasi telah habis.\n\n" +
                "Seorang investigator harus\n" +
                "lebih teliti dalam\n" +
                "menganalisis seluruh barang bukti."
            );
        }
    }

    //================================================
    // FAILURE
    //================================================

    void ShowFailure(string message)
    {
        timerRunning = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (failureText != null)
            failureText.text = message;

        if (failurePanel != null)
            failurePanel.SetActive(true);

        StartCoroutine(OpenGameOver());
    }

    IEnumerator OpenGameOver()
    {
        yield return new WaitForSecondsRealtime(2f);

        if (failurePanel != null)
            failurePanel.SetActive(false);

        GameOver();
    }

    //================================================
    // GAME OVER
    //================================================

    public void GameOver()
    {
        timerRunning = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    //================================================
    // BUTTON
    //================================================

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuUtama");
    }

    //================================================
    // FINISH EVIDENCE
    //================================================

    public void FinishLaptopEvidence()
    {
        AddScore(100);
        AddEvidence();
    }

    public void FinishSmartphoneEvidence()
    {
        AddScore(100);
        AddEvidence();
    }

    public void FinishTelephoneEvidence()
    {
        AddScore(100);
        AddEvidence();
    }

    public void FinishReportEvidence()
    {
        AddScore(100);
        AddEvidence();
    }

    //================================================
    // GETTER
    //================================================

    public int GetScore()
    {
        return score;
    }
    public bool HasEnoughScore()
    {
        return score >= 520;
    }

    public int GetEvidence()
    {
        return evidence;
    }

    public int GetFocus()
    {
        return focus;
    }

    public bool IsTimerRunning()
    {
        return timerRunning;
    }

    public float GetRemainingTime()
    {
        return currentTime;
    }
}