using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour
{
    //Enemy stats
    public float enemyMoveSpeed = 5.0f;
    public float enemyJumpSpeed = 5.0f;
    public float enemyDamage = 2.0f;
    public float enemyHealth = 10.0f;
    public float attackDelayMax = 25.0f;
    public float attackCooldownMax = 25.0f;

    //Powers
    public int[] availablePowers;
    public string[] powersDescription;

    //UI
    public GameObject displayPowers;
    public TMPro.TextMeshProUGUI[] textBox;

    //Game Objects
    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPowers()
    {
        availablePowers[0] = Random.Range(0, 2);
        do
        {
            availablePowers[1] = Random.Range(0, 2);
        } while (availablePowers[1] != availablePowers[0]);
        do
        {
            availablePowers[2] = Random.Range(0, 2);
        } while (availablePowers[2] != availablePowers[0] && availablePowers[2] != availablePowers[1]);

        for(int i = 0; i < 3; i++)
        {
            textBox[i].text = powersDescription[availablePowers[i]];
        }
        displayPowers.SetActive(true);
    }

    public void SelectPower(int choice)
    {
        switch (availablePowers[choice])
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
        displayPowers.SetActive(false);
        gameManagerScript.NewWave();
    }

}
