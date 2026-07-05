using UnityEngine;

public class CaseBoardManager : MonoBehaviour
{
    public GameObject boardPaper;

    public GameObject startButton;

    public GameObject investigationWarning;

    public void OpenWarning()
    {
        boardPaper.SetActive(false);

        startButton.SetActive(false);

        investigationWarning.SetActive(true);
    }
}