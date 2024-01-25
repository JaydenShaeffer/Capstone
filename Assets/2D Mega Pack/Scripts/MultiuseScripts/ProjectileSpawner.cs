using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;
    public Sprite poweredUpSprite; // Reference to the powered-up sprite

    private float originalDamage; // Store the original damage for reverting after power-up
    private bool isPoweredUp = false;
    private float powerUpDuration = 10f; // Duration of the power-up in seconds
    private float timer;

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
                RevertDamage();
            }
        }
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        // Flip the projectile's facing direction and movement based on the direction the character is facing at time of launch
        projectile.transform.localScale = new Vector3( origScale.x * transform.localScale.x > 0 ? 1 : -1, origScale.y, origScale.z);

       // Apply damage based on power-up state
        float damage = isPoweredUp ? originalDamage * 2f : originalDamage;
        
        // Convert the damage to an integer before setting it
        projectile.GetComponent<Projectile>().SetDamage(Mathf.RoundToInt(damage));
    }

     public void BuffDamage()
    {
        // Store the original damage
        originalDamage = projectilePrefab.GetComponent<Projectile>().GetDamage();

         // Double the damage during power-up
        projectilePrefab.GetComponent<Projectile>().SetDamage(Mathf.RoundToInt(originalDamage * 2f));

        // Change sprite during power-up
        GetComponent<SpriteRenderer>().sprite = poweredUpSprite;

        isPoweredUp = true;
    }

    public void RevertDamage()
    {
        // Revert to the original damage
        projectilePrefab.GetComponent<Projectile>().SetDamage(originalDamage);


        isPoweredUp = false;
    }
}