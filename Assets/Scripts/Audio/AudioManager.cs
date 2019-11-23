using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    private List<SoundClient> Sounds = new List<SoundClient>();
    public Image ButtonImage;
    public Sprite Texture1;
    public Sprite Texture2;

    public static bool SoundOn = true;
    void Awake ()
    {
       
    }
     
    void Update()
    {
        if (SoundOn == true)
        {
            ButtonImage.sprite = Texture1;
        }
        if (SoundOn == false)
        {
            ButtonImage.sprite = Texture2;
        }
    }
    public void SetNewSound(SoundClient NewClient)
    {
        Sounds.Add(NewClient);
        if (SoundOn == true)
        {
            NewClient.SwitchSoundOn();
        }
        else
        {
            NewClient.SwitchSoundOff();
        }
    }
    public void OnSoundButtonClick()
    {
        SoundOn = !SoundOn;
        if (SoundOn == true)
        {
            for (int i = 0; i < Sounds.Count; i++)
            {
                if (Sounds[i] != null)
                Sounds[i].SwitchSoundOn();
            }
            ButtonImage.sprite = Texture1;
        }
        else
        {
            for (int i = 0; i < Sounds.Count; i++)
            {
                if (Sounds[i] != null)
                Sounds[i].SwitchSoundOff();
            }
            ButtonImage.sprite = Texture2;
        }

    }
}
