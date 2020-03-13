﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicManager : MonoBehaviour
{
    public AudioClip[] MusicClips;
    private AudioSource AudioSource;
    public static bool MusicPlaying = true;
    public bool MusicChanging;
    public Sprite Texture1;
    public Sprite Texture2;
    public Image image;
    void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        if (MusicPlaying)
        {
            image.sprite = Texture1;
            AudioSource.enabled = true;
        }
        else
        {
            image.sprite = Texture2;
            AudioSource.enabled = false;
        }
        if (MusicChanging == true)
        {
            if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber < 6)
            {
                AudioSource.clip = MusicClips[0];
            }
            if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber > 5 && LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber < 10)
            {
                AudioSource.clip = MusicClips[1];
            }
            if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber == 10)
            {
                AudioSource.clip = MusicClips[2];
                AudioSource.volume = 0.65f;
            }
        }
        AudioSource.Play();
    }

    // Update is called once per frame
    public IEnumerator StopMusic (float StopTime)
    {
        for (float i = AudioSource.volume; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(StopTime / 100);
            AudioSource.volume -= 0.01f;
        }
    }
    public void MusicButton ()
    {
        MusicPlaying = !MusicPlaying;
        if (MusicPlaying)
        {
            image.sprite = Texture1;
            AudioSource.enabled = true;
        }
        else
        {
            image.sprite = Texture2;
            AudioSource.enabled = false;
        }
    }
}
