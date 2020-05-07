using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string gameId;
    public string GameOverVideo = "video";
    public string WinRewardedVideo = "rewardedVideo";
    public WinScript winScript;
    public GameObject GameOverPanel;
    public Transform NewRewardPosition;
    public GameObject AdButton;
    public GameObject Reward;
    public GameObject AdConsole;
    public Text AdConsoleText;
    public Text AdConsoleTextShadow;
    public Translation AdError;
    public Translation PleaseWatchAdFull;
    public Translation ThanksForWhatching;
    public bool RewardedVideoWasShown;
    public GameSarter gameStarter;

    void Start()
    {
        gameId = "3243303";
        AdConsole.SetActive(false);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowShortAd()
    {
        if (RewardedVideoWasShown == false)
        {
            Time.timeScale = 0;
            Advertisement.Show(GameOverVideo);
        }
        else
        {
            gameStarter.NextMission();
        }
    }
    public void ShowGameOverAd()
    {
        Time.timeScale = 0;
        Advertisement.Show(GameOverVideo);
    }
    public void ShowWinAd()
    {
        Time.timeScale = 0;
        Advertisement.Show(WinRewardedVideo);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == WinRewardedVideo)
        {
            Debug.Log("ItWasWin");
            if (showResult == ShowResult.Finished)
            {
                HideAdButton();
                RewardedVideoWasShown = true;
                winScript.GiveRewardToPlayer();
                winScript.CrystalsRewardForWin = winScript.CrystalsRewardForWin * 2;
                StartCoroutine(ShowConsole(ThanksForWhatching.GetTranslatedText(), Color.yellow));
                SavingSystem.SavePlayerData();
            }
            if (showResult == ShowResult.Skipped)
            {
                StartCoroutine(ShowConsole(PleaseWatchAdFull.GetTranslatedText(), Color.red));
            }
            if (showResult == ShowResult.Failed)
            {
                StartCoroutine(ShowConsole(AdError.GetTranslatedText(), Color.red));
            }
            Time.timeScale = 1;
        }
        else if (placementId == GameOverVideo)
        {
            if (winScript.Win == false)
            {
                Debug.Log("ItWasGameOver");
                GameOverPanel.SetActive(false);
                Time.timeScale = 1;
                SceneManager.LoadScene(3);
            }
            else
            {
                Time.timeScale = 1;
                gameStarter.NextMission();

            }
        }
    }
    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
    public void HideAdButton()
    {
        AdButton.SetActive(false);
        Reward.transform.position = NewRewardPosition.position;
    }
    public void OnUnityAdsReady(string placementId)
    {

    }
    public IEnumerator ShowConsole(string Text, Color TextColor)
    {
        AdConsole.SetActive(true);
        AdConsoleText.color = TextColor;
        AdConsoleText.text = Text;
        AdConsoleTextShadow.text = Text;
        yield return new WaitForSeconds(5f);
        AdConsole.SetActive(false);
    }
}
