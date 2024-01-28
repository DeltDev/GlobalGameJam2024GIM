using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyenaProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        } else if (other.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
