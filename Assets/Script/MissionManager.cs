using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public GameObject objectiveUI;

    public TMP_Text progressText;
    public TMP_Text objectiveText;

    private int evidenceFound = 0;

    private int totalEvidence = 3;

    void Awake()
    {
        Instance = this;
    }

    public void StartMission()
    {
        evidenceFound = 0;

        objectiveText.text = "Cari 3 Bukti";

        progressText.gameObject.SetActive(true);

        UpdateProgress();
    }

    public void AddEvidence()
    {
        evidenceFound++;

        UpdateProgress();

        if (evidenceFound >= totalEvidence)
        {
            Debug.Log("Mission Selesai");
        }
    }

    void UpdateProgress()
    {
        progressText.text = evidenceFound + " / " + totalEvidence;
    }

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
}
