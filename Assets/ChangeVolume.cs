using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class ChangeVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixername;
    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat(name, PlayerPrefs.GetFloat(Slider.name));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Changevolume()
    {
        mixer.SetFloat(name, Slider.value);
        PlayerPrefs.SetFloat(Slider.name, Slider.value);
    }
}
