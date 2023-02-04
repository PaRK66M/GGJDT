using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Stats
    public float enemyMoveSpeed = 5.0f;
    public float enemyJumpSpeed = 5.0f;
    public float enemyDamage = 2.0f;
    public float enemyHealth = 10.0f;
    private float attackDelayMax = 25.0f;
    private float attackCooldownMax = 25.0f;

    //Movement
    public float direction = 0.0f;
    private float attackDelay;
    private float attackCooldown = 0;

    //Attacking
    public bool canAttack = false;

    //Player
    public Transform player;
    private Vector2 targetPosition = Vector2.zero;

    //Components
    public Rigidbody2D enemyRb;
    public GameObject attackRadius;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(player == null)
        {
            Debug.Log("Can't find player");
        }
        attackDelay = attackDelayMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TakeDamage(5);
        }

        if (!canAttack)
        {
            targetPosition = new Vector2(player.position.x, player.position.y);

            if (transform.position.x < targetPosition.x)
            {
                direction = 1.0f;
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
            }
            else if (transform.position.x > targetPosition.x)
            {
                direction = -1.0f;
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 180, 0, 0));
            }
            else
            {
                direction = 0.0f;
            }
        }
        else
        {
            direction = 0.0f;
            if (attackDelay > 0)
            {
                attackDelay -= 1;
            }
            else if (attackCooldown > 0)
            {
                attackCooldown -= 1;
            }
            else
            {
                Attack();
                attackCooldown = attackCooldownMax;
            }
        }
        
    }

    private void FixedUpdate()
    {
        enemyRb.MovePosition(new Vector2(enemyRb.position.x + enemyMoveSpeed * Time.fixedDeltaTime * direction, enemyRb.position.y));
    }

    private void Attack()
    {
        Debug.Log("ATTACK");
    }

    public void ResetAttackDelay()
    {
        attackDelay = attackDelayMax;
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }
}
