using TMPro;
using UnityEngine;

public class AnalysisPopup : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text analysisText;

    public void Show(string message)
    {
        panel.SetActive(true);
        analysisText.text = message;

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Close()
    {
        panel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}