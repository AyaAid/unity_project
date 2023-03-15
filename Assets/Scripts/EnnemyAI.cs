using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAI : MonoBehaviour
{

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;


    public Transform target;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        // Find the player character
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;

            // Set the destination for the enemy's navmesh agent to the player's position
            agent.destination = player.transform.position;
        }
    }
}