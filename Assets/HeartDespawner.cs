using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDespawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float DespawnTime;
    [SerializeField] private GameObject SmokeParticle;
    private ParticleSystem SmokeVFX;
    private AudioManager audioManager;
    void Start()
    {
        StartCoroutine(DespawnHeart(DespawnTime));
        SmokeVFX = SmokeParticle.GetComponent<ParticleSystem>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    IEnumerator DespawnHeart(float DespawnTime)
    {
        yield return new WaitForSeconds(DespawnTime);
        audioManager.PlaySound("EnemySpawn");
        SmokeVFX.Play();
        SmokeParticle.transform.position = transform.position;
        SmokeParticle.transform.parent = null;
        
        Destroy(this.gameObject);
    }
}