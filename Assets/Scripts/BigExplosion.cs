using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour
{
    [SerializeField] private float tiempoVida;

    void Update()
    {
        tiempoVida -= Time.deltaTime;

        if (tiempoVida < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
