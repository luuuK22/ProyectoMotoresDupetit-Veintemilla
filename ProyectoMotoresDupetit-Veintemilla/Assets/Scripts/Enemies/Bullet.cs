using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - LUCA VEINTEMILLA

public class Bullet : MonoBehaviour
{

    public float damage = 20f;
    public float lifetime = 5f;

    void Start()
    {
       
        Destroy(gameObject, lifetime);
    }

 
    void OnTriggerEnter(Collider other)
    {
        
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

     
        Destroy(gameObject);
    }
}


