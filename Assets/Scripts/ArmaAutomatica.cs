using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
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

        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque)
        {
            timer = 0;

            system.Play();

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
