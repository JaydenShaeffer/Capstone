using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died!");
        anim.SetTrigger("death");

        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
    }*/

    public void ExternalTakeDamage(int damage)
    {
        // Call the private TakeDamage method
        TakeDamage(damage);
    }
}
