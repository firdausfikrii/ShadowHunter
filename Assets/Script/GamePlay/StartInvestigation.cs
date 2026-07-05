using UnityEngine;

public class StartInvestigation : MonoBehaviour
{
    public GameplayManager gameplayManager;

    public CaseFlow caseFlow;

    public GameObject caseBoardPanel;

    public GameObject investigationWarning;

    public GameObject gameplayHUD;

    public void StartCase()
    {
        // Tutup Warning
        investigationWarning.SetActive(false);

        // Tutup Case Board
        caseBoardPanel.SetActive(false);

        // Tampilkan HUD
        gameplayHUD.SetActive(true);

        // Mulai Timer
        gameplayManager.StartTimer();

        // Ganti Objective
        caseFlow.FinishCaseBoard();

        // Kunci kembali mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
    }
}