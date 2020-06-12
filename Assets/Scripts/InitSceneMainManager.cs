﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class InitSceneMainManager : MonoBehaviour
{
    public SavingSystem savingSystem;

    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerVisitIndex") > 0)
        {
            PlayerPrefs.SetInt("PlayerVisitIndex", (PlayerPrefs.GetInt("PlayerVisitIndex") + 1));
            savingSystem.SetPlayerData();
        }
        if (PlayerPrefs.GetInt("PlayerVisitIndex") == 0 || PlayerPrefs.HasKey("PlayerVisitIndex") == false)
        {
            savingSystem.SetPlayerStartSetting();
            PlayerPrefs.SetInt("PlayerVisitIndex", 1);
        }
        SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame

} 
