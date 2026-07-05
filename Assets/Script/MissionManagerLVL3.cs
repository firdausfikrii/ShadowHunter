using TMPro;
using UnityEngine;

public class MissionManagerLVL3 : MonoBehaviour
{
    public static MissionManagerLVL3 Instance;

    [Header("UI")]
    public GameObject objectiveUI;
    public TMP_Text objectiveText;
    public TMP_Text progressText;

    private int evidenceFound = 0;
    private int totalEvidence = 4;

    private void Start()
    {
        objectiveUI.SetActive(true);
        objectiveText.text = "Periksa Berkas Korban";
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

        objectiveText.text = "Periksa Berkas Korban";
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
            objectiveText.text = "Kembali ke Meja Analisis";

            ScoreManager.Instance.AddScore(100);

            FeedbackManager.Instance.ShowFeedback("MISSION COMPLETE\n+100 Bonus", Color.cyan);
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
        progressText.gameObject.SetActive(true);
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
