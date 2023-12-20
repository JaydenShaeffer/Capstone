using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    
    public ProjectileSpawner projectileSpawner;

//   public AudioSource audioSource;
  //  public AudioClip audioClip;  
    private bool isAirAttacking = false;
    private PlayerMovement playerMovement; // Reference to your PlayerMovement script
    [Header("Attack Sounds")]
    [SerializeField] private AudioClip attackSound1;
    [SerializeField] private AudioClip attackSound2;
    [SerializeField] private AudioClip attackSound3;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>(); 
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
            if (playerMovement.IsJumping == false)
            {
                OnRangedAttack();
            }
        }
        
    }

    private void MeleeSound1()
    {
        SoundManager.instance.PlaySound(attackSound1);
    }

    private void MeleeSound2()
    {
        SoundManager.instance.PlaySound(attackSound2);
    }

    private void MeleeSound3()
    {
        SoundManager.instance.PlaySound(attackSound3);
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
      
    }
}

