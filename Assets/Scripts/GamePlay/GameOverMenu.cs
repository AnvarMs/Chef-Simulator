using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newRecordText;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        finalScoreText.text = $"Score: {score}";
        highScoreText.text = $"Best: {highScore}";
        newRecordText.text = score >= highScore && score > 0 ? "NEW BEST!" : "";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
}