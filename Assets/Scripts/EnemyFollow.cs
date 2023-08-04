using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public float followRange; // The range within which the enemy starts following the player
    Animator am;
    SpriteRenderer spriteRenderer; // Reference to the sprite renderer component
    EnemyHealth enemyHealth; // Reference to the EnemyHealth script

    public int amount;
    void Start()
    {
        am = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (enemyHealth.IsDead()) // Check if the enemy is dead
        {
            am.SetBool("Move", false);
            return; // Exit the Update method early if the enemy is dead
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= followRange && distanceToPlayer > minimumDistance)
        {
            am.SetBool("Move", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Flip the enemy sprite based on movement direction
            if (target.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true; // Face left
            }
            else
            {
                spriteRenderer.flipX = false; // Face right
            }
        }
        else
        {
            am.SetBool("Move", false);
        }

        if (distanceToPlayer <= minimumDistance)
        {
            //am.SetTrigger("Attack");
            // Attack code
            PlayerMovement controller = target.GetComponent<PlayerMovement>();
            controller.ChangeHealth(-amount);
        }
    }
}
