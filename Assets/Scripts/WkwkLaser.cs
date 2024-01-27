using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WkwkLaser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject WkwkLaserPrefab;
    [SerializeField] private Transform ProjectileSpawnPosition;
    [SerializeField] private float AttackCooldownTime;
    [SerializeField] private float ProjectileDespawnTime;
    [SerializeField] private int TickNumber;
    [SerializeField] private float TickSpeed;
    private TopDownController TopDown;
    private bool canWkwkAttack;
    void Start()
    {
        canWkwkAttack = true;
        TopDown = GetComponent<TopDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canWkwkAttack)
        {
            //WkwkAttack();
            canWkwkAttack = false;
            TopDown.disableRotation= true;
            StartCoroutine(AttackCooldown(AttackCooldownTime, TickSpeed, TickNumber));
        }
    }

    void WkwkAttack()
    {

        GameObject laser = Instantiate(WkwkLaserPrefab, ProjectileSpawnPosition.position, transform.rotation);
        //Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        //rb2D.AddForce(ProjectileSpawnPosition.right * ProjectileForce, ForceMode2D.Impulse);
        StartCoroutine(DespawnProjectile(ProjectileDespawnTime, laser));
    }

    IEnumerator AttackCooldown(float CooldownTime, float TickSpeed, int TickNumber)
    {
        for(int i = 0; i < TickNumber; i++)
        {
            yield return new WaitForSeconds(TickSpeed);
            GameObject laser = Instantiate(WkwkLaserPrefab, ProjectileSpawnPosition.position, transform.rotation);
            StartCoroutine(DespawnProjectile(ProjectileDespawnTime, laser));
        }
        TopDown.disableRotation = false;
        yield return new WaitForSeconds(CooldownTime);
        
        canWkwkAttack = true;
    }

    IEnumerator DespawnProjectile(float DespawnTime, GameObject laser)
    {
        yield return new WaitForSeconds(DespawnTime);
        
        Destroy(laser);
    }
}
