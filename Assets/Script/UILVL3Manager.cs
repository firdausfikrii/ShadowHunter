using UnityEngine;

public class UILVL3Manager : MonoBehaviour
{
    public static UILVL3Manager Instance;

    [Header("Evidence")]
    public GameObject report;
    public GameObject smartphone;
    public GameObject laptop;
    public GameObject victim;

    private void Awake()
    {
        Instance = this;
    }

    public void StartCase()
    {
        MissionManagerLVL3.Instance.ShowObjective("Periksa Berkas Korban");
    }

    public void ReportCompleted()
    {
        smartphone.SetActive(true);

        MissionManagerLVL3.Instance.ShowObjective("Periksa Smartphone Korban");
    }

    public void PhoneCompleted()
    {
        laptop.SetActive(true);

        MissionManagerLVL3.Instance.ShowObjective("Periksa Marketplace");
    }

    public void MarketplaceCompleted()
    {
        victim.SetActive(true);

        MissionManagerLVL3.Instance.ShowObjective("Wawancarai Korban");
    }

    public void VictimCompleted()
    {
        MissionManagerLVL3.Instance.ShowObjective("Kembali ke Meja Analisis");
    }
}