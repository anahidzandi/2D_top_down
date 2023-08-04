using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;

    public Animator animator;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Play hurt Animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            animator.SetBool("IsDead", false);
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        isDead = true;

        //Play die Animation
        animator.SetBool("IsDead", true);

        //Diasble enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
