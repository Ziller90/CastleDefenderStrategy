using System.Collections;
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

    [SerializeField]
    public static bool StrongWalls;
    [SerializeField]
    public static bool GoldFever;
    [SerializeField]
    public static bool StartUpCapital;
    [SerializeField]
    public static bool SuperMine;




    public void BuyProduct (int ProductIndex)
    {
        if (PlayerStats.Crystals - Prices[ProductIndex] >= 0)
        {
            BuyButtons[ProductIndex].interactable = false;
            SoldOut[ProductIndex].SetActive(true);
            SetImprovement(ProductIndex);
        }
    }
    void Start()
    {
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
        else
        {
            NextButton.interactable = true;
        }
        if (PageIndex == 1)
        {
            PreviousButton.interactable = false;
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
