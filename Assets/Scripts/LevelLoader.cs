using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
 
    public void LoadNextLevel()
    {
        Debug.Log("Animation Loaded");
        StartCoroutine(LoadWithTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void RestartLevel()
    {
        Debug.Log("Animation Loaded");
        StartCoroutine(LoadWithTransition(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadPreviousLevel()
    {
        Debug.Log("Animation Loaded");
        StartCoroutine(LoadWithTransition(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void ToMainMenu()
    {
        StartCoroutine(LoadWithTransition(0));
    }
    IEnumerator LoadWithTransition(int LevelIdx)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelIdx);
    }

}
