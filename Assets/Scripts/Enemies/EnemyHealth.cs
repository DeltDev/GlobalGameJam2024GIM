using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    public float CurrentHealth = 1;
    [SerializeField] private Slider slider;
    public GameObject Self;
    public Action OnDeath;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        CurrentHealth = MaxHealth;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        ScoreManager.instance.AddScore((int)Mathf.Round(amount));
        CurrentHealth -= amount;
        UpdateHealthBar(MaxHealth, CurrentHealth);
        audioManager.PlaySound("DamageSFX");
        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
            Destroy(Self);
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
