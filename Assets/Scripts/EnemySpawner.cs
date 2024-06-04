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
        if (gameObject.activeInHierarchy && handler.enemyCount <= 30)
        {
            rand = Random.Range(0, 3);
            if (rand == 0)
            {
                Instantiate(mediumEnemy, spawnPos, Quaternion.identity);
                Instantiate(mediumEnemy, spawnPos, Quaternion.identity);
                handler.enemyCount += 2;
            }
            else if (rand == 1)
            {
                Instantiate(mediumEnemy, spawnPos, Quaternion.identity);
                Instantiate(mediumEnemy, spawnPos, Quaternion.identity);
                handler.enemyCount += 2;
            }
            else
            {
                Instantiate(largeEnemy, spawnPos, Quaternion.identity);

                handler.enemyCount += 1;
            }

            wait();
        }

    }
    void wait()
    {
        Invoke("spawnEnemy", 15f);
    }
    private void OnDestroy()
    {
        handler.spawnerCount -= 1;
    }
}
