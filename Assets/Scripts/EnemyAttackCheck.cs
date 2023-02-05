using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public Collider2D attackRadius;
    public EnemyMovement eMScript;

    public bool isAttacking = false;
    public float damage = 0;

    private void Update()
    {
        
    }

    public void Attack(float currentDamage)
    {
        isAttacking = true;
        damage = currentDamage;
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eMScript.canAttack = true;
            if (isAttacking)
            {
                collision.gameObject.GetComponent<PlayerMovement>().playerHealth -= damage;
                isAttacking = false;
            }
        }
        else if (collision.gameObject.tag == "JumpZone")
        {
            eMScript.jumping = 1;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eMScript.canAttack = false;
            eMScript.ResetAttackDelay();
        }
        else if (collision.gameObject.tag == "JumpZone")
        {
            eMScript.jumping = 0;
        }
    }
}
