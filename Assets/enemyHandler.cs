using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHandler : MonoBehaviour
{
    public float enemyCount;
    public GameObject[] enemies;

    public float spawnerCount;
    public GameObject[] spawners;

    public float captureTimer;
    public float captureArea;
    public GameObject[] captureZone;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        captureZone = GameObject.FindGameObjectsWithTag("capture");
        foreach (GameObject enemy in enemies)
        {
            enemyCount++;
        }
        foreach (GameObject spawners in spawners)
        {
            spawnerCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
