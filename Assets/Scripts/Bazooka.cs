using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoca : MonoBehaviour
{
    // Referencias
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cadenciaDisparo = 2.5f;
    private float timer;

    void Start()
    {
        timer = cadenciaDisparo;
    }

    void Update()
    {
        if (this.gameObject.activeSelf == false)
        {
            return;
        }

        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer >= cadenciaDisparo)
        {
            Disparar();
            timer = 0;
        }
    }

    void Disparar()
    {
        Instantiate(grenadePrefab, spawnPoint.position, this.transform.rotation);
    }
}
