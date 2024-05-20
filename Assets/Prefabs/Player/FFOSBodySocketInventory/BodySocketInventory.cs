using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class bodySocket
{
    public GameObject gameObject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}

public class BodySocketInventory : MonoBehaviour

{
    public XRRayInteractor leftHand;
    public XRRayInteractor rightHand;

    public GameObject HMD;
    public bodySocket[] bodySockets;

    private Vector3 _currentHMDlocalPosition;
    private Quaternion _currentHMDRotation;
    void Update()
    {
        _currentHMDlocalPosition = HMD.transform.localPosition;
        _currentHMDRotation = HMD.transform.rotation;
        foreach(var bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }
        UpdateSocketInventory();
    }

    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {

        bodySocket.gameObject.transform.localPosition = new Vector3(bodySocket.gameObject.transform.localPosition.x,(_currentHMDlocalPosition.y * bodySocket.heightRatio), bodySocket.gameObject.transform.localPosition.z);
    }

    private void UpdateSocketInventory()
    {
        transform.localPosition = new Vector3(_currentHMDlocalPosition.x, 0, _currentHMDlocalPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x, _currentHMDRotation.y, transform.rotation.z, _currentHMDRotation.w);
    }
    public void dropgun()
    {
        if(leftHand.selectTarget.tag == "Gun")
        {
            GameObject gun = leftHand.selectTarget.gameObject;
            gun.transform.position = bodySockets[0].gameObject.transform.position;
        }
        else if (rightHand.selectTarget.tag == "Gun")
        {
            GameObject gun = rightHand.selectTarget.gameObject;
            gun.transform.position = bodySockets[0].gameObject.transform.position;
        }
    } 
}
