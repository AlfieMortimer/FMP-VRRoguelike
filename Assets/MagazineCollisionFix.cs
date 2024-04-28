using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class MagazineCollisionFix : MonoBehaviour
{
    public GameObject socketObj;
    public ammoCapacity ammoscript;
    public XRsocketinteractorTag Socket;
    public GameObject Magazine;
    private void Start()
    {
        socketObj = GameObject.FindGameObjectWithTag("MagSocket");
        Socket = socketObj.GetComponent<XRsocketinteractorTag>();
    }
    public void layerEnter()
    {
        IXRSelectInteractable enteredMag = Socket.GetOldestInteractableSelected();
        ammoscript = enteredMag.transform.GetComponent<ammoCapacity>();
        Magazine = enteredMag.transform.gameObject;
        ammoscript.inGun = true;
    }
    public void layerExit()
    {
        ammoscript.inGun = false;
        print(Magazine.tag);
        
    }
    
}
