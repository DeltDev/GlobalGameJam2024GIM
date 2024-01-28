using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WavePrefab {
    public GameObject prefab;
    public int weight;
}

public class WaveManager : MonoBehaviour
{   
    public Transform playerTr;
    public float firstWaveSpawnDelay = 3;
    public float idleBetweenWave = 5f;
    public float spawnDelayInWave = 1f;
    public AnimationCurve spawnAmountProgression;
    public WavePrefab[] wavePrefabs;

    private int waveNumber = 1;
    [SerializeField] private int startSpawningFasterAfterWave = 5;
    private int enemiesAlive = 0;
    private int totalWeightProbabilities; 
    [SerializeField] private float maxWaveSpawnDelay = 15f;
    private AudioManager audioManager;
    // Magic Timestamp
   Coroutine autoSpawnCoroutine = null;

    private void OnEnemyDeath() {
        enemiesAlive --;
        if (enemiesAlive == 0) StartNewWave();
    }

    private void Start() {
        totalWeightProbabilities = 0;
        foreach (WavePrefab wavePrefab in wavePrefabs)
        {
            totalWeightProbabilities += wavePrefab.weight;
        }
        StartCoroutine(StartFirstWave());
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private IEnumerator StartFirstWave() {
        yield return new WaitForSeconds(firstWaveSpawnDelay);
        StartNewWave();
    }

    public void StartNewWave()
    {
        StartCoroutine(SpawnWave());
    }
    
    public IEnumerator SpawnWave()
    {
        if (autoSpawnCoroutine != null) StopCoroutine(autoSpawnCoroutine);
        yield return new WaitForSeconds(idleBetweenWave);
        int spawnAmount = (int) spawnAmountProgression.Evaluate((float) waveNumber/startSpawningFasterAfterWave);
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject enemy = GetGameObjectFromWavePrefabs();
            GameObject instance = SpawnEnemy(enemy, GetRandomSpawnPosition());

            // terpaksa ga clean code gara" . . .
            EnemyHealth enemyHealth = instance.GetComponent<EnemyHealth>();
            if (enemyHealth == null)
                enemyHealth = instance.GetComponentInChildren<EnemyHealth>();

            if (enemyHealth != null)
                enemyHealth.OnDeath += OnEnemyDeath;

            enemiesAlive ++;
            yield return new WaitForSeconds(spawnDelayInWave);
        }
        waveNumber++;
        if (waveNumber > startSpawningFasterAfterWave) { 
            idleBetweenWave -= 0.2f; idleBetweenWave = Mathf.Clamp(idleBetweenWave, 1.2f, 100f);
            spawnDelayInWave -= 0.15f; spawnDelayInWave = Mathf.Clamp(spawnDelayInWave, 0.3f, 100f);
            maxWaveSpawnDelay -= 0.6f; maxWaveSpawnDelay = Mathf.Clamp(maxWaveSpawnDelay, 5f, 100f);
        }

        autoSpawnCoroutine = StartCoroutine(InitNextSpawn());
    }

    IEnumerator InitNextSpawn() {
        yield return new WaitForSeconds(maxWaveSpawnDelay);
        StartNewWave();
    }

    private GameObject SpawnEnemy(GameObject enemy, Vector2 position)
    {
        audioManager.PlaySound("EnemySpawn");
        return Instantiate(enemy, position, Quaternion.identity);
    }
    private GameObject GetGameObjectFromWavePrefabs()
    {
        int randomWeight = Random.Range(0, totalWeightProbabilities);
        int currentWeight = 0;
        foreach (WavePrefab wavePrefab in wavePrefabs)
        {
            currentWeight += wavePrefab.weight;
            if (randomWeight < currentWeight)
            {
                return wavePrefab.prefab;
            }
        }
        return null;
    }
    private Vector2 GetRandomSpawnPosition()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        float minX = boxCollider2D.bounds.min.x;
        float maxX = boxCollider2D.bounds.max.x;
        float minY = boxCollider2D.bounds.min.y;
        float maxY = boxCollider2D.bounds.max.y;

        Vector2 randomPosition;

        // Repeat until a position is found that is outside the specified radius from the player
        do
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            randomPosition = new Vector2(randomX, randomY);

            if (playerTr == null)
            {
                break;
            }

        } while (Vector2.Distance(randomPosition, playerTr.position) < 1.5f);

        return randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
