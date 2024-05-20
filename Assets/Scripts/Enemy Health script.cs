using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthscript : MonoBehaviour
{
    public float health;
    public float damage;
    enemyHandler handler;
    levelManager LM;
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
            if(LM.objectivetype == 1)
            {
                handler.enemyCount--;
            }
            //in future play animation which will edit level objectives and then kill itself
            Destroy(gameObject);
        }
    }


}
