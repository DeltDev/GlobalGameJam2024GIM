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
    [SerializeField] private AudioManager audioManager;
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
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void GoToMainMenu()
    {
        audioManager.PlaySound("ButtonClick");
        levelLoader.GetComponent<LevelLoader>().ToMainMenu();
    }

    public void QuitGame()
    {
        audioManager.PlaySound("ButtonClick");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void TryAgain()
    {
        audioManager.PlaySound("ResumeSFX");
        levelLoader.GetComponent<LevelLoader>().LoadPreviousLevel();
    }
}
