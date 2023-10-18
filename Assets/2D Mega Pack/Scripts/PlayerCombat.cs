using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    
    public ProjectileSpawner projectileSpawner;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public AudioSource audioSource;
    public AudioClip audioClip;  
    public int attackDamage = 40;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }

         if (Input.GetKeyDown(KeyCode.H))
        {
            OnRangedAttack();
        }
    }

    void Attack()
    {
    animator.SetTrigger("Attack");

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach (Collider2D enemy in hitEnemies)
    {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(attackDamage);
        }
        else
        {
            Debug.Log("Enemy component not found on " + enemy.name);
        }
    }
    }

    public void OnRangedAttack()
    {
        animator.SetTrigger("rangedAttack");
        audioSource.clip = audioClip;
        audioSource.Play();
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
