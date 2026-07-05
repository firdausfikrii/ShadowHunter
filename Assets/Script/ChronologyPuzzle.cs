using UnityEngine;

public class ChronologyPuzzle : MonoBehaviour
{
    public static ChronologyPuzzle Instance;

    private int currentStep = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckStep(int step)
    {
        if (step == currentStep)
        {
            currentStep++;

            if (currentStep >= 4)
            {
                PuzzleComplete();
            }
        }
        else
        {
            PuzzleFailed();
        }
    }

    void PuzzleComplete()
    {
        Debug.Log("Puzzle Complete");

        UIManager.Instance.CloseCurrentUI();
        OutroManager.Instance.StartOutro();
    }

    void PuzzleFailed()
    {
        Debug.Log("Wrong Order");

        currentStep = 0;

        LifeManager.Instance.LoseLife();
    }
}
