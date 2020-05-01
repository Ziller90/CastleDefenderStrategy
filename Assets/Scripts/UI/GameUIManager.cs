﻿using System.Collections;
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
    public Text ImprovingCostShadow;
    public Text SellCost;
    public Text SellCostShadow;
    public Text CurrentLevel;
    public Text CurrentLevelShadow;
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
    public Translation Level;
    public Translation Sell;
    public GameObject ImproveButtonBlack;
    public GameObject LevelUpCostString;
    public GameObject MAX;
    public GameObject Lock;
    public GameObject Star;
    public GameObject ArrowsUp;
    public GameObject ShowInterfaceIdenButton;
    public GameObject HideInterfaceButton;










    void Start()
    {
        PlayingUIElements = LinksContainer.instance.PlayingUIElements;
        if (Debug.isDebugBuild)
        {
            HideInterfaceButton.SetActive(true);
        }
        MessageManager = LinksContainer.instance.Level.GetComponent<MessagesManager>();
        ImprovingAvaiableLevel = LinksContainer.instance.Level.GetComponent<ImprovingsLevelsAvaiable>().ImprovingsAvaiableLevel;

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
            NewThingsMark.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Fader.fadeState == ScreenFader.FadeState.OutEnd)
        {
            ShowPauseMenu();
        }
        if (BuildingToImprove != null)
        {
            SellCost.text = "" + BuildingToImprove.BuildingCard.SellCost[BuildingToImprove.Currentlevel];
            SellCostShadow.text = "" + BuildingToImprove.BuildingCard.SellCost[BuildingToImprove.Currentlevel];
            if (BuildingToImprove.BuildingCard.BuildingId == 2)
            {
                BuidlingImproveButton.SetActive(false);
            }
            if (BuildingToImprove.BuildingCard.AmountOfLevels == BuildingToImprove.Currentlevel || BuildingToImprove.Currentlevel + 1 == ImprovingAvaiableLevel)
            {
                ImproveButtonBlack.SetActive(true);
                LevelUpCostString.SetActive(false);
                MAX.SetActive(true);
                ArrowsUp.SetActive(false);
                if (BuildingToImprove.Currentlevel == 1)
                {
                    Lock.SetActive(true);
                }
                if (BuildingToImprove.Currentlevel == 2)
                {
                    Star.SetActive(true);
                }
                CurrentLevel.text = Level.GetTranslatedText() + (BuildingToImprove.Currentlevel + 1);
                CurrentLevelShadow.text = Level.GetTranslatedText() + (BuildingToImprove.Currentlevel + 1);
                ImproveButtonBlack.SetActive(true);
            }
            else
            {
                if (BuildingToImprove.BuildingCard.LevelUpPrice[BuildingToImprove.Currentlevel + 1] > Manager.Gold)
                {
                    ImproveButtonBlack.SetActive(true);
                }
                else
                {
                    ImproveButtonBlack.SetActive(false);
                }
                Lock.SetActive(false);
                Star.SetActive(false);
                ArrowsUp.SetActive(true);
                MAX.SetActive(false);
                LevelUpCostString.SetActive(true);
                CurrentLevel.text = Level.GetTranslatedText() + (BuildingToImprove.Currentlevel + 2);
                CurrentLevelShadow.text = Level.GetTranslatedText() + (BuildingToImprove.Currentlevel + 2);
                ImprovingCost.text = "" + BuildingToImprove.BuildingCard.LevelUpPrice[BuildingToImprove.Currentlevel + 1];
                ImprovingCostShadow.text = "" + BuildingToImprove.BuildingCard.LevelUpPrice[BuildingToImprove.Currentlevel + 1];
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
    public void HideInterface()
    {
        PlayingUIElements.SetActive(false);
        ShowInterfaceIdenButton.SetActive(true);
    }
    public void ShowInterface()
    {
        PlayingUIElements.SetActive(true);
        ShowInterfaceIdenButton.SetActive(false);
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
