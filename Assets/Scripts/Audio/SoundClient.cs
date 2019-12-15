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
        var SoundManager = LinksContainer.instance.audioManager;
        NewSoundClient = gameObject.GetComponent<SoundClient>();
        SoundManager.SetNewSound(NewSoundClient);
    }

    // Update is called once per frame

    public void SwitchSoundOff()
    {

        gameObject.GetComponent<AudioSource>().volume = 0;
    }
    public void SwitchSoundOn()
    {
        gameObject.GetComponent<AudioSource>().volume = SoundNormalVolume;
    }
}
