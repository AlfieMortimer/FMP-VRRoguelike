using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerDamageHandler : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStatusHandler PlayerStatus = other.GetComponent<PlayerStatusHandler>();
            PlayerStatus.Health -= damage;
        }
    }
}
