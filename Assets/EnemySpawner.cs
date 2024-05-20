using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enemyHandler handler;
    public GameObject spawnPosOBJ;
    public GameObject smallEnemy;
    public GameObject mediumEnemy;
    public GameObject largeEnemy;
    public Vector3 spawnPos;

    public int rand;
    // Start is called before the first frame update
    void Start()
    {
        GameObject handlerOBJ = GameObject.FindWithTag("Handler");
        handler = handlerOBJ.GetComponent<enemyHandler>();
        spawnPos = spawnPosOBJ.transform.position;
        wait();
    }

    void spawnEnemy()
    {
        if (gameObject.activeInHierarchy)
        {
            rand = Random.Range(0, 3);
            if (rand == 0)
            {
                Instantiate(smallEnemy, spawnPos, Quaternion.identity);
                Instantiate(smallEnemy, spawnPos, Quaternion.identity);
                Instantiate(smallEnemy, spawnPos, Quaternion.identity);
                Instantiate(smallEnemy, spawnPos, Quaternion.identity);
                Instantiate(smallEnemy, spawnPos, Quaternion.identity);
                print("Small Spawned");
                handler.enemyCount += 5;
            }
            else if (rand == 1)
            {
                print("Medium spawned");
                handler.enemyCount += 2;
            }
            else
            {
                Instantiate(largeEnemy, spawnPos, Quaternion.identity);
                print("Large Spawned");
                handler.enemyCount += 1;
            }

            wait();
        }

    }
    void wait()
    {
        Invoke("spawnEnemy", 15f);
    }
}
