using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    [Header("UI")]
    public GameObject objectiveUI;
    public TMP_Text objectiveText;
    public TMP_Text progressText;

    public Interactable chiefInteractable;

    private int evidenceFound = 0;
    private int totalEvidence = 3;

    private void Start()
    {
        objectiveUI.SetActive(true);
        UpdateProgress();
    }

    private void Awake()
    {
        Instance = this;
    }

    // =========================
    // START MISSION
    // =========================
    public void StartMission()
    {
        evidenceFound = 0;

        objectiveText.text = "Cari 3 Bukti";
        progressText.gameObject.SetActive(true);

        UpdateProgress();
    }

    // =========================
    // ADD EVIDENCE
    // =========================
    public void AddEvidence()
    {
        evidenceFound++;
        UpdateProgress();

        if (evidenceFound >= totalEvidence)
        {
            AudioManager.Instance.PlayVictoryMusic();
            objectiveText.text = "Temui Chief";

            ScoreManager.Instance.AddScore(100);

            FeedbackManager.Instance.ShowFeedback("MISSION COMPLETE\n+100 Bonus", Color.cyan);

            chiefInteractable.canInteract = true;
        }
    }

    void UpdateProgress()
    {
        progressText.text = evidenceFound + " / " + totalEvidence;
    }

    // =========================
    // OBJECTIVE CONTROL
    // =========================
    public void ShowObjective(string text)
    {
        objectiveUI.SetActive(true);

        objectiveText.text = text;
        progressText.gameObject.SetActive(false);
    }

    public void HideObjective()
    {
        objectiveUI.SetActive(false);
    }

    public bool IsMissionComplete()
    {
        return evidenceFound >= totalEvidence;
    }
}
