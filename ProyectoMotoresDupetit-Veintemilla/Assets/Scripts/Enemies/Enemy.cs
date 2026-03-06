using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - LUCA VEINTEMILLA
public abstract class Enemy : MonoBehaviour, IDamageable
{
  
    public float life;
    public float speed;

    
   
    public delegate void EnemyDamaged(float currentLife);
    public event EnemyDamaged OnEnemyDamaged;

   
    public delegate void EnemyDied();
    public event EnemyDied OnEnemyDied;
    
    public Player player;


    public void TakeDamage(float dmg)
    {
        life -= dmg;

      
        OnEnemyDamaged?.Invoke(life);

        if (life <= 0)
        {
            Die();

        
            OnEnemyDied?.Invoke();
        }
    }

    protected virtual void FollowPlayer()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerRef;
            if (player == null) return; // Evita errores si sigue sin existir
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Start()
    {
        player = GameManager.Instance.PlayerRef;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.PlayerRef;
        }
        // Aquí puedes llamar a FollowPlayer() si lo necesitas
    }

    protected abstract void Die();



   
}


