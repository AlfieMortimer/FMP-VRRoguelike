using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public AudioClip Victory;
    public AudioClip LVLM1;
    public AudioClip LVLM2;
    public AudioClip LVLM3;


    enemyHandler eH;

    public soundManager soundManager;

    public GameObject player;
    public Vector3 playerCoord;

    public float level;
    public float objectivetype;
    public float Difficulty;

    public GameObject floornum;
    public float floorsClear;

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
        if (SceneManager.GetActiveScene().name != "LevelBreakRoom" && eH == null)
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
        if (handlerOBJ != null)
        {
            eH = handlerOBJ.GetComponent<enemyHandler>();

        }
        player.transform.position = playerCoord;
        TextMeshPro numTextBox = floornum.GetComponent<TextMeshPro>();
        numTextBox.text = ("Floor: " + floorsClear);
    }
    private void levelComplete()
    {
        //Play win animation before load scene
        SceneManager.LoadScene("LevelBreakRoom");
        objectivetype = 0;
        eH = null;

        floornum = GameObject.FindGameObjectWithTag("FloorNum");
        TextMeshPro numTextBox = floornum.GetComponent<TextMeshPro>();
        numTextBox.text = ("Floor: " + floorsClear);
        soundManager.stopmusic();
        soundManager.playMusic(Victory);
    }
    public void LevelLoad()
    {
        string levelname = ("Test " + level);

        soundManager.playMusic(LVLM1);

        SceneManager.LoadScene(levelname);
        floorsClear++;
    }

}