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
    public GameObject levelLoader;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader");
        highScoreObject.SetActive(false);
        scoreText.text = "Score : " + ScoreManager.instance.GetScore().ToString();
        if (ScoreManager.instance.GetHighScore() < ScoreManager.instance.GetScore())
        {
            
            PlayerPrefs.SetInt("highscore", ScoreManager.instance.GetScore());
            highScoreObject.SetActive(true);


        }
    }

    public void GoToMainMenu()
    {
        levelLoader.GetComponent<LevelLoader>().ToMainMenu();
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void TryAgain()
    {
        levelLoader.GetComponent<LevelLoader>().LoadPreviousLevel();
    }
}
