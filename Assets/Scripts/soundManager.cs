using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    public void playsfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void playMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void stopmusic()
    {
        musicSource.Stop();
    }
}