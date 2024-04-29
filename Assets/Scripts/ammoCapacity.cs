using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCapacity : MonoBehaviour
{
    public playerStats Stats;
    public bool inGun;
    public float ammoCount = 20;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        Stats = player.GetComponent<playerStats>();
        ammoCount = Stats.maxAmmo;
        print(ammoCount);
    }



}
