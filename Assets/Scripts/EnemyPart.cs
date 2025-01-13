using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPart : MonoBehaviour
{

    [SerializeField] private Enemigo enemyObject;
    [SerializeField] private float multiplicadorDanho;

    public void RecibirDanho(float danhoRecibido)
    {
        Debug.Log("Enemy Life: " + enemyObject.Vidas);
        enemyObject.Vidas -= (danhoRecibido * multiplicadorDanho);
        if (enemyObject.Vidas <= 0)
        {
            enemyObject.Morir();
        }
    }

    public void Explotar()
    {
        enemyObject.GetComponent<Animator>().enabled = false;
        enemyObject.GetComponent<NavMeshAgent>().enabled = false;
        enemyObject.enabled = false;
    }
}
