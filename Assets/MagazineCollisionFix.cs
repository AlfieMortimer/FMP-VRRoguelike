using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineCollisionFix : MonoBehaviour
{
    public void layerEnter()
    {
        gameObject.layer = 7;
        gameObject.tag = "inClip";
        print(gameObject.tag);
    }
    public void layerExit()
    {
        gameObject.layer = 0;
        gameObject.tag = "MAG";
        print(gameObject.tag);
    }
}
