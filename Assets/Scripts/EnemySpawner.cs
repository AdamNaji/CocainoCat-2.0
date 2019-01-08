using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public enum SpawnState
    {
        SPAWNING,
        WAITING // State that the spawner is between wave spawining.
    };

    [System.Serializable]public class Wave
    {
        public GameObject enemyPrefab;
        public int amountOfEnemies;
        public float spawnEnemyEveryXSeconds;
    }
    

    
    // Serialized variables
    [SerializeField] Wave[] waves = null;
    [SerializeField] float timeBeforeNextWave = 4.0f;

    // Private variables
    int currentWaveID = 0;
    SpawnState state = SpawnState.WAITING;
    float defaultTimeBetweenWaves; 
   

 // fait spawn les enemies selon le nombre indiquer
    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < wave.amountOfEnemies; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.spawnEnemyEveryXSeconds);
        }
        currentWaveID++;
        timeBeforeNextWave = defaultTimeBetweenWaves;
        state = SpawnState.WAITING;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }

    
    void Start()
    {
        defaultTimeBetweenWaves = timeBeforeNextWave;
    }
    void Update()
    {
        if (timeBeforeNextWave <= 0) // If it's time to start a wave, start spawining.
        {
            if (state != SpawnState.SPAWNING)
            {
                if (currentWaveID <= waves.Length-1)
                {
                    StartCoroutine(SpawnWave(waves[currentWaveID]));
                }
            }
        }
        else
        {
            timeBeforeNextWave -= Time.deltaTime; // Else, count down.
        }
    }
    
    
}