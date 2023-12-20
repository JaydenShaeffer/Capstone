using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDMG = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    // See if it can be hit
    if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        BossHealthbar bossHP = collision.GetComponent<BossHealthbar>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackDMG);
            Debug.Log($"Enemy hit for {attackDMG}");
        }
        else if (bossHP != null)
        {
            bossHP.TakeDamage(attackDMG);
            Debug.Log($"Enemy hit for {attackDMG}");
        }
    }
}

}
