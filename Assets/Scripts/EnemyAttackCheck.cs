using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    public Collider2D attackRadius;
    public EnemyMovement eMScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Can attack");
            eMScript.canAttack = true;
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
