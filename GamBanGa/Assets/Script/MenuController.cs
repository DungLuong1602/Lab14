using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    public TextMeshProUGUI ScoreText;
    public int Score = 0;
    public GameObject GameOverPanel;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        Score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
            ScoreText.text = "Score: " + Score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.PlaySFX("Gameover");
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
    }
}
