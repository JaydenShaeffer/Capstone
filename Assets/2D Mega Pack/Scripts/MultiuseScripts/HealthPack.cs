using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthAmount = 25;  // Adjust this value as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHealth = other.GetComponent<PlayerHP>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount);
                Destroy(gameObject);  // Destroy the health pack when collected
            }
        }
    }
}
