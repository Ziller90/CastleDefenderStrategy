using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{

     

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<SavingSystem>().SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            gameObject.GetComponent<SavingSystem>().SavePlayerData();
        }

    }
    public void SavePlayerData()
    {
        if (ShopManager.GoldFever == true)
        {
            PlayerPrefs.SetInt("GoldFever", 1);
        }
        else
        {
            PlayerPrefs.SetInt("GoldFever", 0);
        }

        if (ShopManager.StartUpCapital == true)
        {
            PlayerPrefs.SetInt("StartUpCapital", 1);
        }
        else
        {
            PlayerPrefs.SetInt("StartUpCapital", 0);
        }

        if (ShopManager.StrongWalls == true)
        {
            PlayerPrefs.SetInt("StrongWalls", 1);
        }
        else
        {
            PlayerPrefs.SetInt("StrongWalls", 0);
        }

        if (ShopManager.SuperMine == true)
        {
            PlayerPrefs.SetInt("SuperMine", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SuperMine", 0);
        }


        PlayerPrefs.SetInt("CrystalsAmount", PlayerStats.Crystals);
        PlayerPrefs.SetInt("CampaignProgressIndex", PlayerStats.CampaignProgressIndex);
        if (AudioManager.SoundOn == true)
        {
            PlayerPrefs.SetInt("SoundIndex", 1);
        }
        if (AudioManager.SoundOn == false)
        {
            PlayerPrefs.SetInt("SoundIndex", 0);
        }
        if (MusicManager.MusicPlaying == true)
        {
            PlayerPrefs.SetInt("MusicIndex", 1);
        }
        if (MusicManager.MusicPlaying == false)
        {
            PlayerPrefs.SetInt("MusicIndex", 0);
        }

        switch (GlobalLanguageManager.Language)
        {
            case GlobalLanguageManager.GloabalLanguage.English:
                PlayerPrefs.SetInt("LanguageIndex", 1);
                break;
            case GlobalLanguageManager.GloabalLanguage.Japan:
                PlayerPrefs.SetInt("LanguageIndex", 2);
                break;
            case GlobalLanguageManager.GloabalLanguage.Korean:
                PlayerPrefs.SetInt("LanguageIndex", 3);
                break;
            case GlobalLanguageManager.GloabalLanguage.Russian:
                PlayerPrefs.SetInt("LanguageIndex", 4);
                break;
            case GlobalLanguageManager.GloabalLanguage.Spanish:
                PlayerPrefs.SetInt("LanguageIndex", 5);
                break;
        }
    }
    public void SetPlayerData()
    {
        if (PlayerPrefs.GetInt("GoldFever") == 1)
        {
            ShopManager.GoldFever = true;
        }
        else
        {
            ShopManager.GoldFever = false;
        }

        if (PlayerPrefs.GetInt("StartUpCapital") == 1)
        {
            ShopManager.StartUpCapital = true;
        }
        else
        {
            ShopManager.StartUpCapital = false;
        }

        if (PlayerPrefs.GetInt("StrongWalls") == 1)
        {
            ShopManager.StrongWalls = true;
        }
        else
        {
            ShopManager.StrongWalls = false;
        }

        if (PlayerPrefs.GetInt("SuperMine") == 1)
        {
            ShopManager.SuperMine = true;
        }
        else
        {
            ShopManager.SuperMine = false;
        }

        PlayerStats.Crystals = PlayerPrefs.GetInt("CrystalsAmount");
        PlayerStats.CampaignProgressIndex = PlayerPrefs.GetInt("CampaignProgressIndex");
        if (PlayerPrefs.GetInt("SoundIndex") == 1)
        {
            AudioManager.SoundOn = true;
        }
        if (PlayerPrefs.GetInt("SoundIndex") == 0)
        {
            AudioManager.SoundOn = false;
        }
        if (PlayerPrefs.GetInt("MusicIndex") == 1)
        {
            MusicManager.MusicPlaying = true;
        }
        if (PlayerPrefs.GetInt("MusicIndex") == 0)
        {
            MusicManager.MusicPlaying = false;
        }

        switch (PlayerPrefs.GetInt("LanguageIndex"))
        {
            case 1:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.English;
                break;
            case 2:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Japan;
                break;
            case 3:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Korean;
                break;
            case 4:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Russian;
                break;
            case 5:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Spanish;
                break;

        }
    }
    public void SetPlayerStartSetting()
    {
        PlayerStats.Crystals = 0;
        PlayerStats.CampaignProgressIndex = 0;
        AudioManager.SoundOn = true;
        MusicManager.MusicPlaying = true;
        if (Application.systemLanguage == SystemLanguage.English)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.English;
        }
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Japan;
        }
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Korean;
        }
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Russian;
        }
        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Spanish;
        }
    }
}
