using TMPro;
using UnityEngine;

public class ReportManager : MonoBehaviour
{
    [Header("Timeline")]
    public TMP_Text[] steps;

    [Header("Cards")]
    public GameObject[] cards;

    [Header("Gameplay")]
    public GameplayManager gameplayManager;
    public CaseFlow caseFlow;
    public ChiefEnding chiefEnding;

    [Header("UI")]
    public GameObject reportPanel;
    public TMP_Text resultText;

    private int currentStep = 0;
    private int wrongAttempt = 0;

    public string[] playerOrder = new string[6];

    private readonly string[] correctOrder =
    {
        "Korban menerima chat QR",
        "Korban memindai QR Code",
        "Pelaku menelepon korban",
        "Korban memberikan kode OTP",
        "Akun Marketplace diambil alih",
        "Saldo rekening berkurang",
    };

    public void AddEvidence(string evidence)
    {
        if (currentStep >= steps.Length)
            return;

        steps[currentStep].text = (currentStep + 1) + ". " + evidence;

        playerOrder[currentStep] = evidence;

        currentStep++;
    }

    public void ResetTimeline()
    {
        currentStep = 0;
        wrongAttempt = 0;

        resultText.gameObject.SetActive(false);

        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].text = (i + 1) + ". ...";
            playerOrder[i] = "";
        }

        foreach (GameObject card in cards)
        {
            card.SetActive(true);
        }
    }

    public void CheckReport()
    {
        // =========================
        // CEK KRONOLOGI
        // =========================

        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                wrongAttempt++;

                gameplayManager.LoseFocus();

                resultText.gameObject.SetActive(true);

                if (wrongAttempt == 1)
                {
                    resultText.text =
                        "❌ Kronologi masih belum sesuai.\n\n"
                        + "Susunan kejadian belum menggambarkan\n"
                        + "alur penipuan yang sebenarnya.\n\n"
                        + "Periksa kembali seluruh barang bukti.";
                }
                else if (wrongAttempt == 2)
                {
                    resultText.text =
                        "⚠ Investigasi Belum Teliti\n\n"
                        + "Seorang investigator harus\n"
                        + "memperhatikan setiap bukti,\n"
                        + "chat, website, dan rekaman\n"
                        + "yang telah diperiksa.\n\n"
                        + "Coba analisis kembali\n"
                        + "dengan lebih teliti.";
                }
                else
                {
                    AudioManager.Instance.PlayGameOverMusic();
                    resultText.text =
                        "❌ MISSION FAILED\n\n"
                        + "Fokus investigasi telah habis.\n\n"
                        + "Kamu gagal menyusun\n"
                        + "kronologi kasus.";

                    Invoke(nameof(OpenGameOver), 2f);
                }

                return;
            }
        }

        // =========================
        // JIKA BENAR
        // =========================

        resultText.gameObject.SetActive(true);

        resultText.text =
            "✔ Kronologi berhasil disusun.\n\n"
            + "Laporan investigasi telah selesai dibuat.\n\n"
            + "Sekarang laporkan hasil investigasi kepada Chief.";

        AudioManager.Instance.PlayVictoryMusic();
        gameplayManager.AddScore(100);
        gameplayManager.AddEvidence();

        // Objective berubah
        caseFlow.FinishReport();

        // Tutup panel setelah 2.5 detik
        CloseReport();
    }

    void CloseReport()
    {
        reportPanel.SetActive(false);

        resultText.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        // Chief baru aktif setelah panel report ditutup
        if (chiefEnding != null)
        {
            chiefEnding.EnableEnding();
        }
    }

    void OpenGameOver()
    {
        gameplayManager.GameOver();
    }
}
