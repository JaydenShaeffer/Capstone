using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    public GameObject keyPrefab; // Reference to the Key prefab
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Call this method to drop the key when the enemy dies
    public void DropKeyOnDeath()
    {
        if (keyPrefab != null)
        {
            Instantiate(keyPrefab, transform.position, Quaternion.identity);
            // Optionally, you can add more logic related to dropping the key here
        }
    }
}