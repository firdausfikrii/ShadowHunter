using TMPro;
using UnityEngine;

public class ReportInteract : MonoBehaviour
{
    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject interactionText;
    public GameObject reportPanel;

    private bool playerNearby = false;

    void Start()
    {
        interactionText.SetActive(false);
        reportPanel.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Hanya bisa dibuka jika objective Report
            if (caseFlow.CurrentMission != CaseFlow.MissionState.Report)
                return;

            interactionText.SetActive(false);

            reportPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        TMP_Text txt = interactionText.GetComponent<TMP_Text>();

        if (caseFlow.CurrentMission == CaseFlow.MissionState.Report)
        {
            txt.text =
                "Tekan E untuk Membuat\nLaporan Investigasi";
        }
        else
        {
            txt.text =
                "Kumpulkan seluruh bukti\nterlebih dahulu.";
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