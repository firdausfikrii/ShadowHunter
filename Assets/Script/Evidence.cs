using UnityEngine;

public class Evidence : MonoBehaviour
{
    public enum EvidenceType
    {
        Normal,
        Report,
        Smartphone,
        Marketplace,
        Victim,
    }

    [Header("Level 3")]
    public EvidenceType evidenceType = EvidenceType.Normal;
    private bool collected;

    [Header("Reward")]
    public int scoreReward = 50;

    public void Collect()
    {
        if (collected)
            return;

        collected = true;

        // Tambah Score
        ScoreManager.Instance.AddScore(scoreReward);
        FeedbackManager.Instance.ShowFeedback("+50 Score", Color.yellow);

        // Progress Level 1
        if (MissionManager.Instance != null)
        {
            MissionManager.Instance.AddEvidence();
        }

        // Progress Level 3
        if (MissionManagerLVL3.Instance != null)
        {
            MissionManagerLVL3.Instance.AddEvidence();
        }

        // Tutup UI Evidence
        UIManager.Instance.CloseCurrentUI();

        // Evidence tidak bisa diambil lagi
        gameObject.SetActive(false);

        // Alur khusus Level 3
        if (UILVL3Manager.Instance != null)
        {
            switch (evidenceType)
            {
                case EvidenceType.Report:
                    UILVL3Manager.Instance.ReportCompleted();
                    break;

                case EvidenceType.Smartphone:
                    UILVL3Manager.Instance.PhoneCompleted();
                    break;

                case EvidenceType.Marketplace:
                    UILVL3Manager.Instance.MarketplaceCompleted();
                    break;

                case EvidenceType.Victim:
                    UILVL3Manager.Instance.VictimCompleted();
                    break;
            }
        }
    }
}
