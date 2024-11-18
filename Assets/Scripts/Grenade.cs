using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private float radioExplosion;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private GameObject explosionPrefab;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaImpulso);
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnDestroy()
    {
        Instantiate(explosionPrefab,transform.position, Quaternion.identity);

        Debug.Log("Me voy de este mundo :(");
        

        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, queEsDanhable);

        if(collsDetectados.Lenght > 0)
        {
            foreach (Collider coll in collsDetectados)
            {
                coll.GetComponent<ParteDeEnemigo>().Explotar();
                coll.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, radioExplosion, 3.5f);
               
            }
        }
        


    }
}
