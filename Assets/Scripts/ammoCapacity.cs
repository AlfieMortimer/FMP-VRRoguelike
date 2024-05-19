using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ammoCapacity : MonoBehaviour
{
    public playerStats Stats;
    public bool inGun;
    public float ammoCount = 20;
    public string initialScene;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Stats = player.GetComponent<playerStats>();
        ammoCount = Stats.maxAmmo;
    }
    private void Update()
    {

    }


}
