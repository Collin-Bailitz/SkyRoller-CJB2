using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text scoreText;
    public GameObject gameOverPanel;

    public Transform player;

    float score;
    bool gameOver;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (gameOver) return;

        score += Time.deltaTime;
        scoreText.text = "Survival Score: " + Mathf.FloorToInt(score);
    }

    public void LoseGame()
    {
        gameOver = true;
        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}