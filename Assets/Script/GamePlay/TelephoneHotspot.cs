using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneHotspot : MonoBehaviour
{
    [Header("Manager")]
    public TelephoneEvidenceManager manager;

    [Header("Analysis")]
    public TMP_Text analysisText;

    [TextArea(3, 6)]
    public string message;

    [Header("Hotspot")]
    public bool isCorrect;

    private bool solved = false;
    public bool IsSolved => solved;

    private Image image;
    private Button button;

    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (analysisText != null)
            analysisText.gameObject.SetActive(false);
    }

    public void Analyze()
    {
        // Kalau tombol sudah tidak bisa diklik
        if (!button.interactable)
            return;

        // Kalau investigasi sudah gagal
        if (manager != null && manager.IsLocked())
            return;

        // Tampilkan analisis
        if (analysisText != null)
        {
            analysisText.gameObject.SetActive(true);
            analysisText.text = message;
        }

        if (isCorrect)
        {
            solved = true;
            image.color = new Color(0f, 1f, 0f, 0.35f);
        }
        else
        {
            image.color = new Color(1f, 0f, 0f, 0.35f);

            if (manager != null)
                manager.WrongAnswer();
        }

        button.interactable = false;
    }

    public void ResetHotspot()
    {
        solved = false;

        button.interactable = true;

        image.color = new Color(1f, 1f, 1f, 0f);
    }
}