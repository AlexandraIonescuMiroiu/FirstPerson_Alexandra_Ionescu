using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{


    private NavMeshAgent agent;
    [SerializeField] private FirstPerson player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<FirstPerson>();
        
    }

    
    void Update()
    {
        agent.SetDestination(player.transform.position);
        

    }
}
