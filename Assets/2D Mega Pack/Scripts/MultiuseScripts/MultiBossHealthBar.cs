using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBossHealthBar : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject[] enemies; // Array to hold the two enemies
    public int maxHealth = 600;
    public int currentHealth;
    private DropKey dropKey;
    public HealthBar healthBar;

    [Header("Spawn Sound")]
    [SerializeField] private AudioClip spawnSound;
    float adjustedVolume = 1.0f;


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
         // Check if any of the enemies are still alive
        if (currentHealth <= 0 && !IsAnyEnemyAlive())
        {
            Die();
        }
    }


     bool IsAnyEnemyAlive()
     {
        foreach (GameObject enemy in enemies)
        {
            BossHealthbar enemyHealth = enemy.GetComponent<BossHealthbar>();
            if (enemyHealth != null && enemyHealth.currentHealth > 0)
            {
                return true;
            }
        }
        return false;
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

}
