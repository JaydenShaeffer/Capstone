using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   // public Sprite originalSprite;
  //  public Sprite poweredUpSprite;
    public static int damage = 25;
    public static int powerDamage = 50;
    public static int defaultDMG = 25;
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public GameObject projectile;
    Rigidbody2D rb;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip poweredupAttackSound;

    public AudioSource audioSource;
  //  public AudioClip audioClip;  

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(ItemCollector.isPoweredUp == true)
        {
            SoundManager.instance.PlaySound(poweredupAttackSound);
        }
        if(ItemCollector.isPoweredUp == false)
        {
            SoundManager.instance.PlaySound(attackSound);
        }
       
        //audioSource.clip = audioClip;
       // audioSource.Play();
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
        if (collision.CompareTag("HealthPack") || collision.CompareTag("Z") || collision.CompareTag("Door") || collision.CompareTag("Powerup") || collision.CompareTag("ShieldPowerup"))
        {
            return;
        }
        projectile = GameObject.FindWithTag("EnemyProjectile");
        Enemy enemy = collision.GetComponent<Enemy>();
        BossHealthbar bossHP = collision.GetComponent<BossHealthbar>();
        MultiBossHealthBarHealthBar multibossHP = collision.GetComponent<MultiBossHealthBarHealthBar>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            //bossHP.TakeDamage(damage);
            Debug.Log($"Enemy hit for {damage}");
            Destroy(gameObject); // Destroy the projectile on collision
        }
        else if (bossHP != null)
        {
            bossHP.TakeDamage(damage);
            Debug.Log($"Enemy hit for {damage}");
            Destroy(gameObject); // Destroy the projectile on collision
        }
        else if (multibossHP != null)
        {
            multibossHP.TakeDamage(damage);
            Debug.Log($"Enemy hit for {damage}");
            Destroy(gameObject); // Destroy the projectile on collision
        }
        if(projectile != null)
        {
            Destroy(gameObject);
        }
    }
}