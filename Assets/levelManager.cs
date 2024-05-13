using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public float level;
    enemyHandler eH;
    public int objectivetype;

    public GameObject captureZone;
    public captureZone zone;
    //Value 0 is base for home
    //Objective 1 = Kill all enemies
    //Objective 2 = Destroy all spawners
    //Objective 3 = Capture the zone

    void Update()
    {
        //Debug Remove after working
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            levelLoaded();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            objectivetype = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            objectivetype = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            objectivetype = 3;
            captureZone = GameObject.FindGameObjectWithTag("capture");
            zone = captureZone.GetComponent<captureZone>();
        }
        //Debug remove after working


        if (objectivetype == 1 && eH.enemyCount <= 0)
        {
            levelComplete();
        }
        if (objectivetype == 2 && eH.spawnerCount <= 0)
        {
            levelComplete();
        }
        if (objectivetype == 3 && zone.timer <= 0)
        {
            levelComplete();
        }
    }
    private void levelLoaded()
    {
        GameObject handlerOBJ = GameObject.FindWithTag("Handler");
        print(handlerOBJ);
        eH = handlerOBJ.GetComponent<enemyHandler>();
    }
    private void levelComplete()
    {
        level++;
        //Play win animation before load scene
        SceneManager.LoadScene("Tower");
        objectivetype = 0;
    }
}
