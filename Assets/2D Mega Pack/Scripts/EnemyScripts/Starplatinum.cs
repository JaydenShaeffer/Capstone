using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starplatinum : MonoBehaviour
{
    [Header("Attack Sound")]
    [SerializeField] private AudioClip attackSound;
    float adjustedVolume = 5.5f;

    private Animator anim;

    public float attackInterval = 60f; // Time between attacks in seconds
    public float freezeDuration = 2f; // Duration of the freeze in seconds

    public static bool isPlayerFrozen = false;
    public float attackTimer = 0f;

     // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTimer = attackInterval;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        // Check if it's time for the enemy to attack and not on cooldown
        if (!isPlayerFrozen && attackTimer <= 0)
        {
            Attack();
            Debug.Log("this isnt going to work dummy");
            attackTimer = attackInterval; // Reset the attack timer
        }

        // Check if the player is frozen
        if (isPlayerFrozen)
        {
            // If frozen, reduce the freeze duration and prevent player movement
            freezeDuration -= Time.deltaTime;

            if (freezeDuration <= 0f)
            {
                // If freeze duration is over, allow the player to move again
                isPlayerFrozen = false;
                // Reset freeze duration for the next attack
                freezeDuration = 2f;
            }
            else
            {
                // If still frozen, you can add visual effects or feedback here
                Debug.Log("Player is frozen!");
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("starPlatinum");
        isPlayerFrozen = true;
    }

    private void AttackAudioSP()
    {
        SoundManager.instance.PlaySound(attackSound);
    }
}
