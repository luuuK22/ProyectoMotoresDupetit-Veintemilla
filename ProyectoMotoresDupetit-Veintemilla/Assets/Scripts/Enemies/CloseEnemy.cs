using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemy : Enemy
{

    void Update()
    {
        FollowPlayer();
        if (Vector3.Distance(transform.position, player.position) < 2f)
            player.GetComponent<Idamageable>().TakeDamage(10);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}


