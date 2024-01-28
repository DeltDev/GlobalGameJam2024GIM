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
    public float HealthGain;
    private bool canActivate;
    private bool canDamage;
    [SerializeField] private float CooldownTime;
    [SerializeField] private float Invincibility;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        //slider = GetComponent<slider>();
        canActivate = true;
        canDamage = true;
        fillImage.enabled = true;
        slider.value = MaxHealth;
        CurrentHealth = MaxHealth;
        levelLoader = GameObject.Find("LevelLoader");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && canActivate)
        {
            Die();
            canActivate = false;
            StartCoroutine(Cooldown(CooldownTime));
        }
    }

    void Die()
    {
        canDamage = false;
        StartCoroutine(DespawnProjectile(Invincibility, PlayerCollider));
    }

    IEnumerator Cooldown(float CooldownTime)
    {
        yield return new WaitForSeconds(CooldownTime);
        canActivate = true;
    }

    IEnumerator DespawnProjectile(float Invincibility, Collider2D PlayerCollider)
    {
        yield return new WaitForSeconds(Invincibility);
        canDamage = true;
    }

    public void TakeDamage(float amount)
    {
        if (canDamage)
        {
            audioManager.PlaySound("DamageSFX");
            CurrentHealth -= amount;
            float fillvalue = CurrentHealth / MaxHealth;
            slider.value = fillvalue;
            if (slider.value <= 0)
            {
                fillImage.enabled = false;
            }
            if (CurrentHealth <= 0)
            {
                audioManager.PlaySound("GameOverSFX");
                Destroy(GameObject.Find("Player"));
                levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "EnemyProjectile")
        //{
        //    TakeDamage(1);
        //}
        if (collision.tag == "ExtraHP")
        {
            TakeDamage(-HealthGain);
            Destroy(collision.gameObject);
            if (CurrentHealth > MaxHealth)
            {
                TakeDamage(HealthGain);
                //CurrentHealth = MaxHealth;
            }
        }
    }
}