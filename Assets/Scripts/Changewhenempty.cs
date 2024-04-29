using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changewhenempty : MonoBehaviour
{
    public Mesh emptyMag;
    public ammoCapacity ammoCapacity;
    public MeshFilter fullMagazine;

    // Update is called once per frame
    void Update()
    {
        if (ammoCapacity.ammoCount <= 0)
        {
            fullMagazine.mesh = emptyMag;
        }
    }
}
