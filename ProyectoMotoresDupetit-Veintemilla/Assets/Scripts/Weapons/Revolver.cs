using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapons
{
    public override void Shoot()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Idamageable target = hit.collider.GetComponent<Idamageable>();
            if (target != null)
                target.TakeDamage(dmg);
        }
    }

    public override void Reload()
    {
        Debug.Log("Reloading Revolver...");
    }
}


