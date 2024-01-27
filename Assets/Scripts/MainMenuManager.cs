using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject levelLoader;
    [SerializeField] private AudioManager audioManager;
    // Start is called before the first frame update
    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void MainMenu()
    {
        audioManager.PlaySound("ButtonClick");
        levelLoader.GetComponent<LevelLoader>().ToMainMenu();
    }
}
