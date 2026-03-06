using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP FINAL - MATEO DUPETIT

public class PowerRun : PowerUps
{
    public float speedMultiplier = 2f;

    protected override void ApplyPowerUp(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.StartCoroutine(movement.SpeedBoost(speedMultiplier, duration));
    }
}
