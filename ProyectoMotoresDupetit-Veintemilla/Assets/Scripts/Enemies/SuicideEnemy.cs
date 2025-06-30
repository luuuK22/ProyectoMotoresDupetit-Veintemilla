using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : Enemy
{
 
    public float explosionRadius = 3f;
    public float explosionDamage = 50f;
    private bool hasExploded = false;

    void Update()
    {
        FollowPlayer();
        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            Explode();
        }
    }

    

    void Explode()
    {
        if (hasExploded)
            return;
        hasExploded = true;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in hitColliders)
        {
            IDamageable target = col.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(30);
        }
        Destroy(gameObject);
    }
    protected override void Die()
    {
        Explode();
    }
}


