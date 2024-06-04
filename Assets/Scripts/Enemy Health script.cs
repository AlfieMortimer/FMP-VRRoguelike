using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyHealthscript : MonoBehaviour
{
    public float health;
    public float damage;
    public enemyHandler handler;
    levelManager LM;
    bool dead = false;
    public bool type;
    // Start is called before the first frame update
    void Start()
    {
        handler = GameObject.FindWithTag("Handler").GetComponent<enemyHandler>();
        LM = GameObject.FindWithTag("LevelManager").GetComponent<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(dead == false)
            {
                if (type)
                {
                    handler.enemyCount--;
                    dead = true;
                }
                else
                {
                    dead = true;
                    handler.spawnerCount --;

                }
                
            }

            Invoke("Death", 0.25f);
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }


}
