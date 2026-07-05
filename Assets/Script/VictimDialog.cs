using TMPro;
using UnityEngine;

public class VictimDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;

    [TextArea]
    public string[] dialogues;

    public AudioSource victimVoice;

    private int index;

    public ClueController clueController;

    void OnEnable()
    {
        index = 0;

        dialogueText.text = dialogues[index];

        // Putar suara sekali saja
        if (!victimVoice.isPlaying)
            victimVoice.Play();
    }

    public void NextDialogue()
    {
        index++;

        // Jika semua dialog selesai
        if (index >= dialogues.Length)
        {
            // Matikan suara
            if (victimVoice.isPlaying)
                victimVoice.Stop();

            // Tutup UI
            gameObject.SetActive(false);

            // Buka notebook
            clueController.ShowNotebook();

            return;
        }

        // Ganti teks saja
        dialogueText.text = dialogues[index];
    }
}
