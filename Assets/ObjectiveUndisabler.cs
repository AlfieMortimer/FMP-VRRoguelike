using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUndisabler : MonoBehaviour
{
    GameObject levelManager;
    levelManager LM;

    public GameObject enemies;
    public GameObject spawners;
    public GameObject captureZone;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        print(levelManager);
        LM = levelManager.GetComponent<levelManager>();
        print(LM);
        print(LM.objectivetype);
        if (LM.objectivetype == 1)
        {
            spawners.SetActive(false);
            captureZone.SetActive(false);
        }
        if (LM.objectivetype == 2)
        {
            enemies.SetActive(false);
            captureZone.SetActive(false);
        }
        if (LM.objectivetype == 3)
        {
            enemies.SetActive(false);
            spawners.SetActive(false);
        }
    }
}
