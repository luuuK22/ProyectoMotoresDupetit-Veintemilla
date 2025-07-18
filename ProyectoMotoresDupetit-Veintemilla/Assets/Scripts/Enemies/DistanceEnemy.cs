using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : Enemy
{
 
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootCooldown = 2f;
    private float shootTimer;

    void Update()
    {
        FollowPlayer();
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCooldown)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = (player.position - shootPoint.position).normalized * 10f;
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}


