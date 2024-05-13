using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public float level;
    enemyHandler eH;
    public int objectivetype;
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
        }
        //Debug remove after working


        if (objectivetype == 1 && eH.enemyCount <= 0)
        {
            level++;
            //Play win animation before load scene
            SceneManager.LoadScene("Tower");
        }
        if (objectivetype == 2 && eH.spawnerCount <= 0)
        {
            level++;
            //Play win animation before load scene
            SceneManager.LoadScene("Tower");
        }
        if (objectivetype == 3 && eH.captureTimer <= 0)
        {
            level++;
            //Play win animation before load scene
            SceneManager.LoadScene("Tower");
        }
    }
    private void levelLoaded()
    {
        GameObject handlerOBJ = GameObject.FindWithTag("Handler");
        print(handlerOBJ);
        eH = handlerOBJ.GetComponent<enemyHandler>();
    }
}
