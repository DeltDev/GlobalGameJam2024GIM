using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birjon : MonoBehaviour
{
    public Transform player;
    [Header("Birjon Settings")]
    public float speed = 1f;
    public float distanceToStartAttack = 1f;
    public float attackDelay = 1.2f;
    public float postAttackDelay = 0.8f;
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public int numOfProjectiles = 5;
    public float projSpeed = 0.5f;
    public float delayBetweenProjectiles = 0.2f;
    public float amplitude = 1f;
    public float frequency = 10f;
    private bool isAttacking = false;

    public void Start() {
        this.player = GameObject.FindObjectOfType<PlayerHealth>().transform;
    }

    private IEnumerator LaunchProjectiles() {
        yield return new WaitForSeconds(attackDelay);

        Vector2 direction = (player.position - transform.position).normalized;
        for (int i = 0; i < numOfProjectiles; i++) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<BirjonProjectile>().Launch(
                direction, projSpeed, amplitude: amplitude, frequency: frequency
            );
            yield return new WaitForSeconds(delayBetweenProjectiles);
        }   
        yield return new WaitForSeconds(postAttackDelay);
    }
    
    private IEnumerator StartAttack() {
        isAttacking = true;
        yield return StartCoroutine(LaunchProjectiles());
        isAttacking = false;
    }

    void Update()
    {
        if (!player) return;
        if (isAttacking) return;
        
        Vector2 distanceVector = player.position - transform.position;
        transform.position += (Vector3) distanceVector.normalized * Time.deltaTime * speed;

        transform.rotation = Quaternion.Euler(0, distanceVector.x < 0 ? 0 : 180, 0);

        if (playerIsInAttackRange()) {
            StartCoroutine(StartAttack());
        }
    }


    private bool playerIsInAttackRange() {
        return Vector2.Distance(transform.position, player.position) < distanceToStartAttack;
    }
}
