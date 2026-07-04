using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    [Header("Life")]
    public Image[] hearts;

    public int maxLife = 3;

    private int currentLife;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentLife = maxLife;
        UpdateLifeUI();
    }

    public void LoseLife()
    {
        if (currentLife <= 0)
            return;

        currentLife--;

        UpdateLifeUI();

        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    public void AddLife()
    {
        if (currentLife >= maxLife)
            return;

        currentLife++;

        UpdateLifeUI();
    }

    void UpdateLifeUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLife;
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
