using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    public Enemy_behavior enemy_Behavior;
    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died!");
        StartCoroutine(DieOng());
        //anim.SetTrigger("death");
        //yield return new WaitForSeconds(1);
       // Destroy(gameObject);

        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
    }

     IEnumerator DieOng()
    {
        anim.SetTrigger("death");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        //Destroy(parent);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
    }*/

    //public void ExternalTakeDamage(int damage)
    //{
        // Call the private TakeDamage method
    //    TakeDamage(damage);
   // }


   // Handle collisions with enemy attack colliders
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            // Get the damage value from the enemy's attack collider
            int closeCombatDamage = other.GetComponentInChildren<BoxCollider2D>().GetComponent<EnemyAttack>().closeCombatDamage;

            // Call the TakeDamage method to apply the damage
            TakeDamage(closeCombatDamage);
        }
    }
}
