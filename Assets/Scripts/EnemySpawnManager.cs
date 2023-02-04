using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //Enemy types
    public GameObject[] enemies;

    //Spawn points
    public GameObject[] spawnPoints;

    //Waves
    public int waveNumber = 0;
    public int enemiesSpawned = 0;

    //Delay
    private float spawnDelayMax = 200;
    private float spawnDelay;

    //Checks
    public bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if (spawnDelay > 0)
            {
                spawnDelay -= 1;
            }
            else
            {
                SpawnEnemy();
                spawnDelay = spawnDelayMax;
                enemiesSpawned++;
                if(enemiesSpawned == waveNumber)
                {
                    spawning = false;
                }
            }
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemies[0], spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
    }

    public void NewWave(int newWaveNumber)
    {
        waveNumber = newWaveNumber;
        enemiesSpawned = 0;
        spawning = true;
    }
}
