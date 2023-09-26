using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField] private GameObject parent;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
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
        Debug.Log("Enemy Died!");
        StartCoroutine(DieFr());

        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
    }

    IEnumerator DieFr()
    {
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
        Destroy(parent);
    }
}
