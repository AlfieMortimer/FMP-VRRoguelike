using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatusHandler : MonoBehaviour
{
    public float Health = 100f;

    public GameObject HealthUI;
    public Image HealthIndicator;
    public Color Healthopacity;
        // Start is called before the first frame update
    void Start()
    {
        HealthIndicator = HealthUI.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        Healthopacity.a = (100 - Health) / 100;
        HealthIndicator.color = Healthopacity;


        if (Health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        //CHANGE LATER - TESTING PURPOSES ONLY
        SceneManager.LoadScene("Death");
    }

    
}
