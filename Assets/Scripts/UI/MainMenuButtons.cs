using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuButtons : MonoBehaviour
{
    bool FirstTimeInGame = true;
    public SavingSystem savingSystem;
    public GameObject LoadingText;
    public Text Loading;
    public LanguageText PlayButtonTranslation;
    public Translation NewGame;
    public Translation ContinueGame;
    public GameObject SettingsPanel;
    public GameObject MainButtons;
    public GameObject Shop;
    public GameObject ShopOpenButton;



    void Awake()
    {
        if (PlayerStats.CampaignProgressIndex > 5)
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
        }
        else
        {
            PlayButtonTranslation.Translation = ContinueGame;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            savingSystem.SavePlayerData();
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            savingSystem.SavePlayerData();
            Application.Quit();
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
        savingSystem.SavePlayerData();
        Application.Quit();
    }
    public void PlayButton ()
    {
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

}
