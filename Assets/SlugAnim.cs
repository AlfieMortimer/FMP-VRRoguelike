using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SlugAnim : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Rigidbody rb;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= 0.5f)
        {
            anim.SetBool("Idle", true);
            //Look At Player
            anim.SetTrigger("Attack");
        }
        else
        {
            anim.SetBool("Idle", false);
        }
    }
}
