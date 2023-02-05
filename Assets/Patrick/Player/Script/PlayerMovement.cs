using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 18f;
    private bool isFacingRight = true;
    public float playerHealthMax = 10.0f;
    public float playerHealth = 10.0f;
    public float playerDamage = 5.0f;

    bool ifAlive = true;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Transform attackPoint;
    public float attackRange = 0.65f;
    public LayerMask enemyLayers;

    public GameManager thatManager;

    public healthBar healthThing;

    void Start()
    {
        healthThing.SetMaxHealth(playerHealth);
    }
    void Update()
    {
        if(ifAlive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("runSpeed", Mathf.Abs(horizontal));

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
            Flip();
            if(playerHealth<=0)
            {
                ifAlive = false;
            }
            healthThing.SetHealth(playerHealth);
        }

        if(!ifAlive)
        {
            animator.SetBool("isDied", true);
            thatManager.GameOver();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void Attack()
    {
        //play an attack animation
        animator.SetTrigger("Attack");
        //detect enemies in range of attack

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.gameObject.GetComponent<EnemyMovement>().TakeDamage(playerDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
