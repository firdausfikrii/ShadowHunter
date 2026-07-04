using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public TMP_Text scoreText;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}