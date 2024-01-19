using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    [Header("Enemy")]
    [SerializeField] private Transform enemy;


    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;


    [Header("Header Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;


    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header("Player Detection")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionDistance;

    private void Awake()
    {
        initScale = enemy.localScale;
    }


    private void OnDisable()
    {
        if (anim != null)
        {
            anim.SetBool("moving", false);
        }
    }


    private void Update()
    {
        CheckPlayerHit();

        if(leftEdge != null && rightEdge != null && enemy != null)
        {
            if(movingLeft)
            {
                if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
        }
    }

    private void CheckPlayerHit()
    {
        if (player != null && enemy != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, enemy.position);

            // Check if player is behind the enemy within the detection distance
            if (distanceToPlayer < detectionDistance && Mathf.Sign(player.position.x - enemy.position.x) != Mathf.Sign(enemy.localScale.x))
            {
                // Player hit from behind, turn around
                movingLeft = !movingLeft;
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);


        idleTimer += Time.deltaTime;


        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);


        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize detection distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.position, detectionDistance);
    }
    
}



