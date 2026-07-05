using TMPro;
using UnityEngine;

public class WebsiteAnalyzer : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject laptopPanel;

    private bool urlFound = false;
    private bool httpFound = false;
    private bool loginFound = false;

    private bool finished = false;

    public void URLHotspot()
    {
        if (urlFound) return;

        urlFound = true;

        gameplayManager.AddScore(20);

        Debug.Log("Domain website palsu.");
    }

    public void HTTPHotspot()
    {
        if (httpFound) return;

        httpFound = true;

        gameplayManager.AddScore(20);

        Debug.Log("Website tidak menggunakan HTTPS.");
    }

    public void LoginHotspot()
    {
        if (loginFound) return;

        loginFound = true;

        gameplayManager.AddScore(20);

        Debug.Log("Website meminta login akun.");

        CheckFinished();
    }

    public void WrongHotspot()
    {
        gameplayManager.LoseFocus();

        Debug.Log("Bukan petunjuk.");
    }

    void CheckFinished()
    {
        if (finished)
            return;

        if (urlFound && httpFound && loginFound)
        {
            finished = true;

            gameplayManager.AddScore(100);

            gameplayManager.AddEvidence();

            caseFlow.FinishLaptop();

            laptopPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;
        }
    }
}