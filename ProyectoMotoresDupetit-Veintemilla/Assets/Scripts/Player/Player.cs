using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Idamageable
{

    [SerializeField] private float _life = 100f;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerWeapon _playerWeapons;



    public void TakeDamage(float dmg)
    {
        _life -= dmg;
        if (_life <= 0)
        {
            Debug.Log("Player died!");
        }
    }
}




