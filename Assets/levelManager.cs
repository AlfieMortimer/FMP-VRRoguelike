using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    enemyHandler eH;

    public GameObject player;
    public Vector3 playerCoord;

    public float level;
    public float objectivetype;
    public float Difficulty;


    public GameObject captureZone;
    public captureZone zone;
    //Value 0 is base for home
    //Objective 1 = Kill all enemies
    //Objective 2 = Destroy all spawners
    //Objective 3 = Capture the zone

    public static levelManager instance;

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("dont destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "LevelBreakRoom" && eH == null)
        {
            levelLoaded();
        }

        if (objectivetype == 3 && zone == null)
        {
            captureZone = GameObject.FindGameObjectWithTag("capture");
            if (captureZone)
            {
                print(captureZone);
                zone = captureZone.GetComponent<captureZone>();
            }
            
        }

        if (SceneManager.GetActiveScene().name != "LevelBreakRoom")
        {
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
        
    }
    private void levelLoaded()
    {
        player = GameObject.FindWithTag("Player");
        GameObject handlerOBJ = GameObject.FindWithTag("Handler");
        if(handlerOBJ != null)
        {
            eH = handlerOBJ.GetComponent<enemyHandler>();

        }
        player.transform.position = playerCoord;

    }
    private void levelComplete()
    {
        level++;
        //Play win animation before load scene
        SceneManager.LoadScene("LevelBreakRoom");
        objectivetype = 0;
        eH = null;
    }
    public void LevelLoad()
    {
        if(level == 1)
        {
            SceneManager.LoadScene("Test 1");
        }
        if (level == 2)
        {
            SceneManager.LoadScene("Test 2");
        }
        if (level == 3)
        {
            SceneManager.LoadScene("Test 3");
        }
        if (level == 4)
        {
            SceneManager.LoadScene("Test 4");
        }
        if (level == 5)
        {
            SceneManager.LoadScene("Test 5");
        }
        else if(level >= 6 || level <= 0)
        {
            SceneManager.LoadScene("LevelBreakRoom");
        }


    }
}
