using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameDuration = 180f; // 3 minutes
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int highScore;
    private float timeRemaining;
    private int score;
    private bool isGameOver;
    public bool IsGameOver() => isGameOver;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        timeRemaining = gameDuration;
        score = 0;
        isGameOver = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    private void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        UpdateUI();

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();
        }
    }

    public void AddScore(int points)
    {
        if (isGameOver) return;
        score += points;
        UpdateUI();
    }

    private void UpdateUI()
    {
        int min = Mathf.FloorToInt(timeRemaining / 60f);
        int sec = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = $"{min:00}:{sec:00}";
        timerText.color = timeRemaining < 30f ? Color.red : Color.white;
        scoreText.text = $"Score: {score}";
        highScoreText.text = $"Best: {highScore}";
    }

    private void EndGame()
    {
        isGameOver = true;

        PlayerPrefs.SetInt("LastScore", score);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateUI();
        SceneManager.LoadScene("GameOverScene");
    }
}