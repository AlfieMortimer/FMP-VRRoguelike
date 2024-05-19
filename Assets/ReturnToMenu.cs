using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("LevelBreakRoom");
    }
    public void Return()
    {
        SceneManager.LoadScene("LevelBreakRoom");
    }
}
