using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    public LevelLoader TransitionAnimation;
    public GameObject LevelLoaderGameObject;
    [SerializeField] private AudioManager audioManager;
    

    void Start()
    {
        LevelLoaderGameObject = GameObject.Find("LevelLoader");
        TransitionAnimation = LevelLoaderGameObject.GetComponent<LevelLoader>();
        textComponent.text = string.Empty;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                audioManager.PlaySound("ButtonClick");
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            audioManager.PlaySound("DialogueSFX");
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            Scene activeScene = SceneManager.GetActiveScene();
            gameObject.SetActive(false);
            if (activeScene.name.Equals("Prologue"))
            {
                TransitionAnimation.LoadNextLevel();
            }

        }
    }

    
}
