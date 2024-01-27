using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahahaAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject HahahaProjectilePrefab;
    [SerializeField] private float ProjectileForce;
    [SerializeField] private Transform ProjectileSpawnPosition;
    [SerializeField] private float AttackCooldownTime;
    [SerializeField] private float ProjectileDespawnTime;
    private bool canHahahaAttack;
    void Start()
    {
        canHahahaAttack= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(0) && canHahahaAttack && !PauseMenu.clickedButtonName.Equals("PauseButton"))
            {
                HahahahaAttack();
                canHahahaAttack = false;
                StartCoroutine(AttackCooldown(AttackCooldownTime));
            }
            
        }
    }

    void HahahahaAttack()
    {
        GameObject bullet = Instantiate(HahahaProjectilePrefab, ProjectileSpawnPosition.position, transform.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(ProjectileSpawnPosition.right * ProjectileForce, ForceMode2D.Impulse);
        StartCoroutine(DespawnProjectile(ProjectileDespawnTime, bullet));
    }

    IEnumerator AttackCooldown(float CooldownTime)
    {
        yield return new WaitForSeconds(CooldownTime);
        canHahahaAttack = true;
    }

    IEnumerator DespawnProjectile(float DespawnTime, GameObject bullet)
    {
        yield return new WaitForSeconds(DespawnTime);
        Destroy(bullet);
    }
}
