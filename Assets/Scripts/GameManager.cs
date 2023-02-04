using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Waves
    public int waveNumber;
    public int enemiesAlive;

    //GameObjects
    public EnemySpawnManager spawner;
    public PowersManager powersManager;

    //Variables
    public bool newWaveSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        NewWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive <= 0)
        {
            

        }
    }

    public void NewWave()
    {
        waveNumber++;
        enemiesAlive = waveNumber;
        spawner.NewWave(waveNumber);
        newWaveSpawn = false;
    }
}
