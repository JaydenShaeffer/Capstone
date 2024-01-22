using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunProjectile : EnemyAttack
{   [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private BoxCollider2D coll;

    private PlayerMovement player;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null && !PlayerMovement.isStunned)
            {
                PlayerMovement.isStunned = true;
            }
        }

        else if (collision.CompareTag("HealthPack") || collision.CompareTag("Z") || collision.CompareTag("Enemy") || collision.CompareTag("Door"))
    {
        // Projectile goes through health pack and object with "Z" tag, no damage
        //base.OnTriggerEnter2D(collision); // Execute logic from the parent script first
        //coll.enabled = true;
        gameObject.SetActive(true); // When this hits any object, deactivate arrow
        return;
    }
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        coll.enabled = false;
        gameObject.SetActive(false); //When this hits any object deactivate arrow
    }

    


   /* IEnumerator StunPlayer(PlayerMovement player)
    {
        // Stun duration, you can adjust this value
        float stunDuration = 0.5f;

        // Set player to stunned state
        player.isStunned = true;

        // Trigger stun effect (e.g., disable player movement)
        // Add your own code for disabling movement, you might need to modify your Player script
        // Example: player.DisableMovement();

        // Wait for the stun duration
        yield return new WaitForSeconds(stunDuration);

        // Reset player state after stun duration
        player.isStunned = false;

        // Trigger any necessary reset or re-enable movement
        // Example: player.EnableMovement();
    }
    */
}