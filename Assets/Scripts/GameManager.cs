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

    //UI
    public GameObject defeatScreen;
    public TMPro.TextMeshProUGUI waveNumberDisplay;
    public TMPro.TextMeshProUGUI defeatTextDisplay;

    //Variables
    public bool displayingPowers = false;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        waveNumberDisplay.text = waveNumber.ToString();
        NewWave();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesAlive);
        if(enemiesAlive <= 0)
        {
            Debug.Log("Showing Powers");
            if (!displayingPowers)
            {
                powersManager.ShowPowers();
                displayingPowers = true;
            }
        }
    }

    public void GameOver()
    {
        defeatTextDisplay.text = waveNumber.ToString();
        defeatScreen.SetActive(true);
    }

    public void NewWave()
    {
        waveNumber++;
        enemiesAlive = waveNumber;
        waveNumberDisplay.text = waveNumber.ToString();
        spawner.NewWave(waveNumber);
        displayingPowers = false;
    }
}
