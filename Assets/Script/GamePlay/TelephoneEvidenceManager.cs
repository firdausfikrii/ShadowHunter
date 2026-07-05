using System.Collections;
using TMPro;
using UnityEngine;

public class TelephoneEvidenceManager : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("Interact")]
    public TelephoneInteract telephoneInteract;

    [Header("UI")]
    public GameObject telephonePanel;
    public TMP_Text analysisText;

    [Header("Hotspot Benar")]
    public TelephoneHotspot otpHotspot;
    public TelephoneHotspot requestOtpHotspot;

    [Header("Semua Hotspot")]
    public TelephoneHotspot[] allHotspots;

    private int wrongCount = 0;
    private bool completed = false;
    private bool isLocked = false;

    public bool IsLocked()
    {
        return isLocked;
    }

    void Update()
    {
        if (completed)
            return;

        if (otpHotspot.IsSolved &&
            requestOtpHotspot.IsSolved)
        {
            CompleteTelephone();
        }
    }

    public void WrongAnswer()
    {
        if (isLocked)
            return;

        wrongCount++;

        if (wrongCount >= 2)
        {
            isLocked = true;

            gameplayManager.LoseFocus();

            StartCoroutine(RestartTelephone());
        }
    }

    IEnumerator RestartTelephone()
    {
        analysisText.gameObject.SetActive(true);

        analysisText.text =
            "❌ ANALISIS GAGAL\n\n" +
            "Kamu terlalu banyak memilih\n" +
            "kalimat yang bukan berasal\n" +
            "dari rekaman telepon.\n\n" +
            "Fokuslah mendengarkan kembali\n" +
            "bukti sebelum menganalisis.";

        yield return new WaitForSecondsRealtime(3f);

        telephonePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        wrongCount = 0;
        isLocked = false;

        foreach (TelephoneHotspot hotspot in allHotspots)
        {
            hotspot.ResetHotspot();
        }

        analysisText.gameObject.SetActive(false);
    }

    void CompleteTelephone()
    {
        completed = true;

        gameplayManager.AddScore(100);
        gameplayManager.AddEvidence();

        analysisText.gameObject.SetActive(false);

        caseFlow.FinishTelephone();

        // Telepon tidak bisa dibuka lagi
        if (telephoneInteract != null)
        {
            telephoneInteract.FinishInvestigation();
        }

        telephonePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        Debug.Log("Telephone Investigation Complete");
    }
}