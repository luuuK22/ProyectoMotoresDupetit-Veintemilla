using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    
    public float dmg = 10f;
    public float range = 100f;
    public Camera fpsCam; // FPS Integration

    public abstract void Shoot();
    public abstract void Reload();
}


