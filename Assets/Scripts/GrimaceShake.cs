using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimaceShake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BoxCollider2D PlayerCollider;
    [SerializeField] private float CooldownTime;
    [SerializeField] private float DespawnTime;
    private bool canActivate;
    void Start()
    {
        canActivate = true;
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
        PlayerCollider.isTrigger = false;
        StartCoroutine(DespawnProjectile(DespawnTime, PlayerCollider));
    }

    IEnumerator Cooldown(float CooldownTime)
    {
        yield return new WaitForSeconds(CooldownTime);
        canActivate = true;
    }

    IEnumerator DespawnProjectile(float DespawnTime, BoxCollider2D PlayerCollider)
    {
        yield return new WaitForSeconds(DespawnTime);
        PlayerCollider.isTrigger = true;
    }
}
