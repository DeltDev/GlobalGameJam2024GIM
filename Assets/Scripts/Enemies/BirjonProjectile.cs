using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirjonProjectile : MonoBehaviour
{

    private bool isLaunched = false; 
    private Vector2 direction;
    private Vector2 perpendicularDirection;
    private float projSpeed;
    private float amplitude;
    private float frequency;
    private float startTime;

    public void Launch(Vector2 direction, float projSpeed = 0.5f, float amplitude = 0.5f, float frequency = 1f) {
        this.direction = direction.normalized;
        this.perpendicularDirection = new Vector2(-direction.y, direction.x);
        this.projSpeed = projSpeed;
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.startTime = Time.time;
        isLaunched = true;
    }

    void Update()
    {
        if (!isLaunched) return;
        transform.position += (Vector3) direction * Time.deltaTime * projSpeed;

        float timeElapsed = Time.time - startTime;
        float yOffSet = Mathf.Sin(timeElapsed * frequency) * amplitude;
        transform.position += (Vector3) perpendicularDirection * yOffSet * Time.deltaTime;        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        if (other.CompareTag("Player")) {
            // other.GetComponent<PlayerController>().TakeDamage(1);
            // Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
