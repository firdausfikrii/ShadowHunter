using UnityEngine;
using UnityEngine.UI;

public class WebsiteHotspot : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Analysis Text")]
    public GameObject analysisText;

    [Header("Hotspot")]
    public bool isCorrect = true;

    private bool alreadyClicked = false;
    public bool IsSolved => alreadyClicked && isCorrect;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        if (analysisText != null)
            analysisText.SetActive(false);
    }

    public void Analyze()
    {
        if (alreadyClicked)
            return;

        alreadyClicked = true;

        // Munculkan analisis
        if (analysisText != null)
            analysisText.SetActive(true);

        // Jika benar
        if (isCorrect)
        {
            gameplayManager.AddScore(20);

            image.color = new Color(0f, 1f, 0f, 0.35f);
        }
        // Jika salah
        else
        {
            gameplayManager.LoseFocus();

            image.color = new Color(1f, 0f, 0f, 0.35f);
        }

        // Tidak bisa diklik lagi
        GetComponent<Button>().interactable = false;
    }
}