using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - LUCA VEINTEMILLA

public class CloseEnemy : Enemy
{

  
    public float stopDistance = 1.5f;

    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.position) > stopDistance)
        {
            FollowPlayer();
        }

        
        if (Vector3.Distance(transform.position, player.position) <= stopDistance + 0.5f)
        {
            player.GetComponent<IDamageable>().TakeDamage(10);
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}




