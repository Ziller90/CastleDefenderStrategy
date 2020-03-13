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
    public GameObject PlayingUIElements;
    public GameObject ShopPanel;
    public GameObject ShopOpenButton;
    public ShopManager ShopMgr;
    public GameObject NewThingsMark;
    public GameSarter gameSarter;
    int NumberOfNewThings;




    void Start()
    {
        MessageManager = GameObject.FindGameObjectWithTag("Level").GetComponent<MessagesManager>();
        ImprovingAvaiableLevel = GameObject.FindGameObjectWithTag("Level").GetComponent<ImprovingsLevelsAvaiable>().ImprovingsAvaiableLevel;

        ShopMgr.ShopAcessLevel = 1;
        if (gameSarter.CurrentLevelCampaignIndex >= 6)
        {
            ShopMgr.ShopAcessLevel = 2;
        }
        //if (gameSarter.CurrentLevelCampaignIndex >= 9)
        //{
        //    ShopMgr.ShopAcessLevel = 3;
        //}
        if (gameSarter.CurrentLevelCampaignIndex >= 6 && MainMenuButtons.AlreadySeeNewThingsLevel6 == false)
        {
            NewThingsMark.SetActive(true);
            NumberOfNewThings = 1;
        }
        if (PlayerStats.GameWasFinished == false)
        {
            if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber > 2)
            {
                ShopOpenButton.SetActive(true);
            }
            else
            {
                ShopOpenButton.SetActive(false);
            }
        }
        else
        {
            ShopOpenButton.SetActive(true);
        }
       
    }
    private void Awake()
    {
      
    }
    public void SeeIfNewThings()
    {
        if (NewThingsMark.activeSelf == true)
        {
            if (NumberOfNewThings == 1)
            {
                MainMenuButtons.AlreadySeeNewThingsLevel6 = true;
                NewThingsMark.SetActive(false);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (LinksContainer.instance.Level.GetComponent<MapSetting>().MainSpawner.StartedSpawning == true)
        {
            ShopOpenButton.SetActive(false);
        }
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
    public void ShowShopPanel()
    {
        PlayingUIElements.SetActive(false);
        ShopPanel.SetActive(true);
    }
}
