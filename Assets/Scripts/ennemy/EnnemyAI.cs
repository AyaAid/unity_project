using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyAI : MonoBehaviour
{

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    private UnityEvent m_OnTouch;

    [SerializeField]
    private int TaDistanceQueTuConsidèreAssezPetite = 3;


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
    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Ghoul");
        

        if (Vector3.Distance(player.transform.position, enemy.transform.position) < TaDistanceQueTuConsidèreAssezPetite)
            //Debug.Log("touché");
            m_OnTouch.Invoke();
     }
}