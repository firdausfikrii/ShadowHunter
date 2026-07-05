using TMPro;
using UnityEngine;

public class ChiefEnding : MonoBehaviour
{
    [Header("UI")]
    public GameObject interactionText;
    public GameObject dialoguePanel;
    public TMP_Text npcName;
    public TMP_Text dialogueText;
    public GameObject continueText;
    public GameObject missionCompletePanel;

    [Header("Chief")]
    public ChiefInteract chiefInteract;

    [Header("Gameplay")]
    public GameplayManager gameplayManager;

    [Header("Audio")]
    public AudioSource voiceAudio;

    private bool playerNearby = false;
    private bool reportFinished = false;
    private bool endingStarted = false;
    private bool notEnoughEvidence = false;

    private int dialogueIndex = 0;

    private readonly string[] dialogues =
    {
        "Kerja bagus, Detective Byte.\n\nKamu berhasil menghubungkan seluruh barang bukti.\n\nKorban menerima chat berisi QR Code palsu, kemudian memindainya. Setelah itu pelaku menelepon korban dan meminta kode OTP. Setelah OTP diberikan, akun Marketplace korban berhasil diambil alih.",

        "Kasus QR Scam berhasil diselesaikan.\n\nLaporanmu sangat baik.\n\nTerus tingkatkan kemampuan investigasimu.\n\nBersiaplah menghadapi kasus berikutnya."
    };

    public void EnableEnding()
    {
        reportFinished = true;

        if (chiefInteract != null)
        {
            chiefInteract.FinishIntro();
        }

        if (playerNearby)
        {
            interactionText.GetComponent<TMP_Text>().text =
                "Tekan E untuk Melapor kepada Chief";

            interactionText.SetActive(true);
        }

        Debug.Log("Chief Ending Enabled");
    }

    void Update()
    {
        if (!reportFinished || !playerNearby)
            return;

        // Dialog bukti belum cukup
        if (notEnoughEvidence)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CloseNotEnoughDialogue();
            }

            return;
        }

        if (!endingStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Chief Ending Interact");

                if (gameplayManager != null &&
                    gameplayManager.HasEnoughScore())
                {
                    OpenDialogue();
                }
                else
                {
                    ShowNotEnoughEvidence();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextDialogue();
            }
        }
    }

    void OpenDialogue()
    {
        endingStarted = true;

        interactionText.SetActive(false);

        dialoguePanel.SetActive(true);

        if (voiceAudio != null)
        {
            voiceAudio.Stop();
            voiceAudio.Play();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        npcName.text = "Chief";

        dialogueIndex = 0;
        dialogueText.text = dialogues[0];

        continueText.SetActive(true);
    }

    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex >= dialogues.Length)
        {
            FinishMission();
            return;
        }

        dialogueText.text = dialogues[dialogueIndex];
    }

    void ShowNotEnoughEvidence()
    {
        endingStarted = false;
        notEnoughEvidence = true;

        interactionText.SetActive(false);

        dialoguePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        npcName.text = "Chief";

        dialogueText.text =
            "Byte...\n\n" +
            "Bukti yang kamu kumpulkan belum cukup kuat.\n\n" +
            "Seorang investigator profesional tidak boleh\n" +
            "mengambil kesimpulan tanpa bukti yang lengkap.\n\n" +
            "Kembali dan kumpulkan seluruh barang bukti,\n" +
            "lalu laporkan kembali kepadaku.";

        continueText.SetActive(false);

        if (voiceAudio != null)
        {
            voiceAudio.Stop();
            voiceAudio.Play();
        }
    }

    void CloseNotEnoughDialogue()
    {
        notEnoughEvidence = false;

        dialoguePanel.SetActive(false);

        if (voiceAudio != null)
            voiceAudio.Stop();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        interactionText.SetActive(true);
    }

    void FinishMission()
    {
        dialoguePanel.SetActive(false);

        if (voiceAudio != null)
            voiceAudio.Stop();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        missionCompletePanel.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        if (!reportFinished)
            return;

        interactionText.GetComponent<TMP_Text>().text =
            "Tekan E untuk Melapor kepada Chief";

        interactionText.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = false;

        interactionText.SetActive(false);
    }
}