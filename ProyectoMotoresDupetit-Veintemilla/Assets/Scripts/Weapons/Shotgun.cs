using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - MATEO DUPETIT

public class Shotgun : Weapons
{
    public int pellets = 6;
    public float spread = 0.05f;

    public override void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            Vector3 direction = fpsCam.transform.forward;
            direction += new Vector3(
                Random.Range(-spread, spread),
                Random.Range(-spread, spread),
                0
            );

            if (Physics.Raycast(fpsCam.transform.position, direction, out RaycastHit hit, range))
            {
                IDamageable target = hit.collider.GetComponent<IDamageable>();
                if (target != null)
                    target.TakeDamage(dmg);
            }
        }
    }

    public override void Reload()
    {
        Debug.Log("Reloading Shotgun...");
    }
}


