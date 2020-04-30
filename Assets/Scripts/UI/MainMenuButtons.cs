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
    public GameObject LevelsPanel;

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
    public static bool  AlreadySeeNewThingsLevel6;
    public GameObject AuthoresPanel;
    int NumberOfNewThings;
    public GameObject Crown;
    public Text NumberOfLevel;
    public Text NumberOfLevelShadow;
    public GameObject LevelNumberTexts;
    public GameObject TutorialText;
    public Translation LevelText;
    public AsyncOperation AO;
    public GameObject LevelSelection;
    public GameObject ThanksPanel;
    public GameObject EraseProgressPanel;
    public int CounterToResetProgress;
    public Translation Left;
    public Translation Clicks;
    public Text ClicksLeftToEraseProgress;





    void Start()
    {
        if (PlayerStats.DifficultyLevelIndex == 0)
        {
            PlayerStats.DifficultyLevelIndex = 2;
        }
         if (PlayerStats.GameWasFinished == true)
        {
            Crown.SetActive(true);
            ShopMgr.ShopAcessLevel = 2;
            LevelNumberTexts.SetActive(false);
            LevelSelection.SetActive(true);
        }
        if (PlayerStats.GameWasFinished == false)
        {
            ShopMgr.ShopAcessLevel = 1;
            if (PlayerStats.CampaignProgressIndex >= 6)
            {
                ShopMgr.ShopAcessLevel = 2;
            }

            if (PlayerStats.CampaignProgressIndex >= 6 && AlreadySeeNewThingsLevel6 == false)
            {
                NewThingsMark.SetActive(true);
                NumberOfNewThings = 1;
            }
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
    public void ShowThanksForPlaying()
    {
        MainButtons.SetActive(false);
        ThanksPanel.SetActive(true);
    }
    public void HideThanksForPlaying()
    {
        MainButtons.SetActive(true);
        ThanksPanel.SetActive(false);
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

    void Update()
    {
        if (PlayerStats.CampaignProgressIndex != 0)
        {
            NumberOfLevel.text = "" + LevelText.GetTranslatedText() + PlayerStats.CampaignProgressIndex.ToString();
            NumberOfLevelShadow.text = "" + LevelText.GetTranslatedText() + PlayerStats.CampaignProgressIndex.ToString();
        }
        else
        {
            LevelNumberTexts.SetActive(false);
            TutorialText.SetActive(true);
        } 
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
        LevelsPanel.SetActive(true);
        MainButtons.SetActive(false);
    }
    public void QuitButton()
    {
        SavingSystem.SavePlayerData();
        Application.Quit();
    }
    public void PlayButton ()
    {
        if (PlayerStats.GameWasFinished == false)
        {
            if (PlayerStats.CampaignProgressIndex == 0)
            {
                StartCoroutine("Fading", 5);
            }
            else
            {
                StartCoroutine("Fading", 3);
                LevelLoader.LevelToLoad = PlayerStats.CampaignProgressIndex;
            }
        }
        else
        {
            LevelsPanel.SetActive(true);
            MainButtons.SetActive(false);
        }
    }
    IEnumerator Fading (int SceneToLoad)
    {
        AO = SceneManager.LoadSceneAsync(SceneToLoad);
        AO.allowSceneActivation = false;
        gameObject.GetComponent<ScreenFader>().fadeState = ScreenFader.FadeState.In;
        yield return new WaitForSeconds(1.5f);
        LoadingText.SetActive(true);
        gameObject.GetComponent<ScreenFader>().enabled = false;
        AO.allowSceneActivation = true;
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
    public void ProgressResettingPanel()
    {
        EraseProgressPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void YESResetProgress()
    {
        ClicksLeftToEraseProgress.gameObject.SetActive(true);
        CounterToResetProgress--;
        ClicksLeftToEraseProgress.text = Left.GetTranslatedText() + " " + CounterToResetProgress.ToString() + " " + Clicks.GetTranslatedText();
        if (CounterToResetProgress == 0)
        {
            ERASEPROGRESS();
        }
    }
    public void NOEraseProgress()
    {
        CounterToResetProgress = 5;
        ClicksLeftToEraseProgress.gameObject.SetActive(false);
        EraseProgressPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
 
}
