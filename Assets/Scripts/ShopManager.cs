﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject MainButtons;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public int PageIndex;
    public Button NextButton;
    public Button PreviousButton;
    public int[] Prices;
    public Button[] BuyButtons;
    public GameObject[] SoldOut;
    public Text GemsAmount;
    public Text GemsAmountShad;
    public int ShopAcessLevel;

    [SerializeField]
    public static bool StrongWalls;
    [SerializeField]
    public static bool GoldFever;
    [SerializeField]
    public static bool StartUpCapital;
    [SerializeField]
    public static bool SuperMine;
    [SerializeField]
    public static bool BurningArrows;
    [SerializeField]
    public static bool BigBalls;
    [SerializeField]
    public static bool FullFreeze;
    [SerializeField]
    public static bool Spikes;



    void Awake()
    {
        if (StrongWalls == true)
        {
            BuyButtons[0].interactable = false;
            SoldOut[0].SetActive(true);
        }
        if (GoldFever == true)
        {
            BuyButtons[1].interactable = false;
            SoldOut[1].SetActive(true);
        }
        if (SuperMine == true)
        {
            BuyButtons[2].interactable = false;
            SoldOut[2].SetActive(true);
        }
        if (StartUpCapital == true)
        {
            BuyButtons[3].interactable = false;
            SoldOut[3].SetActive(true);
        }
    }
    public void BuyProduct (int ProductIndex)
    {
        if (PlayerStats.Crystals - Prices[ProductIndex] >= 0)
        {
            PlayerStats.Crystals -= Prices[ProductIndex];
            BuyButtons[ProductIndex].interactable = false;
            SoldOut[ProductIndex].SetActive(true);
            SetImprovement(ProductIndex);
        }
    }
    void Start()
    {
        ShopAcessLevel = 3;
        PlayerStats.Crystals = 10000;
        PageIndex = 1;
    }
    void SetImprovement(int ImprovementIndex)
    {
        switch (ImprovementIndex)
        {
            case 0:
                StrongWalls = true;
                break;
            case 1:
                GoldFever = true;
                break;
            case 2:
                SuperMine = true;
                break;
            case 3:
                StartUpCapital = true;
                break;
            case 4:
                BurningArrows = true;
                break;
            case 5:
                BigBalls = true;
                break;
            case 6:
                FullFreeze = true;
                break;
            case 7:
                Spikes = true;
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        GemsAmount.text = PlayerStats.Crystals.ToString();
        GemsAmountShad.text = PlayerStats.Crystals.ToString();
        if (PageIndex == 3)
        {
            NextButton.interactable = false;
        }
        if (PageIndex == 2)
        {
            if (ShopAcessLevel == 2)
            {
                NextButton.interactable = false;
            }
            if (ShopAcessLevel > 2)
            {
                NextButton.interactable = true;
            }
        }
        if (PageIndex == 1)
        {
            PreviousButton.interactable = false;
            if (ShopAcessLevel == 1)
            {
                NextButton.interactable = false;
            }
            if (ShopAcessLevel > 1) 
            {
                NextButton.interactable = true;
            }
        }
        else
        {
            PreviousButton.interactable = true;
        }
        switch (PageIndex)
        {
            case 1:
                Page1.SetActive(true);
                Page2.SetActive(false);
                Page3.SetActive(false);
                break;
            case 2:
                Page1.SetActive(false);
                Page2.SetActive(true);
                Page3.SetActive(false);
                break;
            case 3:
                Page1.SetActive(false);
                Page2.SetActive(false);
                Page3.SetActive(true);
                break;
        }
    }
    public void BackButton()
    {
        MainButtons.SetActive(true);
        Shop.SetActive(false);
    }
    public void NextShopPage()
    {
        PageIndex++;
    }
    public void PreviousShopPage()
    {
        PageIndex--;
    }
}
