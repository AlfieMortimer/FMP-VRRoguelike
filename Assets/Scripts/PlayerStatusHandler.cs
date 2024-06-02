using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class PlayerStatusHandler : MonoBehaviour
{
    public float Health = 100f;

    public Color Healthopacity;
    soundManager SM;
    public Animator Anim;
        // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.FindWithTag("audiomanager").GetComponent<soundManager>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        SceneManager.LoadScene("Death");
        SM.stopmusic();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            playerDamageHandler PDH = other.gameObject.GetComponent<playerDamageHandler>();
            Health -= PDH.damage;
            if (Health <= 0)
            {
                Death();
            }
        }
    }

}
