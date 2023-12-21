using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField] private GameObject parent;
    public int maxHealth = 100;
    public int currentHealth;
    private DropKey dropKey;
    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    float adjustedVolume = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        dropKey = GetComponent<DropKey>(); // Get the DropKey script
    }

    public void Destroy()
    {
        Destroy(parent);
    }

    private void DeathSound()
    {
        SoundManager.instance.PlaySound(deathSound, adjustedVolume);
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
        // Call the DropKeyOnDeath method to drop the key
        dropKey.DropKeyOnDeath();
    }

    IEnumerator DieFr()
    {
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
    }
}
