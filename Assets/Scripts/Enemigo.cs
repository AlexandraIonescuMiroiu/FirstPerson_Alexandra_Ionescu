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
    private bool ventanaAbierta = true;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    private Rigidbody[] huesos;

    [SerializeField] private float vidas;

    [SerializeField] private float timeBetweenAtacks = 1f;
    private float timeNextAttack = 0f;
    public float Vidas { get => vidas; set => vidas = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }
        CambiarEstadoHuesos(true);

    }

    void Update()
    {
        Perseguir();

        if (ventanaAbierta)
        {
            DetectarJugador();
        }
    }

    private void DetectarJugador()
    {
        if (Time.time >= timeNextAttack)
        {
            Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
            if (collsDetectados.Length > 0)
            {
                for (int i = 0; i < collsDetectados.Length; i++)
                {
                    if (collsDetectados[i].tag == "Player")
                    {
                        collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
                        Debug.Log("Danho realizado: " + danhoAtaque);
                    }
                    timeNextAttack = Time.time + timeBetweenAtacks;
                }
                danhoRealizado = true;
            }
        }
    }

    private void Perseguir()
    {
        if (player == null || agent == null || !agent.isOnNavMesh)
        {
            return;
        }

        // Solo realiza la persecución si el agente está en un NavMesh
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("Attack", true);
            EnfocarPlayer();
        }
    }

    private void EnfocarPlayer()
    {
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;
        direccionAPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }

    #region Eventos de animacion
    private void FinAtaque()
    {
        agent.isStopped = false;
        anim.SetBool("Attack", false);
        danhoRealizado = false;
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }

    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
    #endregion

    public void Morir()
    {
        CambiarEstadoHuesos(false);
        agent.enabled = false;
        anim.enabled = false;
        Debug.Log("Muerto");
        Destroy(gameObject, 5);
        GameManager.Instance.enemiesDead++;
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
}
