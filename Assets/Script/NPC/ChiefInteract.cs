using TMPro;
using UnityEngine;

public class ChiefInteract : MonoBehaviour
{
    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject interactionText;

    [Header("Dialogue")]
    public ByteTalk dialogueManager;

    [Header("Ending")]
    public ChiefEnding chiefEnding;

    private bool playerNearby = false;
    private bool introFinished = false;

    void Start()
    {
        interactionText.SetActive(false);
    }

    void Update()
    {
        if (!playerNearby)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Dialog awal
            if (!introFinished)
            {
                dialogueManager.StartDialogue("Chief");
                interactionText.SetActive(false);
                return;
            }

            // Sudah waktunya melapor
            if (caseFlow.CurrentMission == CaseFlow.MissionState.Chief)
            {
                if (chiefEnding != null)
                {
                    chiefEnding.EnableEnding();
                }

                interactionText.SetActive(false);
                return;
            }

            // Selain itu tidak melakukan apa-apa
        }
    }

    // Dipanggil ByteTalk setelah dialog awal selesai
    public void FinishIntro()
    {
        introFinished = true;

        UpdateInteractionText();
    }

    void UpdateInteractionText()
    {
        if (!playerNearby)
            return;

        TMP_Text txt = interactionText.GetComponent<TMP_Text>();

        if (!introFinished)
        {
            txt.text = "Tekan E untuk berbicara";
        }
        else if (caseFlow.CurrentMission == CaseFlow.MissionState.Chief)
        {
            txt.text = "Tekan E untuk Melapor kepada Chief";
        }
        else
        {
            txt.text = "Selesaikan investigasi terlebih dahulu.";
        }

        interactionText.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;
        UpdateInteractionText();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = false;
        interactionText.SetActive(false);
    }
}