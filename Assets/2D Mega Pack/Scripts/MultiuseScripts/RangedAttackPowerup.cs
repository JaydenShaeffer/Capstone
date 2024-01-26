/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackPowerup : MonoBehaviour
{

    private Sprite originalSprite;
    private bool isPoweredUp = false;
    private float powerUpDuration = 10f;
    private float timer;

    private void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPoweredUp)
        {
            // Buff ranged attack damage
            other.GetComponent<ProjectileSpawner>().BuffDamage();

            // Change sprite
            GetComponent<SpriteRenderer>().sprite = poweredUpSprite;

            // Start timer
            isPoweredUp = true;
        }
    }

    private void Update()
    {
        if (isPoweredUp)
        {
            // Update timer
            timer += Time.deltaTime;

            // Check if power-up duration has elapsed
            if (timer >= powerUpDuration)
            {
                // Revert changes
                RevertChanges();
            }
        }
    }

    private void RevertChanges()
    {
        // Revert ranged attack damage
        GetComponent<ProjectileSpawner>().RevertDamage();

        // Revert sprite
        GetComponent<SpriteRenderer>().sprite = originalSprite;

        // Reset variables
        isPoweredUp = false;
        timer = 0f;
    }
}
*/