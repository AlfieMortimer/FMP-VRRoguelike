using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatusHandler : MonoBehaviour
{
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        //CHANGE LATER - TESTING PURPOSES ONLY
        SceneManager.LoadScene("Tower");
    }

    
}
