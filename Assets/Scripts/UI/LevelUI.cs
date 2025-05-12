using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{

    //ui elements ref
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject gameOverScreen;

    //buttons
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button backToHomeButton;

    public float backgroundMoveSpeed;

    private void Start()
    {
        scoreText.text = "Score: 0";
        coinsText.text = "Coins: 0";
        restartGameButton.onClick.AddListener(RestartGame);
        backToHomeButton.onClick.AddListener(BackToHome);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void BackToHome()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void UpdateCoinsUI(int coins)
    {
        coinsText.text = "Coins: " + coins.ToString();
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.gameObject.SetActive(true);
    }

}
