using TMPro;
using UnityEngine;

public class ByteTalk : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public TMP_Text continueText;

    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("Chief")]
    public ChiefInteract chiefInteract;

    [Header("Audio")]
    public AudioSource voiceAudio;

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogueLines;

    private int currentLine = 0;
    private bool isTalking = false;

    public bool IsTalking => isTalking;

    public void StartDialogue(string npcName)
    {
        if (isTalking)
            return;

        currentLine = 0;
        isTalking = true;

        dialoguePanel.SetActive(true);

        // Putar suara Chief
        if (voiceAudio != null)
        {
            voiceAudio.Stop();
            voiceAudio.Play();
        }

        npcNameText.text = npcName;
        dialogueText.text = dialogueLines[currentLine];

        if (continueText != null)
            continueText.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!isTalking)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;

            if (currentLine >= dialogueLines.Length)
            {
                EndDialogue();
            }
            else
            {
                dialogueText.text = dialogueLines[currentLine];
            }
        }
    }

    void EndDialogue()
    {
        isTalking = false;

        dialoguePanel.SetActive(false);

        // Hentikan suara jika masih diputar
        if (voiceAudio != null)
        {
            voiceAudio.Stop();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        if (caseFlow != null)
        {
            caseFlow.FinishMeetChief();
        }

        if (chiefInteract != null)
        {
            chiefInteract.FinishIntro();
        }
    }
}