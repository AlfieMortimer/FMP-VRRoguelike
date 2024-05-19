using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnAmmo : MonoBehaviour
{
    public GameObject Ammo;

    public void spawnAmmo()
    {
        if (SceneManager.loadedSceneCount == 1)
        {
            Instantiate(Ammo, gameObject.transform.position, Quaternion.identity);
        }
    }
}
