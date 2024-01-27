using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    #region Transition
    public LevelLoader TransitionAnimation;
    public GameObject LevelLoaderGameObject;
    #endregion

    private void Start()
    {
        LevelLoaderGameObject = GameObject.Find("LevelLoader");
        TransitionAnimation = LevelLoaderGameObject.GetComponent<LevelLoader>();
    }
    #region Play Button
    public void PlayButton()
    {
        TransitionAnimation.LoadNextLevel();
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
    }
    #endregion

    #region How To Play Button
    public void HowToPlayButton()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
    }
    #endregion

    #region Exit Button
    public void ExitButton()
    {
        
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
        Application.Quit();
        Debug.Log("Aplikasi sudah keluar");
    }

    public void HoverPlaySound()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonHover");
    }
    #endregion

    #region High Score Button

    public void HighScoreButton()
    {

    }

    #endregion

}
