using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            weaponManager.RefillAllAmmo();
            Debug.Log("Colisiono con: Player");
        }
    }
}
