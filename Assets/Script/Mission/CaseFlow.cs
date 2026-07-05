using TMPro;
using UnityEngine;

public class CaseFlow : MonoBehaviour
{
    public enum MissionState
    {
        MeetChief,
        CaseBoard,
        Laptop,
        Smartphone,
        Telephone,
        Report,
        Chief,
        Complete,
    }

    [Header("Objective UI")]
    public TMP_Text objectiveText;

    public MissionState CurrentMission { get; private set; } = MissionState.MeetChief;

    void Start()
    {
        UpdateObjective();
    }

    void UpdateObjective()
    {
        switch (CurrentMission)
        {
            case MissionState.MeetChief:
                objectiveText.text = "🎯 OBJECTIVE\n\nTemui Chief";
                break;

            case MissionState.CaseBoard:
                objectiveText.text = "🎯 OBJECTIVE\n\nTemui Case Board";
                break;

            case MissionState.Laptop:
                objectiveText.text = "🎯 OBJECTIVE\n\nPeriksa Laptop Bukti";
                break;

            case MissionState.Smartphone:
                objectiveText.text = "🎯 OBJECTIVE\n\nPeriksa Smartphone Korban";
                break;

            case MissionState.Telephone:
                objectiveText.text = "🎯 OBJECTIVE\n\nPeriksa Rekaman Telepon";
                break;

            case MissionState.Report:
                objectiveText.text = "🎯 OBJECTIVE\n\nBuat Laporan Investigasi";
                break;

            case MissionState.Chief:
                objectiveText.text = "🎯 OBJECTIVE\n\nLaporkan Hasil\nInvestigasi kepada Chief";
                break;

            case MissionState.Complete:
                objectiveText.text = "🎯 OBJECTIVE\n\nMISSION COMPLETE";
                break;
        }
    }

    public void FinishMeetChief()
    {
        SetMission(MissionState.CaseBoard);
    }

    public void FinishCaseBoard()
    {
        SetMission(MissionState.Laptop);
    }

    public void FinishLaptop()
    {
        SetMission(MissionState.Smartphone);
    }

    public void FinishSmartphone()
    {
        SetMission(MissionState.Telephone);
    }

    public void FinishTelephone()
    {
        SetMission(MissionState.Report);
    }

    public void FinishReport()
    {
        SetMission(MissionState.Chief);
    }

    public void FinishMission()
    {
        SetMission(MissionState.Complete);
    }

    void SetMission(MissionState mission)
    {
        CurrentMission = mission;
        UpdateObjective();
    }
}
