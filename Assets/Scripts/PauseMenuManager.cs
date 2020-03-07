using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public PauseResumeScript Pauser;
    public AdsManager adsManager;
     

    // Update is called once per frame
    void Update()
    {
            if (SettingsPanel.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    BackFromSettings();
                }
            }
    }
    public void ReStart ()
    {
        adsManager.ShowGameOverAd();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        Pauser.Paused = true;
        Pauser.OnClick();
    }
    public void MainMenu ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void RestartTutorial()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
    public void BackFromSettings()
    {
        SettingsPanel.SetActive(false);
    }
}
