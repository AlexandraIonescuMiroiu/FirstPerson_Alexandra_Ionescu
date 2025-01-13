using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform transformPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerIsGoingToUse;


    void Update()
    {
        DetectarJugador();
    }

    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(transformPoint.position, radius, layerIsGoingToUse);

        // Draw the sphere in the editor for visualization in green
        Debug.DrawRay(transformPoint.position, Vector3.up * radius, Color.green);

        if (collsDetectados.Length > 0)
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                if (collsDetectados[i].tag == "Player")
                {
                    weaponManager.RefillAllAmmo();
                    Debug.Log("Colisiono con: Player");
                }
            }
        }
    }
}
