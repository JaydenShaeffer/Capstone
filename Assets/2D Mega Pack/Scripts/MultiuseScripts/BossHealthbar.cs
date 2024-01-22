using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField] private GameObject parent;
    public int maxHealth = 100;
    public int currentHealth;
    private DropKey dropKey;
    public HealthBar healthBar;

    [Header("Spawn Sound")]
    [SerializeField] private AudioClip spawnSound;
    float adjustedVolume = 1.0f;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        dropKey = GetComponent<DropKey>(); // Get the DropKey script
        
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Destroy()
    {
        Destroy(parent);
    }

    // Update is called once per frame
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

    private void SpawnAudio()
    {
        SoundManager.instance.PlaySound(spawnSound);
    }

    private void DeathAudio()
    {
        SoundManager.instance.PlaySound(deathSound);
    }
}
