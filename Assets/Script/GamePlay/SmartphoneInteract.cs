using TMPro;
using UnityEngine;

public class SmartphoneInteract : MonoBehaviour
{
    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject interactionText;
    public GameObject smartphonePanel;

    private bool playerNearby = false;
    private bool alreadyOpened = false;

    void Start()
    {
        interactionText.SetActive(false);
        smartphonePanel.SetActive(false);
    }

    void Update()
    {
        if (alreadyOpened)
            return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Hanya bisa dibuka jika objective Smartphone
            if (caseFlow.CurrentMission != CaseFlow.MissionState.Smartphone)
                return;

            OpenSmartphone();
        }
    }

    void OpenSmartphone()
    {
        interactionText.SetActive(false);

        smartphonePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

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

        if (caseFlow.CurrentMission == CaseFlow.MissionState.Smartphone)
        {
            txt.text = "Tekan E untuk memeriksa Smartphone";
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