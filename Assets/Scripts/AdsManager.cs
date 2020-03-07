using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3243302";
#elif UNITY_ANDROID
    private string gameId = "3243303";
#endif
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
    public string AdError;
    public string PleaseWatchAdFull;
    public string ThanksForWhatching;


    void Start()
    {
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
                winScript.CrystalsRewardForWin = winScript.CrystalsRewardForWin * 2;
                StartCoroutine(ShowConsole(ThanksForWhatching, Color.yellow));
            }
            if (showResult == ShowResult.Skipped)
            {
                StartCoroutine(ShowConsole(PleaseWatchAdFull, Color.red));
            }
            if (showResult == ShowResult.Failed)
            {
                StartCoroutine(ShowConsole(AdError, Color.red));
            }
            Time.timeScale = 1;
        }
        else if (placementId == GameOverVideo)
        {
            Debug.Log("ItWasGameOver");

            GameOverPanel.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(3);
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
        yield return new WaitForSeconds(3f);
        AdConsole.SetActive(false);
    }
}
