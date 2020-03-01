using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuButtons : MonoBehaviour
{
    bool FirstTimeInGame = true;
    public SavingSystem savingSystem;
    public ShopManager ShopMgr;
    public GameObject LoadingText;
    public Text Loading;
    public Text LevelNumber;
    public Text LevelNumberShadow;

    public LanguageText PlayButtonTranslation;
    public LanguageText PlayButtonTranslationShadow;
    public Translation NewGame;
    public Translation ContinueGame;
    public GameObject SettingsPanel;
    public GameObject MainButtons;
    public GameObject Shop;
    public GameObject ShopOpenButton;
    public GameObject NewThingsMark;
    public static bool ABwasLoaded;
    public int NumberOfChapter = 0;
    public int NumberOfLevelOfChapter = 0;
    public static bool  AlreadySeeNewThingsLevel6;
    public GameObject AuthoresPanel;
    int NumberOfNewThings;
    public GameObject Crown;


    void Start()
    {
       
        if (PlayerStats.GameWasFinished == true)
        {
            Crown.SetActive(true);
        }
        if (PlayerStats.CampaignProgressIndex < 5)
        {
            NumberOfChapter = 1;
        }
        if (PlayerStats.CampaignProgressIndex < 10 && PlayerStats.CampaignProgressIndex > 5)
        {
            NumberOfChapter = 2;
        }
        if (PlayerStats.CampaignProgressIndex == 10)
        {
            NumberOfChapter = 3;
        }
        if (NumberOfChapter == 1)
        {
            NumberOfLevelOfChapter = PlayerStats.CampaignProgressIndex;
        }
        if (NumberOfChapter == 2)
        {
            NumberOfLevelOfChapter = PlayerStats.CampaignProgressIndex - 5;
        }
        if (NumberOfChapter == 3)
        {
            NumberOfLevelOfChapter = 1;
        }
        LevelNumberUpdateInfo();

        ShopMgr.ShopAcessLevel = 2;
        if (PlayerStats.CampaignProgressIndex >= 6)
        {
            ShopMgr.ShopAcessLevel = 2;
        }
        if (PlayerStats.CampaignProgressIndex >= 9)
        {
            ShopMgr.ShopAcessLevel = 3;
        }
        if (PlayerStats.CampaignProgressIndex >= 6 && AlreadySeeNewThingsLevel6 == false)
        {
            NewThingsMark.SetActive(true);
            NumberOfNewThings = 1;
        }
    }
    public void ShowAuthors()
    {
        MainButtons.SetActive(false);
        AuthoresPanel.SetActive(true);
    }
    public void HideAuthors()
    {
        AuthoresPanel.SetActive(false);
        MainButtons.SetActive(true);
    }
    public void SeeIfNewThings()
    {
        if (NewThingsMark.activeSelf == true)
        {
            if (NumberOfNewThings == 1)
            {
                AlreadySeeNewThingsLevel6 = true;
                NewThingsMark.SetActive(false);
            }
        }

    }
    void Awake()
    {
        if (PlayerStats.CampaignProgressIndex > 2)
        {
            ShopOpenButton.SetActive(true);
        }
        else
        {
            ShopOpenButton.SetActive(false);
        }
        Time.timeScale = 1;
        if (PlayerStats.CampaignProgressIndex == 0)
        {
            PlayButtonTranslation.Translation = NewGame;
            PlayButtonTranslationShadow.Translation = NewGame;

        }
        else
        {
            PlayButtonTranslation.Translation = ContinueGame;
            PlayButtonTranslationShadow.Translation = ContinueGame;
        }
    }

    public void LevelNumberUpdateInfo()
    {
        LevelNumber.text = LevelNumber.text + "  " + NumberOfChapter + " - " + NumberOfLevelOfChapter;
        LevelNumberShadow.text = LevelNumberShadow.text + "  " + NumberOfChapter + " - " + NumberOfLevelOfChapter;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SavingSystem.SavePlayerData();
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            SavingSystem.SavePlayerData();
        }
    }
    public void ShopButton()
    {
        Shop.SetActive(true);
        MainButtons.SetActive(false);
    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
        MainButtons.SetActive(false);
    }
    public void DeveloperMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitButton()
    {
        SavingSystem.SavePlayerData();
        Application.Quit();
    }
    public void PlayButton ()
    {
        Debug.Log(PlayerStats.CampaignProgressIndex);
        if (PlayerStats.CampaignProgressIndex == 0)
        {
            StartCoroutine("Fading", 5);
        }
        else
        {
            StartCoroutine("Fading", 3);
            LevelLoader.LevelToLoad = PlayerStats.CampaignProgressIndex;
            gameObject.GetComponent<LevelLoader>().LoadLevel(PlayerStats.CampaignProgressIndex);
        }
    }
    IEnumerator Fading (int SceneToLoad)
    {
        gameObject.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.In;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(SceneToLoad);
        LoadingText.SetActive(true);
        gameObject.GetComponent<ScreenFader>().enabled = false;
    }
    public void GoToTyler()
    {
        SavingSystem.SavePlayerData();
        Application.OpenURL("https://tylercunningham.bandcamp.com/");
    }
    public void ERASEPROGRESS()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
 
}
