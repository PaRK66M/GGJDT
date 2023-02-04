using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour
{
    //Scripts
    public EnemyMovement enemyStats;

    //Enemy stats
    public float enemyMoveSpeed = 5.0f;
    public float enemyJumpSpeed = 5.0f;
    public float enemyDamage = 2.0f;
    public float enemyHealth = 10.0f;
    public float attackDelayMax = 25.0f;
    public float attackCooldownMax = 25.0f;

    //Variables
    public bool choosingPower = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choosingPower)
        {

        }
    }


}
