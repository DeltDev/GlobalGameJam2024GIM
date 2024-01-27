using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI isHighScoreText;
    public GameObject highScoreObject;

    private void Start()
    {
        highScoreObject.SetActive(false);
        scoreText.text = "Score : " + ScoreManager.instance.score.ToString();
        if (ScoreManager.instance.highScore < ScoreManager.instance.score)
        {
            
            PlayerPrefs.SetInt("highscore", ScoreManager.instance.score);
            highScoreObject.SetActive(true);


        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
