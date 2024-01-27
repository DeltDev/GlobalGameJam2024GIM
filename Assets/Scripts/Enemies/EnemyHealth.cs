using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    public float CurrentHealth = 1;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private Slider slider;
    public GameObject levelLoader;
    public GameObject Self;
    void Start()
    {
        CurrentHealth = MaxHealth;
        //levelLoader = GameObject.Find("LevelLoader");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float MaxHealth, float CurrentHealth)
    {
        slider.value = CurrentHealth / MaxHealth;
    }

    void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        UpdateHealthBar(MaxHealth, CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Destroy(Self);
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            TakeDamage(1);
        }
    }
}