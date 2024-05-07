using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPathfinding : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    bool inRange;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("playerTargetPos");
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
        inRange = Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance;
    }

    void chasePlayer()
    {
        if (inRange)
        {
            agent.velocity = Vector3.zero;
            rb.velocity = new Vector3(0, 0, 0);
        }
        agent.SetDestination(player.transform.position);
        
    }
}
