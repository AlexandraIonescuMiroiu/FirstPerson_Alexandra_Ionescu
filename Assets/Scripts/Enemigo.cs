using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private bool danhoRealizado = false;
    [SerializeField] private float danhoAtaque;
    private NavMeshAgent agent;
    [SerializeField] private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<FirstPerson>();

        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Perseguir();
        if (ventanaAbierta &&  danhoRealizado ==false)
        {
            DetectarJugador();
        }

    }

    private void DetectarJugador()
    {
       Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
        if(collsDetectados.Length > 0)
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
               
            }
            danhoRealizado = true;
        }

    }

    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;

        }
        else
        {
            agent.isStopped = false;
            anim.SetBool("attacking", true);
        }
    }

    #region Eventos de animacion
    //Evento de animacion
    private void FinAtaque()
    {
        //hacer evento fin ataque y ponerle la condicion
        agent.isStopped= false;
        anim.SetBool("attacking", false);
        danhoRealizado = false;

    }
    private void AbrirVentanaAtaque()
    {
        //abrir ventana ataque y cerrarla

        ventanaAbierta = true;

    }
    private void CerrarVentanaAtaque()
    {

        ventanaAbierta=false;

    }
    #endregion



}
