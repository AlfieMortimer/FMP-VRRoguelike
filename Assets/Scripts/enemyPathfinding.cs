using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPathfinding : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("playerTargetPos");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }

    void chasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
