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

    [Header("animation stuff")]
    public Animator anim;
    public GameObject muzzleFlash;
    public Transform barrelLocation;

    private float destroyTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootWeapon()
    {
        
        //Create the muzzle flash
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlash, barrelLocation.position, barrelLocation.rotation);

        //Destroy the muzzle flash effect
        Destroy(tempFlash, destroyTimer);
        

        anim.SetTrigger("shoot");
        anim.ResetTrigger("shoot");

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        //cam = position ray started
        // out RaycastHit hit stores what was hit
        //float.MaxValue is the distance it can travel (change if u want limited distance)
        // shootable is layermask that holds the layers that the ray can collide with (you can set to multiple layers)
        Debug.DrawRay(shootposition.position, forward, Color.green);
        if (Physics.Raycast(shootposition.position, forward, out RaycastHit hit, float.MaxValue, Enemy))
        {
            //gets enemy health script and removes the weaponDMG stat away from it.
           enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealthscript>();
           enemyHealth.health -= playerStats.weaponDMG;
            
        }
    }
}
