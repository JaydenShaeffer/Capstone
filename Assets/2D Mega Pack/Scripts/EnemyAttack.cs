using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int closeCombatDamage = 25; // Adjust the value as needed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
           PlayerHP playerHealth = other.GetComponent<PlayerHP>();
            if (playerHealth != null)
            {
                // Call the TakeDamage method to damage the player
                playerHealth.TakeDamage(closeCombatDamage);
            }
        }
    }
}
