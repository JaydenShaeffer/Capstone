using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public GameObject projectile;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.FindWithTag("EnemyProjectile");
        // Calculate the direction based on the projectile's scale
        Vector2 direction = new Vector2(transform.localScale.x, 0);

        // Set the velocity based on the direction and speed
        rb.velocity = direction.normalized * moveSpeed;

        // Destroy the projectile after 3 seconds
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectile = GameObject.FindWithTag("EnemyProjectile");
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log($"Enemy hit for {damage}");
            Destroy(gameObject); // Destroy the projectile on collision
        }
        if(projectile != null)
        {
            Destroy(gameObject);
        }
    }
}
