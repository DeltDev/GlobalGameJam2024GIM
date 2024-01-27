using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score : " + score.ToString();
        highScoreText.text = "High Score : " + highScore.ToString();
    }

    // Basically like Update()
    // Put this in EnemyHealth

    public void AddScore(int scoreGained)
    {
        score += scoreGained;
        scoreText.text = "Score : " + score.ToString();
        PlayerPrefs.SetInt("highscore", ScoreManager.instance.GetScore());

    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }


}
