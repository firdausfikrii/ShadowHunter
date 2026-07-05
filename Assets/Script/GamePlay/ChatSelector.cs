using TMPro;
using UnityEngine;

public class ChatSelector : MonoBehaviour
{
    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Smartphone UI")]
    public SmartphoneUI smartphoneUI;

    [Header("Analysis")]
    public TMP_Text analysisText;

    [TextArea(3, 6)]
    public string message;

    public bool isCorrect;

    private bool alreadyClicked = false;

    public void SelectChat()
    {
        Debug.Log($"SelectChat() dipanggil dari : {gameObject.name}");

        if (alreadyClicked)
        {
            Debug.Log("Button sudah pernah diklik.");
            return;
        }

        alreadyClicked = true;

        // Tampilkan analisis
        if (analysisText != null)
        {
            analysisText.gameObject.SetActive(true);
            analysisText.text = message;
        }
        else
        {
            Debug.LogError("Analysis Text belum di-drag!");
        }

        if (isCorrect)
        {
            Debug.Log("Chat yang dipilih BENAR.");
            OpenChat();
        }
        else
        {
            Debug.Log("Chat yang dipilih SALAH.");

            if (gameplayManager != null)
                gameplayManager.LoseFocus();
            else
                Debug.LogError("GameplayManager belum di-drag!");
        }
    }

    void OpenChat()
    {
        Debug.Log("OpenChat() dijalankan.");

        if (smartphoneUI != null)
        {
            smartphoneUI.OpenScamChat();
        }
        else
        {
            Debug.LogError("SmartphoneUI belum di-drag!");
        }
    }
}