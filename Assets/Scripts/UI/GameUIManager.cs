using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    public MusicManager MusicManager;
    public GameObject BuidlingImproveButton;
    public GameObject BuidlingDestroyButton;
    public BuildingStats BuildingToImprove;
    public GameObject GameOverScreen;
    public GameObject PausePanel;
    public ResourcesManager Manager;
    public Text ImprovingCost;
    public Text SellCost;
    public Text CurrentLevel;
    MessagesManager MessageManager;
    int ImprovingAvaiableLevel;
    public ScreenFader Fader;


    void Start()
    {
        MessageManager = GameObject.FindGameObjectWithTag("Level").GetComponent<MessagesManager>();
        ImprovingAvaiableLevel = GameObject.FindGameObjectWithTag("Level").GetComponent<ImprovingsLevelsAvaiable>().ImprovingsAvaiableLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Fader.fadeState == ScreenFader.FadeState.OutEnd)
        {
            ShowPauseMenu();
        }
        if (BuildingToImprove != null)
        {
            SellCost.text = "" + BuildingToImprove.BuildingCard.SellCost[BuildingToImprove.Currentlevel];

            if (BuildingToImprove.BuildingCard.AmountOfLevels == BuildingToImprove.Currentlevel || BuildingToImprove.Currentlevel + 1 == ImprovingAvaiableLevel)
            {
                ImprovingCost.text = "MAX";
                CurrentLevel.text = "LEVEL " + (BuildingToImprove.Currentlevel + 1);
                BuidlingImproveButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                BuidlingImproveButton.GetComponent<Button>().interactable = true;
                CurrentLevel.text = "LEVEL " + (BuildingToImprove.Currentlevel + 1);
                ImprovingCost.text = "" + BuildingToImprove.BuildingCard.LevelUpPrice[BuildingToImprove.Currentlevel + 1];
            }
        }

    }
    public void ShowDestroyButton()
    {
        BuidlingDestroyButton.SetActive(true);
    }

    public void ShowImproveButton()
    {
        BuidlingImproveButton.SetActive(true);
    }

    public void HideDestroyButton()
    {
        BuidlingDestroyButton.SetActive(false);
    }

    public void HideImproveButton()
    {
        BuidlingImproveButton.SetActive(false);
    }

    public void BuildingLevelUP ()
    {
        BuildingToImprove.LevelUP ();
    }
    public void BuildingDestroy()
    {
        HideDestroyButton();
        HideImproveButton();
        BuildingToImprove.Destroy();
        Manager.Gold += BuildingToImprove.BuildingCard.SellCost[BuildingToImprove.Currentlevel];
    }
    public void ShowGameOverScreen ()
    {
        GameOverScreen.SetActive(true);
        MusicManager.StartCoroutine("StopMusic", 3);
    }
    public void ShowPauseMenu ()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }
    public void ShowButtonMessage()
    {
        MessageManager.ShowNewMessageButtonOnClick();
    }
}
