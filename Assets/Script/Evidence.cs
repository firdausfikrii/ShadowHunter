using UnityEngine;

public class Evidence : MonoBehaviour
{
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

        // Tambah Progress Mission
        MissionManager.Instance.AddEvidence();

        // Tutup UI Evidence
        UIManager.Instance.CloseCurrentUI();

        // Evidence tidak bisa diambil lagi
        gameObject.SetActive(false);
    }
}
