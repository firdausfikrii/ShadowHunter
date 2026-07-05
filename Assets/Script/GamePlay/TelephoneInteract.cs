using TMPro;
using UnityEngine;

public class TelephoneInteract : MonoBehaviour
{
    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject interactionText;
    public GameObject telephonePanel;

    private bool playerNearby = false;
    private bool alreadyOpened = false;

    void Start()
    {
        interactionText.SetActive(false);
        telephonePanel.SetActive(false);
    }

    void Update()
    {
        if (alreadyOpened)
            return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Hanya bisa dibuka jika objective Telephone
            if (caseFlow.CurrentMission != CaseFlow.MissionState.Telephone)
                return;

            OpenTelephone();
        }
    }

    void OpenTelephone()
    {
        interactionText.SetActive(false);

        telephonePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    // Dipanggil setelah investigasi telepon selesai
    public void FinishInvestigation()
    {
        alreadyOpened = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (alreadyOpened)
            return;

        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        TMP_Text txt = interactionText.GetComponent<TMP_Text>();

        if (caseFlow.CurrentMission == CaseFlow.MissionState.Telephone)
        {
            txt.text = "Tekan E untuk memeriksa Rekaman Telepon";
        }
        else
        {
            txt.text = "Selesaikan objective sebelumnya.";
        }

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