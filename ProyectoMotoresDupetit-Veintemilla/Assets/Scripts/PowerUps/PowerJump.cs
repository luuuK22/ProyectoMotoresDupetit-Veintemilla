using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP FINAL - MATEO DUPETIT
public class PowerJump : PowerUps
{
    public float jumpMultiplier = 2f;

    protected override void ApplyPowerUp(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.StartCoroutine(movement.JumpBoost(jumpMultiplier, duration));
    }
}
