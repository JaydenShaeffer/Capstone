using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behavior : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks 
    public float closeCombatDistance; // Minimum distance for close combat attack
    public float rangedAttackDistance; // Minimum distance for ranged attack
    public int closeCombatDamage = 35; // Adjust the value as needed
    public LayerMask playerLayerMask;
     // Add references to your close and ranged attack prefabs or other assets
    // public GameObject closeCombatAttackPrefab; Not needed not using a prefab for the attack
    public GameObject rangedAttackPrefab;
    //public Transform attackPoint;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; //Check if Player is in range
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    private bool canAttackCloseCombat = true;
    private bool canAttackRanged = true;
    #endregion

    void Awake()
    {
        intTimer = timer; //Store the inital value of timer 
        anim = GetComponent<Animator>();
        playerLayerMask = LayerMask.GetMask("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        //When Player is detected 
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log($"enenmy logic distance:{distance}");
        if (distance > closeCombatDistance)
        {
            Move();
            StopAttack();
        }
        else if (distance <= closeCombatDistance && cooling == false)
        {
            if (canAttackCloseCombat)
            {
                AttackCloseCombat();
            }
        }
        else if (distance <= rangedAttackDistance && cooling == false)
        {
            if (canAttackRanged)
            {
                AttackRanged();
            }
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("CopyX_RushAttack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void AttackCloseCombat()
{
    timer = intTimer; // Reset Timer when Player enters Attack Range
    attackMode = true; // To check if the Enemy can still attack or not

    anim.SetBool("canWalk", false);
    anim.SetBool("Attack", true);
    anim.SetBool("IsCloseCombat", true);
    anim.SetBool("IsRangedAttack", false);

    // Get the hitbox collider component of the child GameObject (hitbox)
    Collider2D[] hitboxColliders = GetComponentsInChildren<Collider2D>();

    // Create a ContactFilter2D to filter collisions with the player's layer
    ContactFilter2D contactFilter = new ContactFilter2D();
    contactFilter.SetLayerMask(playerLayerMask);

    // List to store collision results
    List<Collider2D> hitColliders = new List<Collider2D>();

    // Loop through each hitbox collider
    foreach (Collider2D hitboxCollider in hitboxColliders)
    {
        // Detect collisions using OverlapCollider and the ContactFilter2D
        hitboxCollider.OverlapCollider(contactFilter, hitColliders);

        // Check if the target (player) is within the attack range
        // Loop through the hitColliders and apply damage to the player if detected
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Implement damage logic here
                // Assuming you have a reference to the player's GameObject with the PlayerHP script
                PlayerHP playerHP = collider.GetComponent<PlayerHP>();
                if (playerHP != null)
                {
                    playerHP.ExternalTakeDamage(closeCombatDamage);
                    Debug.Log($"Player Hit for {closeCombatDamage}");
                }
            }
        }
    }
    
    canAttackCloseCombat = false; // Set to false to prevent continuous attacks
}


     void AttackRanged()
    {
        timer = intTimer; // Reset Timer when Player enters Attack Range
        attackMode = true; // To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
        anim.SetBool("IsRangedAttack", true);
        anim.SetBool("IsCloseCombat", false);

        // Instantiate and configure your ranged attack prefab here
        // Example:
        // Instantiate(rangedAttackPrefab, attackPoint.position, Quaternion.identity);

        canAttackRanged = false; // Set to false to prevent continuous attacks
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;

            // Reset attack flags to allow attacks again
            canAttackCloseCombat = true;
            canAttackRanged = true;
        }
    }
    public void CloseCombatAttackAnimationFinished()
    {
    anim.SetBool("IsCloseCombat", false);
    anim.SetBool("Attack", false);
    // Additional logic if needed
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
             Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
