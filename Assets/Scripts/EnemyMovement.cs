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
    public bool communicatedAttack = true;
    public float deathCounter = 10.0f;

    //Jumping
    public float jumping = 0;

    //Player
    public Transform player;
    private Vector2 targetPosition = Vector2.zero;

    //Components
    public Rigidbody2D enemyRb;
    public GameObject attackRadius;
    public EnemyAttackCheck attackScript;
    public GameManager gameManager;
    public PowersManager powersManager;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        powersManager = GameObject.Find("PowersManager").GetComponent<PowersManager>();
        InitialiseStats();
        attackDelay = attackDelayMax;
    }

    private void InitialiseStats()
    {
        //Stats
        float enemyMoveSpeed = powersManager.enemyMoveSpeed;
        float enemyJumpSpeed = powersManager.enemyJumpSpeed;
        float enemyDamage = powersManager.enemyDamage;
        float enemyHealth = powersManager.enemyHealth;
        float attackDelayMax = powersManager.attackDelayMax;
        float attackCooldownMax = powersManager.attackCooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TakeDamage(5);
        }

        if (!communicatedAttack)
        {
            if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "EnemyAttack")
            {
                attackScript.isAttacking = false;
                anim.SetBool("Attacking", false);
                communicatedAttack = true;
            }
        }

        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyIdle")
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("Damaged", false);
        }
        

        if (!canAttack && (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyIdle" || anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyMovement"))
        {
            targetPosition = new Vector2(player.position.x, player.position.y);

            if (transform.position.x < targetPosition.x)
            {
                anim.SetBool("Moving", true);
                direction = 1.0f;
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 180, 0, 0));
            }
            else if (transform.position.x > targetPosition.x)
            {
                anim.SetBool("Moving", true);
                direction = -1.0f;
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                anim.SetBool("Moving", false);
                direction = 0.0f;
            }
        }
        else if(canAttack && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "EnemyDeath" && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "EnemyAttack")
        {
            anim.SetBool("Moving", false);
            direction = 0.0f;
            if (attackDelay > 0)
            {
                attackDelay -= 1;
                anim.SetBool("Attacking", false);
            }
            else if (attackCooldown > 0)
            {
                attackCooldown -= 1;
                anim.SetBool("Attacking", false);
            }
            else
            {
                Attack();
                communicatedAttack = false;
                attackCooldown = attackCooldownMax;
            }
        }
        else if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyDeath")
        {
            direction = 0.0f;
            deathCounter -= 1;
            if(deathCounter <= 0)
            {
                Destroy(gameObject);
            }
            
        }
        
    }

    private void FixedUpdate()
    {
        enemyRb.MovePosition(new Vector2(enemyRb.position.x + enemyMoveSpeed * Time.fixedDeltaTime * direction, enemyRb.position.y + enemyJumpSpeed * Time.fixedDeltaTime * jumping));
    }

    private void Attack()
    {
        attackScript.Attack(enemyDamage);
        anim.SetBool("Attacking", true);
    }

    public void ResetAttackDelay()
    {
        attackDelay = attackDelayMax;
    }

    public void TakeDamage(float damage)
    {
        direction = 0.0f;
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            gameManager.enemiesAlive--;
            anim.SetBool("Dead", true);
        }
        else
        {
            anim.SetBool("Damaged", true);
        }
    }

  
}
