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
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ShopButton()
    {
        SceneManager.LoadScene(4);
    }
    public void Settings()
    {
        SceneManager.LoadScene(6);
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
