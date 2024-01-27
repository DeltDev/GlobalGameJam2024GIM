using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private float HeartSpawnXMinimum;
    [SerializeField] private float HeartSpawnXMaximum;
    [SerializeField] private float HeartSpawnYMinimum;
    [SerializeField] private float HeartSpawnYMaximum;
    [SerializeField] private GameObject Heart;
    [SerializeField] private int MaximumSpawnChanceRange;
    private Vector2 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHearts());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject SpawnHeart(GameObject heart, Vector2 RandomPosition)
    {
        return Instantiate(heart, RandomPosition, Quaternion.identity);
    }

    private Vector2 getRandomPosition()
    {
        float randomX = Random.Range(HeartSpawnXMinimum, HeartSpawnXMaximum);
        float randomY = Random.Range(HeartSpawnYMinimum, HeartSpawnYMaximum);

        randomPosition = new Vector2(randomX, randomY);
        return randomPosition;
    }

    IEnumerator SpawnHearts()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int rand = Random.Range(1,MaximumSpawnChanceRange);
            Debug.Log(rand);
            if(rand == 1)
            {
                SpawnHeart(Heart, getRandomPosition());
            }
        }
        
    }

}
