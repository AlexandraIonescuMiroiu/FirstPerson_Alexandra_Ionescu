using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private TMP_Text actualAmmoText;
    public ArmaSO misDatos;
    [SerializeField] ParticleSystem system;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && misDatos.balasCargador > 0)
        {
            system.Play(); //Ejecutar sistema particulas

            misDatos.balasCargador--;
            actualAmmoText.text = misDatos.balasCargador.ToString();
            Debug.Log("Disparo con " + misDatos.balasCargador + " balas.");

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
            {
                if (hitinfo.transform.CompareTag("EnemyPart"))
                {
                    Debug.Log(hitinfo.transform.name);
                    hitinfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);

                }

            }

        }
    }
}
