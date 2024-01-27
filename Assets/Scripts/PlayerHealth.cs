using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    public float CurrentHealth = 1;
    [SerializeField] private Collider2D PlayerCollider;
    public Image fillImage;
    public Slider slider;
    public GameObject levelLoader;
    private float fillvalue;
    void Start()
    {
        //slider = GetComponent<slider>();
        fillImage.enabled = true;
        slider.value = MaxHealth;
        CurrentHealth = MaxHealth;
        levelLoader = GameObject.Find("LevelLoader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        float fillvalue = CurrentHealth / MaxHealth;
        slider.value = fillvalue;
        if(slider.value <= 0)
        {
            fillImage.enabled = false;
        }
        if(CurrentHealth <= 0)
        {
            Destroy(GameObject.Find("Player"));
            levelLoader.GetComponent<LevelLoader>().RestartLevel();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyProjectile")
        {
            TakeDamage(1);
        }
    }
}