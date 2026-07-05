using TMPro;
using UnityEngine;

public class LaptopInteract : MonoBehaviour
{
    [Header("Mission")]
    public CaseFlow caseFlow;

    [Header("UI")]
    public GameObject interactionText;
    public GameObject laptopPanel;

    private bool playerNearby = false;
    private bool alreadyOpened = false;

    void Start()
    {
        interactionText.SetActive(false);
        laptopPanel.SetActive(false);
    }

    void Update()
    {
        if (alreadyOpened)
            return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Hanya bisa dibuka saat objective Laptop
            if (caseFlow.CurrentMission != CaseFlow.MissionState.Laptop)
                return;

            interactionText.SetActive(false);

            laptopPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
    }

    public void CloseLaptop()
    {
        laptopPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

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

        if (caseFlow.CurrentMission == CaseFlow.MissionState.Laptop)
        {
            txt.text = "Tekan E untuk memeriksa Laptop";
        }
        else
        {
            txt.text = "Objective saat ini bukan memeriksa Laptop.";
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