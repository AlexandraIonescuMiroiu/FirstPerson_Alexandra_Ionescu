using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ArmaSO misDatos;
    [SerializeField] ParticleSystem system;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        system.Play(); //Ejecutar sistema particulas

    //        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
    //        {
    //            if (hitinfo.transform.CompareTag("ParteEnemigo"))
    //            {
    //                Debug.Log(hitinfo.transform.name);
    //                hitinfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);

    //            }
               
    //        }

    //    }
    //}
}
