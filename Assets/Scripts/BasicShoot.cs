using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

public class BasicShoot : MonoBehaviour
{
    public GameObject socketObj;
    public XRsocketinteractorTag Socket;
    public ammoCapacity ammoscript;
    public soundManager sM;

    [Header("Stuff for shooting bullet")]
    public LayerMask Enemy;
    public Transform shootposition;
    EnemyHealthscript enemyHealth;
    public playerStats playerStats;
    public float weaponAmmo = 1f;
    private bool magazineInGun = false;
    public float Chamber = 1f;
    public AudioClip Gunshot;
    public AudioClip GooHit;

    [Header("animation stuff")]
    public Animator anim;
    public GameObject muzzleFlash;
    public Transform barrelLocation;


    private float destroyTimer = 2f;

    private void Start()
    {
        socketObj = GameObject.FindGameObjectWithTag("MagSocket");
        Socket = socketObj.GetComponent<XRsocketinteractorTag>();
        GameObject player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<playerStats>();
        sM = GameObject.FindWithTag("audiomanager").GetComponent<soundManager>();
    }

    public void ShootWeapon()
    {
        if (magazineInGun == true)
        {
            if (weaponAmmo >= 1)
            {
                Shoot();
                //lower magazine ammo count
                if (weaponAmmo >= 1)
                {
                    weaponAmmo--;
                    ammoscript.ammoCount--;
                    
                }
            }
        }
        else if (Chamber >= 1)
        {
            Shoot();
            //lower chamber ammo count
            Chamber--;

        }
        
        
    }
    public void ammoLoaded()
    {
        socketObj = GameObject.FindGameObjectWithTag("MagSocket");
        Socket = socketObj.GetComponent<XRsocketinteractorTag>();
        IXRSelectInteractable enteredMag = Socket.GetOldestInteractableSelected();
        GameObject Magazine = enteredMag.transform.gameObject;
        if ( enteredMag != null)
        {
            ammoscript = enteredMag.transform.GetComponent<ammoCapacity>();

            print(ammoscript.ammoCount);
            weaponAmmo = ammoscript.ammoCount;
            magazineInGun = true;
        }
    }
    public void ammoUnloaded()
    {
        if (weaponAmmo >= 1 && Chamber <= 0)
            {
                Chamber = 1;
                weaponAmmo = 0;
                ammoscript.ammoCount--;
            }
        magazineInGun = false;
    }
    public void Shoot()
    {
        //Create the muzzle flash
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlash, barrelLocation.position, barrelLocation.rotation);

        sM.playsfx(Gunshot);

        //Destroy the muzzle flash effect
        Destroy(tempFlash, destroyTimer);


        anim.SetTrigger("shoot");
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;

        //Shoots ray to detect damage
        Debug.DrawRay(shootposition.position, forward, Color.green);
        if (Physics.Raycast(shootposition.position, forward, out RaycastHit hit, 1000f, Enemy))
        {
            //gets enemy health script and removes the weaponDMG stat away from it.
            enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealthscript>();
            enemyHealth.health -= playerStats.weaponDMG;
            sM.playsfx(GooHit);
        }
    }

}
