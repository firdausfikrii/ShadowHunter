using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject caseBoardUI;
    public PlayerMovement playerMovement;
    public bool IsUIOpen = false;
    private Evidence currentEvidence;
    GameObject currentUI;
    public GameObject dialogueUI;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenDialogue()
    {
        dialogueUI.SetActive(true);

        playerMovement.enabled = false;

        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseDialogue()
    {
        dialogueUI.SetActive(false);

        playerMovement.enabled = true;

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        MissionManager.Instance.ShowObjective("Pergi ke papan kasus.");
    }

    public void OpenCaseBoard()
    {
        caseBoardUI.SetActive(true);
        IsUIOpen = true;

        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseCaseBoard()
    {
        caseBoardUI.SetActive(false);
        IsUIOpen = false;

        playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartInvestigation()
    {
        CloseCaseBoard();

        MissionManager.Instance.StartMission();
    }

    public void OpenUI(GameObject ui, Evidence evidence = null)
    {
        currentUI = ui;

        currentEvidence = evidence;

        ui.SetActive(true);

        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
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

    public void CloseCurrentUI()
    {
        if (currentUI != null)
        {
            currentUI.SetActive(false);
        }

        playerMovement.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
    }
}
