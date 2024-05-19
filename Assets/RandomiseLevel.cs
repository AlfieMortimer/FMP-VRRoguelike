using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomiseLevel : MonoBehaviour
{
    public GameObject LVLNameObj;
    public GameObject LVLDifficultyObj;
    TextMeshProUGUI levelNameAndDifficultyText;
    TextMeshProUGUI difficultyText;
    public Animator Dooranim;
    public GameObject Player;


    GameObject LevelManagerfinder;
    levelManager LM;

    public int Stage;
    //stages 1-5 (for now)

    public int levelType;
    //Type 1 - Defeat Enemies
    //Type 2 - Destroy Spawners
    //Type 3 - Capture Point

    public int Difficulty;
    //Difficulty 1 - Easy - less Enemies spawn and have less HP
    //Difficulty 2 - Normal - Base enemy spawns with normal HP
    //Difficulty 3 - Hard - Increased enemy spawns with larger health pools
    
    //Easy has a higher chance to appear at the start of a run and a lower chance after round 10
    //Hard has a lower chance to spawn the closer to the start of the run with a higher chance after round 10

    void Start()
    {
        string[] levelnames = { "Ignore", "Test1", "Test2", "Test3", "Test4", "Test5" };
        string[] objectiveNames = { "Ignore", "DefeatEnemies", "DestroySpawners", "CaptureZones" };
        string[] difficultynames = { "Ignore", "Easy", "Medium", "Hard" };

        levelNameAndDifficultyText = LVLNameObj.GetComponent<TextMeshProUGUI>();
        print("name:"+levelNameAndDifficultyText);
        difficultyText = LVLDifficultyObj.GetComponent<TextMeshProUGUI>();
        print("Diff "+ difficultyText);

        LevelManagerfinder = GameObject.FindGameObjectWithTag("LevelManager");
        LM = LevelManagerfinder.GetComponent<levelManager>();
        Stage = UnityEngine.Random.Range(1, 5);
        levelType = UnityEngine.Random.Range(1, 3);
        Difficulty = UnityEngine.Random.Range(1, 3);

        levelNameAndDifficultyText.text = levelnames[Stage] + "_" + objectiveNames[levelType];
        difficultyText.text = difficultynames[Difficulty];

        
    }

    public void RandPrint()
    {
        Debug.Log(Stage);
        Debug.Log(levelType);
        Debug.Log(Difficulty);
    }

    public void SendToLM()
    {
        LM.playerCoord = Player.transform.position;
        LM.level = Stage;
        LM.objectivetype = levelType;
        LM.Difficulty = Difficulty;
        LM.LevelLoad();
    }


}
