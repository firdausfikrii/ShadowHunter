using UnityEngine;

public class ClickableClue : MonoBehaviour
{
    public bool isCorrect;

    public GameObject collectButton;

    public void Click()
    {
        if (isCorrect)
        {
            collectButton.SetActive(true);

            FeedbackManager.Instance.ShowFeedback("✔ Analisis Berhasil", Color.green);
        }
        else
        {
            LifeManager.Instance.LoseLife();

            FeedbackManager.Instance.ShowFeedback("✗ Analisis Gagal", Color.red);
        }
    }
}
