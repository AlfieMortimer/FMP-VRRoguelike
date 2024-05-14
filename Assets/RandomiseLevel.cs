using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class RandomiseLevel : MonoBehaviour
{
    public TextMeshPro levelNameAndDifficultyText;
    public TextMeshPro difficultyText;
    public Animator Dooranim;
    public GameObject Player;


    public string levelName;
    public string levelTypeName;

    GameObject LevelManagerfinder;
    levelManager LM;

    public float Stage;
    //stages 1-5 (for now)

    public float levelType;
    //Type 1 - Defeat Enemies
    //Type 2 - Destroy Spawners
    //Type 3 - Capture Point

    public float Difficulty;
    //Difficulty 1 - Easy - less Enemies spawn and have less HP
    //Difficulty 2 - Normal - Base enemy spawns with normal HP
    //Difficulty 3 - Hard - Increased enemy spawns with larger health pools
    
    //Easy has a higher chance to appear at the start of a run and a lower chance after round 10
    //Hard has a lower chance to spawn the closer to the start of the run with a higher chance after round 10

    void Start()
    {
        LevelManagerfinder = GameObject.FindGameObjectWithTag("LevelManager");
        LM = LevelManagerfinder.GetComponent<levelManager>();
        Stage = Random.Range(0, 6);
        levelType = Random.Range(0, 4);
        Difficulty = Random.Range(0, 4);
        RandPrint();
    }

    public void RandPrint()
    {
        Debug.Log(Stage);
        Debug.Log(levelType);
        Debug.Log(Difficulty);
    }

    public void SendToLM()
    {
        print("Level: " + levelType);
        LM.playerCoord = Player.transform.position;
        LM.level = Stage;
        LM.objectivetype = levelType;
        LM.Difficulty = Difficulty;
        LM.LevelLoad();
    }


}
