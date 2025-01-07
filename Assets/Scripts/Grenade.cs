using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private float radioExplosion;
    [SerializeField] private GameObject explosionPrefab;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (cam != null)
        {
            Vector3 direction = cam.transform.forward;
            rb.AddForce(direction * fuerzaImpulso, ForceMode.Impulse);
        }
    }

    void Update()
    {
        tiempoVida -= Time.deltaTime;

        if (tiempoVida < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, queEsDanhable);

        if (collsDetectados.Length > 0)
        {
            foreach (Collider coll in collsDetectados)
            {
                EnemyPart enemyPart = coll.GetComponent<EnemyPart>();
                if (enemyPart != null)
                {
                    enemyPart.Explotar();
                }

                Rigidbody rb = coll.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(50, transform.position, radioExplosion, 3.5f, ForceMode.Impulse);
                }
            }
        }
    }
}
