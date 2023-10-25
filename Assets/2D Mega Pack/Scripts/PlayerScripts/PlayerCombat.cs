using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    
    public ProjectileSpawner projectileSpawner;

    public AudioSource audioSource;
    public AudioClip audioClip;  
    private bool isAirAttacking = false;
    private PlayerMovement playerMovement; // Reference to your PlayerMovement script

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        playerMovement = GetComponent<PlayerMovement>(); // Assign the reference to the PlayerMovement script
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            if (playerMovement.IsJumping == true && !isAirAttacking)
            {
                AirAttack();
            }
            else
            {
                GroundAttack();
            }
            
        }

         if (Input.GetKeyDown(KeyCode.H))
        {
            OnRangedAttack();
        }
        
    }
    
    void AirAttack()
    {
        animator.SetTrigger("AirAttack");
    }

    void GroundAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void OnRangedAttack()
    {
        animator.SetTrigger("rangedAttack");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

