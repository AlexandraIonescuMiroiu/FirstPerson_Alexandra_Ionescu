using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    // Singelton
    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private GameObject currentWeapon;

    [Header("Weapons")]
    public GameObject weapon1;
    public GameObject weapon2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(weapon1, weapon2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(weapon2, weapon1);
        }
    }

    void SwitchWeapon(GameObject weaponToActivate, GameObject weaponToDeactivate)
    {
        SetWeaponActive(weaponToActivate, true);
        SetWeaponActive(weaponToDeactivate, false);
    }

    void SetWeaponActive(GameObject weapon, bool isActive)
    {
        if (weapon != null)
        {
            currentWeapon = weapon;
            weapon.SetActive(isActive);
        }
    }
}
