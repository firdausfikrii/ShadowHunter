using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject caseBoardUI;
    public GameObject dialogueUI;

    [Header("Player")]
    public Player player;

    private GameObject currentUI;
    private Evidence currentEvidence;

    public bool IsUIOpen { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // =========================
    // TIMELINE / CUTSCENE UI
    // =========================
    public void OpenDialogue()
    {
        dialogueUI.SetActive(true);
        SetPlayerControl(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        SetPlayerControl(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        MissionManager.Instance.ShowObjective("Pergi ke papan kasus.");
    }

    // =========================
    // CASE BOARD
    // =========================
    public void OpenCaseBoard()
    {
        caseBoardUI.SetActive(true);
        IsUIOpen = true;

        SetPlayerControl(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseCaseBoard()
    {
        caseBoardUI.SetActive(false);
        IsUIOpen = false;

        SetPlayerControl(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartInvestigation()
    {
        CloseCaseBoard();
        MissionManager.Instance.StartMission();
    }

    // =========================
    // GENERIC UI (EVIDENCE)
    // =========================
    public void OpenUI(GameObject ui, Evidence evidence = null)
    {
        currentUI = ui;
        currentEvidence = evidence;

        ui.SetActive(true);
        SetPlayerControl(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseCurrentUI()
    {
        if (currentUI != null)
            currentUI.SetActive(false);

        currentEvidence = null;

        SetPlayerControl(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CollectCurrentEvidence()
    {
        if (currentEvidence != null)
        {
            currentEvidence.Collect();
            currentEvidence = null;
        }

        CloseCurrentUI();
    }

    // =========================
    // PLAYER CONTROL HELPER
    // =========================
    void SetPlayerControl(bool state)
    {
        if (player != null)
            player.enabled = state;
    }

    public void HideCurrentUI()
    {
        if (currentUI != null)
            currentUI.SetActive(false);
    }
}
