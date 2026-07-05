using TMPro;
using UnityEngine;

public class CaseBoardInteract : MonoBehaviour
{
    [Header("UI")]
    public GameObject interactionText;
    public GameObject caseBoardPanel;
    public GameObject gameplayHUD;

    [Header("Mission")]
    public CaseFlow caseFlow;

    private bool playerNearby = false;
    private bool alreadyOpened = false;

    void Start()
    {
        interactionText.SetActive(false);
        caseBoardPanel.SetActive(false);

        if (gameplayHUD != null)
            gameplayHUD.SetActive(false);
    }

    void Update()
    {
        if (!playerNearby)
            return;

        // Sudah pernah membuka Case Board
        if (alreadyOpened)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Hanya bisa dibuka saat objective Case Board
            if (caseFlow.CurrentMission != CaseFlow.MissionState.CaseBoard)
                return;

            OpenCaseBoard();
        }
    }

    void OpenCaseBoard()
    {
        interactionText.SetActive(false);

        caseBoardPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    // Dipanggil tombol "Mulai Investigasi"
    public void StartInvestigation()
    {
        caseBoardPanel.SetActive(false);

        if (gameplayHUD != null)
            gameplayHUD.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        // Tidak bisa dibuka lagi
        alreadyOpened = true;

        // Lanjut objective
        if (caseFlow != null)
            caseFlow.FinishCaseBoard();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        TMP_Text txt = interactionText.GetComponent<TMP_Text>();

        if (alreadyOpened)
        {
            interactionText.SetActive(false);
            return;
        }

        if (caseFlow.CurrentMission == CaseFlow.MissionState.CaseBoard)
        {
            txt.text = "Tekan E untuk melihat Case Board";
        }
        else
        {
            txt.text = "Temui Chief terlebih dahulu.";
        }

        interactionText.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = false;
        interactionText.SetActive(false);
    }
}