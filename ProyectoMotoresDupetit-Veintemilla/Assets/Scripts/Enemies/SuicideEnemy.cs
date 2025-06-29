using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : Enemy
{
 
    public float explosionRadius = 3f;
    public float explosionDamage = 50f;

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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in hitColliders)
        {
            Idamageable target = col.GetComponent<Idamageable>();
            if (target != null)
                target.TakeDamage(explosionDamage);
        }
        Destroy(gameObject);
    }

    protected override void Die()
    {
        Explode();
    }
}


