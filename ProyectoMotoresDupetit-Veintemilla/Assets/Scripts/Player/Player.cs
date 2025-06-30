using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//TP2 - LUCA VEINTEMILLA

public class Player : MonoBehaviour, IDamageable
{

    [SerializeField] private float _life = 100f;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerWeapon _playerWeapons;



    public void TakeDamage(float dmg)
    {
        _life -= dmg;
        if (_life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}




