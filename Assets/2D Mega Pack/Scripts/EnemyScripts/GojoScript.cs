using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GojoScript : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack Sound")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip domainSound;
    float adjustedVolume = 5.5f;

    public bool noMove = false;
    public static bool domainExpansion;
    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;
    private BossHealthbar bossHP;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        bossHP = GetComponent<BossHealthbar>();
    }

    private void Update()
    {
        if (bossHP.currentHealth <= 100 && !domainExpansion)
        {
            noMove = true;
            enemyPatrol.enabled = false;
            domainExpansion = true;
            anim.SetTrigger("domainExpansion");
        }
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
               
            }
        }

       // if (enemyPatrol != null)
        //   enemyPatrol.enabled = !PlayerInSight();
    }

    private void Reset()
    {
        Debug.Log(" - jeff");
        domainExpansion = false;
    }

    private void DomainTeleport()
    {
        SceneManager.LoadScene("GojoDomain");
    }


    private void DomainAudio()
    {
        SoundManager.instance.PlaySound(domainSound, adjustedVolume);
    }

    private void AttackAudio()
    {
        SoundManager.instance.PlaySound(attackSound);
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
