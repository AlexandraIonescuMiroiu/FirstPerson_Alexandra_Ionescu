using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bazoca : MonoBehaviour
{
    [SerializeField] private TMP_Text actualAmmoText;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform spawnPoint;
    public ArmaSO misDatos;
    private float timer;

    void Start()
    {
        timer = misDatos.cadenciaAtaque;
    }

    void Update()
    {
        if (this.gameObject.activeSelf == false)
        {
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= misDatos.cadenciaAtaque && misDatos.balasCargador > 0)
        {
            misDatos.balasCargador--;
            actualAmmoText.text = misDatos.balasCargador.ToString();
            Debug.Log("Disparo con " + misDatos.balasCargador + " balas.");
            Disparar();
            timer = 0;
        }
    }

    void Disparar()
    {
        Instantiate(grenadePrefab, spawnPoint.position, this.transform.rotation);
    }
}
