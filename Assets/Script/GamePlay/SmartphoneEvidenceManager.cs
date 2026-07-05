using UnityEngine;

public class SmartphoneEvidenceManager : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("Interact")]
    public SmartphoneInteract smartphoneInteract;

    [Header("UI")]
    public GameObject smartphonePanel;

    [Header("Hotspot Benar")]
    public WebsiteHotspot accountHotspot;
    public WebsiteHotspot qrHotspot;
    public WebsiteHotspot promoHotspot;

    private bool completed = false;

    void Update()
    {
        if (completed)
            return;

        if (accountHotspot.IsSolved &&
            qrHotspot.IsSolved &&
            promoHotspot.IsSolved)
        {
            CompleteSmartphone();
        }
    }

    void CompleteSmartphone()
    {
        completed = true;

        gameplayManager.AddScore(100);
        gameplayManager.AddEvidence();

        caseFlow.FinishSmartphone();

        // Smartphone tidak bisa dibuka lagi
        if (smartphoneInteract != null)
        {
            smartphoneInteract.FinishInvestigation();
        }

        smartphonePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        Debug.Log("Smartphone Investigation Complete");
    }
}