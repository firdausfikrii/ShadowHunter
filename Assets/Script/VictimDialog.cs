using TMPro;
using UnityEngine;

public class VictimDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;

    [TextArea]
    public string[] dialogues;

    private int index;

    public ClueController clueController;

    void OnEnable()
    {
        index = 0;
        dialogueText.text = dialogues[index];
    }

    public void NextDialogue()
    {
        index++;

        if (index >= dialogues.Length)
        {
            // Tutup dialog
            gameObject.SetActive(false);

            // Buka Notebook
            clueController.ShowNotebook();

            return;
        }

        dialogueText.text = dialogues[index];
    }
}
