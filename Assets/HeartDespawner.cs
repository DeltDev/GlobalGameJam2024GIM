using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDespawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float DespawnTime;
    void Start()
    {
        StartCoroutine(DespawnHeart(DespawnTime));
    }

    // Update is called once per frame
    IEnumerator DespawnHeart(float DespawnTime)
    {
        yield return new WaitForSeconds(DespawnTime);
        Destroy(this.gameObject);
    }
}