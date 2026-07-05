using UnityEngine;

public class NotebookClue : MonoBehaviour
{
    public bool isCorrect;

    public ClueController clueController;

    public void Click()
    {
        if (isCorrect)
        {
            clueController.ShowNotebook();

            FeedbackManager.Instance.ShowFeedback("✔ Bukti ditemukan", Color.green);
        }
        else
        {
            LifeManager.Instance.LoseLife();

            FeedbackManager.Instance.ShowFeedback("✘ Analisis Gagal", Color.red);
        }
    }
}
