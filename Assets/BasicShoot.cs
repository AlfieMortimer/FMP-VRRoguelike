using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class BasicShoot : MonoBehaviour
{

    [Header("Stuff for shooting bullet")]
    public LayerMask Enemy;
    public Transform shootposition;
    EnemyHealthscript enemyHealth;
    public playerStats playerStats;
    public float weaponAmmo = 1f;
    private bool Magazine = false;
    public float Chamber = 1f;

    [Header("animation stuff")]
    public Animator anim;
    public GameObject muzzleFlash;
    public Transform barrelLocation;

    
    

    private float destroyTimer = 2f;

    public void ShootWeapon()
    {
        if (Magazine == true)
        {
            GameObject Current = GameObject.FindGameObjectWithTag("inClip");
            ammoCapacity magAmmo = Current.GetComponentInParent<ammoCapacity>();
            if (weaponAmmo >= 1)
            {
                Shoot();
                //lower magazine ammo count
                if (weaponAmmo >= 1)
                {
                    weaponAmmo--;
                    magAmmo.ammoCount--;
                    
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
        Magazine = false;
        GameObject Current = GameObject.FindGameObjectWithTag("inClip");
        print(Current.ToString());
        if ( Current != null)
        {
            ammoCapacity magAmmo = Current.GetComponentInParent<ammoCapacity>();
            
            print(magAmmo.ammoCount);
            weaponAmmo = magAmmo.ammoCount;
            Magazine = true;
        }
    }
    public void ammoUnloaded()
    {
        GameObject Current = GameObject.FindGameObjectWithTag("inClip");
        ammoCapacity magAmmo = Current.GetComponentInParent<ammoCapacity>();
        if (weaponAmmo >= 1 && Chamber <= 0)
            {
                Chamber = 1;
                weaponAmmo--;
                magAmmo.ammoCount--;
            }

    }
    public void Shoot()
    {
        //Create the muzzle flash
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlash, barrelLocation.position, barrelLocation.rotation);

        //Destroy the muzzle flash effect
        Destroy(tempFlash, destroyTimer);


        anim.SetTrigger("shoot");
        anim.ResetTrigger("shoot");

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;

        //Shoots ray to detect damage
        Debug.DrawRay(shootposition.position, forward, Color.green);
        if (Physics.Raycast(shootposition.position, forward, out RaycastHit hit, float.MaxValue, Enemy))
        {
            //gets enemy health script and removes the weaponDMG stat away from it.
            enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealthscript>();
            enemyHealth.health -= playerStats.weaponDMG;

        }
    }

}
