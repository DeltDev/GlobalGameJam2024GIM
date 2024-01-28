using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawner : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_particleSystem.isPlaying && transform.parent == null)
        {
            Destroy(this.gameObject);
        }
    }
}
