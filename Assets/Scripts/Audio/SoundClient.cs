using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClient : MonoBehaviour
{
    float SoundNormalVolume;
    SoundClient NewSoundClient;
    AudioSource NewSource;
    void Awake ()
    {
        NewSource = gameObject.GetComponent<AudioSource>();
        SoundNormalVolume = NewSource.volume;
        var SoundManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        NewSoundClient = gameObject.GetComponent<SoundClient>();
        SoundManager.SetNewSound(NewSoundClient);
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchSoundOff()
    {
        Debug.Log("off");
        gameObject.GetComponent<AudioSource>().volume = 0;
    }
    public void SwitchSoundOn()
    {
        Debug.Log("On");
        gameObject.GetComponent<AudioSource>().volume = SoundNormalVolume;
    }
}
