using UnityEngine;

public class LaptopEvidenceManager : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("Laptop")]
    public GameObject laptopPanel;

    [Header("Hotspot Benar")]
    public WebsiteHotspot urlHotspot;
    public WebsiteHotspot httpHotspot;
    public WebsiteHotspot loginHotspot;

    private bool completed = false;

    void Update()
    {
        if (completed)
            return;

        if (urlHotspot.IsSolved &&
            httpHotspot.IsSolved &&
            loginHotspot.IsSolved)
        {
            CompleteLaptop();
        }
    }

    void CompleteLaptop()
    {
        completed = true;

        gameplayManager.FinishLaptopEvidence();

        caseFlow.FinishLaptop();

        laptopPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        Debug.Log("Laptop Investigation Complete");
    }
}