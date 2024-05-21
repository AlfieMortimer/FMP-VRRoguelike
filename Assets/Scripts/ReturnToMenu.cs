using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject main;
    public void startGame()
    {
        SceneManager.LoadScene("LevelBreakRoom");
    }
    public void Return()
    {
        SceneManager.LoadScene("Start");
    }
    public void Settingsopen()
    {
        settings.SetActive(true);
        main.SetActive(false);
    }
    public void Settingsclose()
    {
        settings.SetActive(false);
        main.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
