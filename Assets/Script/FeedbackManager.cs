using System.Collections;
using TMPro;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager Instance;

    public GameObject panel;
    public TMP_Text feedbackText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowFeedback(string message, Color color)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message, color));
    }

    IEnumerator ShowRoutine(string message, Color color)
    {
        panel.SetActive(true);

        feedbackText.text = message;
        feedbackText.color = color;

        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
    }
}
