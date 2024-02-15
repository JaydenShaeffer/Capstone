using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public bool shield;
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    public Enemy_behavior enemy_Behavior;
    public HealthBar healthBar;
    private PlayerMovement PlayerMovement;
    public string deathScene;
    public bool injured = false;
    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    [Header("Heal Sound")]
    [SerializeField] private AudioClip healSound;

    [Header("Injured Sound")]
    [SerializeField] private AudioClip injuredSound;
    float adjustedVolume = 5.5f;

    public bool isDead = false; // Flag to track whether the player has already died

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP(); // Continuously check HP
    }

    public void TakeDamage(int damage)
    {   
        if (!isDead && shield == true) // Check if the player is already dead
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        
        else if (!isDead && shield == false) // Check if the player is already dead
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    void CheckHP()
    {
        // Check if HP is below 50%
        if (currentHealth <= maxHealth * 0.55f && !injured)
        {
            injured = true;
            // Set the animator parameter to trigger the injured idle animation
            anim.SetBool("isInjured", true);
            SoundManager.instance.PlaySound(injuredSound, adjustedVolume);
        }
        if(currentHealth >= maxHealth * 0.55f)
        {
            injured = false;
            // Set the animator parameter to normal idle animation
            anim.SetBool("isInjured", false);
        }
    }
    void Die()
    {
        if (!isDead)
        {
            isDead = true; // Set the flag to true to indicate that the player has died
            Debug.Log("You Died!");
            StartCoroutine(DieOng(2.5f));
        }
    }

    IEnumerator DieOng(float waitDuration)
    {
        anim.SetTrigger("death");
        if (PlayerMovement != null)
        {
            PlayerMovement.enabled = false;
        }
        yield return new WaitForSeconds(waitDuration);
        SceneManager.LoadScene(deathScene);
    }

    public void Heal(int amount)
    {
        // Check if the player's current health is not already at the maximum
        if (currentHealth < maxHealth)
        {
            
            currentHealth += amount;

            // Ensure that healing doesn't exceed the maximum health
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetHealth(currentHealth);
        }
        else
        {
            // Player is already at max health, do not pick up health packs
            Debug.Log("Already at max health, cannot pick up health packs.");
        }
    }

    public void InjuredSound()
    {
        SoundManager.instance.PlaySound(injuredSound, adjustedVolume);
    }
}
