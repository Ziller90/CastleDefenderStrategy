using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{

    public ShopProductsScriptableObject Shop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            SavePlayerData();
        }
    }
    public static void SavePlayerData()
    {
        if (PlayerStats.RateWindowWasShowed == true)
        {
            PlayerPrefs.SetInt("RateWindowWasShowed", 1);
        }
        if (PlayerStats.RateWindowWasShowed == false)
        {
            PlayerPrefs.SetInt("RateWindowWasShowed", 0);
        }

        if (PlayerStats.GameWasFinished == true)
        {
            PlayerPrefs.SetInt("GameWasFinished", 1);
        }
        if (MainMenuButtons.AlreadySeeNewThingsLevel6 == true)
        {
            PlayerPrefs.SetInt("AlreadySeeNewThingsLevel6", 1);
        }
        PlayerPrefs.SetString("BoughtProducts", JsonUtility.ToJson(ShopProductsScriptableObject.purchases));

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
            //case GlobalLanguageManager.GloabalLanguage.Japan:
            //    PlayerPrefs.SetInt("LanguageIndex", 2);
            //    break;
            //case GlobalLanguageManager.GloabalLanguage.Korean:
            //    PlayerPrefs.SetInt("LanguageIndex", 3);
            //    break;
            case GlobalLanguageManager.GloabalLanguage.Russian:
                PlayerPrefs.SetInt("LanguageIndex", 4);
                break;
            //case GlobalLanguageManager.GloabalLanguage.Spanish:
            //    PlayerPrefs.SetInt("LanguageIndex", 5);
            //    break;
        }
    }
    public void SetPlayerData()
    {
        if (PlayerPrefs.GetInt("RateWindowWasShowed") == 1)
        {
            PlayerStats.RateWindowWasShowed = true;
        }
        if (PlayerPrefs.GetInt("RateWindowWasShowed") == 0)
        {
            PlayerStats.RateWindowWasShowed = false;
        }

        ShopProductsScriptableObject.purchases = JsonUtility.FromJson<ShopProductsScriptableObject.Purchases>(PlayerPrefs.GetString("BoughtProducts"));
        PlayerStats.DifficultyLevelIndex = PlayerPrefs.GetInt("DifficultyLevel");
        if (PlayerPrefs.GetInt("GameWasFinished") == 1)
        {
            PlayerStats.GameWasFinished = true;
        }
        if (PlayerPrefs.GetInt("AlreadySeeNewThingsLevel6") == 1)
        {
            MainMenuButtons.AlreadySeeNewThingsLevel6 = true;
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
            //case 2:
            //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Japan;
            //    break;
            //case 3:
            //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Korean;
            //    break;
            case 4:
                GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Russian;
                break;
            //case 5:
            //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Spanish;
            //    break;

        }
    }
    public void SetPlayerStartSetting()
    {
        PlayerStats.GameWasFinished = false;
        ShopProductsScriptableObject.purchases.BoughtProducts.Clear();
        QualitySettings.SetQualityLevel(2);
        PlayerStats.Crystals = 0;
        PlayerStats.DifficultyLevelIndex = 2;
        PlayerStats.CampaignProgressIndex = 0;
        AudioManager.SoundOn = true;
        MusicManager.MusicPlaying = true;

        if (Application.systemLanguage == SystemLanguage.English)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.English;
        }
        //if (Application.systemLanguage == SystemLanguage.Japanese)
        //{
        //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Japan;
        //}
        //if (Application.systemLanguage == SystemLanguage.Korean)
        //{
        //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Korean;
        //}
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Russian;
        }
        else
        {
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.English;
        }
        //if (Application.systemLanguage == SystemLanguage.Spanish)
        //{
        //    GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Spanish;
        //}
    }
    
}
