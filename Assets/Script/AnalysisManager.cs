using UnityEngine;

public class AnalysisManager : MonoBehaviour
{
    public static AnalysisManager Instance;

    public Interactable analysisInteractable;

    private bool analysisUnlocked;

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockAnalysis()
    {
        if (analysisUnlocked)
            return;

        analysisUnlocked = true;

        MissionManagerLVL3.Instance.ShowObjective("Kembali ke Meja Analisis");

        analysisInteractable.enabled = true;
    }
}
