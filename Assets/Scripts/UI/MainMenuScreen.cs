using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScoreText;
    int highScore = 0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "High Score : " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
