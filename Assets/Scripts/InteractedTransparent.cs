using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractedTransparent : MonoBehaviour
{
    public Material White;
    public Material Transparent;
    public XRDirectInteractor Lhand;
    public GameObject lHandModel;
    public XRDirectInteractor Rhand;
    public GameObject rHandModel;
    public void itemGrabbed()
    {
        if (Lhand.hasSelection == true)
        lHandModel.GetComponent<SkinnedMeshRenderer>().material = Transparent;
        else
        {
            lHandModel.GetComponent<SkinnedMeshRenderer>().material = White;
        }
        if (Rhand.hasSelection == true)
            rHandModel.GetComponent<SkinnedMeshRenderer>().material = Transparent;
        else
        {
            rHandModel.GetComponent<SkinnedMeshRenderer>().material = White;
        }
       
    } 
}
