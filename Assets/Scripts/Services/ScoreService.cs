using UnityEngine;

public class ScoreService
{
    public LevelUI levelUI;
    private int scoreVal;
    private int score;
    private int coins;

    //Score and Coins Data Handling
    public ScoreService(LevelUI levelUI)
    {
        score = 0;
        coins = 0;
        scoreVal = 5;
        this.levelUI = levelUI;
    }
    public void IncreaseScore()
    {
        score += scoreVal;
        levelUI.UpdateScoreUI(score);
    }
    public void IncreaseCoins()
    {
        coins++;
        levelUI.UpdateCoinsUI(coins);
    }
}
