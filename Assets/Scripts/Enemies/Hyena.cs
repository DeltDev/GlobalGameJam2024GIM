using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : MonoBehaviour
{
    [Header("Hyena Settings")]
    public float speed = 1f;
    public float rotationSpeed = 10f;
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public float projectileTick = 2f;
    public float projectileSpeed = 10f;

    private Vector2 currentDirection;

    private void Start() {
        // randomize direction
        currentDirection = Random.insideUnitCircle.normalized;
        StartCoroutine(LaunchProjectile());  
    }

    IEnumerator LaunchProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(projectileTick);
            Vector2 perpendicular = Vector2.Perpendicular(transform.up).normalized;
            
            // projectile left
            GameObject projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile1.GetComponent<Rigidbody2D>().velocity = -perpendicular * projectileSpeed;

            // projectile right
            GameObject projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile2.GetComponent<Rigidbody2D>().velocity = perpendicular * projectileSpeed;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)currentDirection * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 
            Mathf.Sign(currentDirection.x) * rotationSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Wall")) {
            currentDirection = Vector2.Reflect(currentDirection, other.transform.up);
        }
    }
}
