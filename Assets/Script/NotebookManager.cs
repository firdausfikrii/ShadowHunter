using TMPro;
using UnityEngine;

public class NotebookManager : MonoBehaviour
{
    public static NotebookManager Instance;

    [Header("UI")]
    public GameObject notebookUI;
    public TMP_Text clueText;

    private Evidence currentEvidence;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowNotebook(string clue, Evidence evidence)
    {
        notebookUI.SetActive(true);

        clueText.text = clue;

        currentEvidence = evidence;
    }

    public void Confirm()
    {
        notebookUI.SetActive(false);

        if (currentEvidence != null)
        {
            currentEvidence.Collect();
            currentEvidence = null;
        }

        if (MissionManagerLVL3.Instance.IsMissionComplete())
        {
            AnalysisManager.Instance.UnlockAnalysis();
        }
    }
}
