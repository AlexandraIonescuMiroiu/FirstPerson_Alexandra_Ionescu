using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private TMP_Text actualAmmoText;
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    public ArmaSO misDatos;
    private float timer;

    void Start()
    {
        cam = Camera.main;
        timer = misDatos.cadenciaAtaque;
    }

    void Update()
    {
        if (this.gameObject.activeSelf == false)
        {
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque && misDatos.balasCargador > 0)
        {
            timer = 0;

            system.Play();

            misDatos.balasCargador--;
            actualAmmoText.text = misDatos.balasCargador.ToString();
            Debug.Log("Disparo con " + misDatos.balasCargador + " balas.");

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitinfo.transform.name);

                if (hitinfo.transform.CompareTag("EnemyPart"))
                {
                    hitinfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }
            }
        }
    }
}
