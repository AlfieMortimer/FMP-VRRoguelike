using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class enemyPathfinding : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    bool inRange;
    Rigidbody rb;
    public Animator animator;

    bool canmove = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Invoke("startdelay", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            chasePlayer();
        }
        inRange = Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance;
    }

    void chasePlayer()
    {
        if (inRange)
        {
            Vector3 targetPostition = new Vector3(player.transform.position.x,
            this.transform.position.y,
            player.transform.position.z);
            this.transform.LookAt(targetPostition);
            agent.velocity = Vector3.zero;
            rb.velocity = new Vector3(0, 0, 0);

            //animator.SetTrigger("Attack");
        }
        agent.SetDestination(player.transform.position);
        
    }

    void startdelay()
    {
        canmove = true;
    }
}
