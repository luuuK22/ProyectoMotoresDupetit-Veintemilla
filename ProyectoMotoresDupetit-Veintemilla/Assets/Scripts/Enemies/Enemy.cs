using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, Idamageable
{
    public float life;
    public float speed;
    [SerializeField] public Transform player;

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        if (life <= 0) Die();
    }

    protected virtual void FollowPlayer()
    {
        if (player == null) player = GameObject.FindWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    protected abstract void Die();
}
  
    

