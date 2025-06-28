using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float life = 100f;
    [SerializeField] private float currentLife;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerWeapon playerWeapon;

    private void Start()
    {
        currentLife = life;
    }

    private void Update()
    {
        
    }

    public void TakeDmg(float dmg)
    {
        currentLife -= dmg;
        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Jugador muerto");
    }
}
