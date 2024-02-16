using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyAttack
{   [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private BoxCollider2D coll;

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
        if (collision.CompareTag("HealthPack") || collision.CompareTag("Z") || collision.CompareTag("Enemy") || collision.CompareTag("Door") || collision.CompareTag("Powerup") || collision.CompareTag("ShieldPowerup") || collision.CompareTag("EnemyProjectile"))
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
    
}