using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthAmount = 25;  // Adjust this value as needed
    [Header("Heal Sound")]
    [SerializeField] private AudioClip healSound;
    float adjustedVolume = 5.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHealth = other.GetComponent<PlayerHP>();

            // Check if the player's health is not already at the maximum
                if (playerHealth.currentHealth < playerHealth.maxHealth)
                {
                    SoundManager.instance.PlaySound(healSound, adjustedVolume);
                    playerHealth.Heal(healthAmount);
                    Destroy(gameObject);  // Destroy the health pack when collected
                  
                }
                else
                {
                    // Player is already at max health, do not pick up health packs
                    Debug.Log("Your already max hp loser");
                }
        }
    }
}
