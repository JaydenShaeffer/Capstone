using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    public Animator animator;
    [SerializeField] private GameObject parent;

    [SerializeField]
    private float _maxHealth = 100;

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    [SerializeField]
    private float _health = 100;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;

            // If health drops below 0 character is no longer alive 
            if(_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    [SerializeField]
    public bool _isAlive = true;

    public bool IsAlive 
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
        }

    }    

    /*private void Awake()
    {
        animator = GetComponent<Animator>();
    }*/
   
   public void Hit(float damage)
   {
        if(IsAlive)
        {
            Health -= damage;
        }
   }
}
