using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UI")]
    public GameObject gameOverUI;

    [Header("Player")]
    public MonoBehaviour playerMovement;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        AudioManager.Instance.PlayGameOverMusic();
        gameOverUI.SetActive(true);

        playerMovement.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
