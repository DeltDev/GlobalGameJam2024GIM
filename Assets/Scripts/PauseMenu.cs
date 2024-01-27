using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public static string clickedButtonName = "";
    [SerializeField] private AudioManager audioManager;
    public GameObject levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader");
        pauseMenu.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                audioManager.PlaySound("ResumeSFX");
                ResumeGame();
            } else
            {
                audioManager.PlaySound("PauseSFX");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        audioManager.PlaySound("PauseSFX");
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseButton()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        audioManager.PlaySound("ResumeSFX");
        Time.timeScale = 1f;
        isPaused = false;
        clickedButtonName = "";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        levelLoader.GetComponent<LevelLoader>().RestartLevel();
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        audioManager.PlaySound("ButtonClick");
        isPaused = false;
        clickedButtonName = "";
    }

    public void QuitGame()
    {
        
        clickedButtonName = "";

        audioManager.PlaySound("ButtonClick");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
