using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class captureZone : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timer -= Time.deltaTime;
        }
    }
}
