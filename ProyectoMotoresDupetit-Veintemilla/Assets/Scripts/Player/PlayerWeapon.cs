using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - LUCA VEINTEMILLA

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private int _actualWeapon;
    [SerializeField] private List<Weapons> weapons = new List<Weapons>();

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            WeaponShoot();

        if (Input.GetKeyDown(KeyCode.R))
            Reload();

        ChangeWeapon();
    }

    public void WeaponShoot()
    {
        weapons[_actualWeapon].Shoot();
    }

    public void Reload()
    {
        weapons[_actualWeapon].Reload();
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.Count >= 1)
        {
            _actualWeapon = 0;
            ActivateWeapon(_actualWeapon);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Count >= 2)
        {
            _actualWeapon = 1;
            ActivateWeapon(_actualWeapon);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Count >= 3)
        {
            _actualWeapon = 2;
            ActivateWeapon(_actualWeapon);
        }

        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            _actualWeapon = (_actualWeapon + 1) % weapons.Count;
            ActivateWeapon(_actualWeapon);
        }
        else if (scroll < 0f)
        {
            _actualWeapon = (_actualWeapon - 1 + weapons.Count) % weapons.Count;
            ActivateWeapon(_actualWeapon);
        }
    }

    private void ActivateWeapon(int indexToActivate)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].gameObject.SetActive(i == indexToActivate);
            }
        }
    }

}


