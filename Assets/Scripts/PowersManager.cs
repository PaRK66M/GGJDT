using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour
{
    //Enemy stats
    public float enemyMoveSpeed = 6.0f;
    public float enemyJumpSpeed = 6.0f;
    public float enemyDamage = 3.0f;
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
    public PlayerMovement playerScript;

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
        availablePowers[1] = Random.Range(0, 2);
        availablePowers[2] = Random.Range(0, 2);

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
                playerScript.speed += 1;
                break;
            case 1:
                playerScript.jumpingPower += 1;
                break;
            case 2:
                playerScript.playerHealthMax += 1;
                playerScript.playerHealth += 1;
                break;
            case 3:
                playerScript.playerDamage += 1;
                break;
            case 4:
                playerScript.playerHealth = playerScript.playerHealthMax;
                break;
            case 5:
                if(enemyMoveSpeed > 1)
                {
                    enemyMoveSpeed -= 1;
                }
                break;
            case 6:
                if(enemyJumpSpeed > 1)
                {
                    enemyJumpSpeed -= 1;
                }
                break;
            case 7:
                if(enemyDamage > 1)
                {
                    enemyDamage -= 1;
                }
                break;
            case 8:
                if(enemyHealth > 1)
                {
                    enemyHealth -= 1;
                }
                break;
            case 9:
                attackDelayMax += 1;
                attackCooldownMax += 1;
                break;
            case 10:
                playerScript.speed -= 1;
                if(playerScript.speed < 1)
                {
                    playerScript.speed = 1;
                }
                enemyMoveSpeed -= 2;
                if(enemyMoveSpeed < 1)
                {
                    enemyMoveSpeed = 1;
                }
                break;
            case 11:
                playerScript.jumpingPower -= 1;
                if (playerScript.jumpingPower < 1)
                {
                    playerScript.jumpingPower = 1;
                }
                enemyJumpSpeed -= 2;
                if (enemyJumpSpeed < 1)
                {
                    enemyJumpSpeed = 1;
                }
                break;
            case 12:
                playerScript.playerHealthMax -= 1;
                if (playerScript.playerHealthMax < 1)
                {
                    playerScript.playerHealthMax = 1;
                }
                if (playerScript.playerHealth > playerScript.playerHealthMax)
                {
                    playerScript.playerHealth = playerScript.playerHealthMax;
                }
                enemyHealth -= 2;
                if (enemyHealth < 1)
                {
                    enemyHealth = 1;
                }
                break;
            case 13:
                playerScript.playerDamage -= 1;
                if (playerScript.playerDamage < 1)
                {
                    playerScript.playerDamage = 1;
                }
                enemyDamage -= 2;
                if (enemyDamage < 1)
                {
                    enemyDamage = 1;
                }
                break;
            case 14:
                playerScript.speed += 2;
                enemyMoveSpeed += 1;
                break;
            case 15:
                playerScript.jumpingPower += 2;
                enemyJumpSpeed += 1;
                break;
            case 16:
                playerScript.playerHealthMax += 2;
                enemyHealth += 1;
                break;
            case 17:
                playerScript.playerDamage += 2;
                enemyDamage += 1;
                break;
            case 18:
                playerScript.playerDamage += 4;
                playerScript.playerHealthMax -= 4;
                if(playerScript.playerHealthMax < 1)
                {
                    playerScript.playerHealthMax = 1;
                }
                if(playerScript.playerHealth > playerScript.playerHealthMax)
                {
                    playerScript.playerHealth = playerScript.playerHealthMax;
                }
                break;
            default:
                break;
        }
        displayPowers.SetActive(false);
        gameManagerScript.NewWave();
    }

}
