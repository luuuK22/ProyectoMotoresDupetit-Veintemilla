using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP FINAL - MATEO DUPETIT
public abstract class PowerUps : MonoBehaviour
{
    public enum PowerUpType
    {
        Speed,
        Jump,
     
    }

    public struct PowerUpData
    {
        public PowerUpType Type;
        public float Duration;
        public string Name;
    }

    public float duration = 5f;

    protected abstract void ApplyPowerUp(GameObject player);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            
        }
    }
}
