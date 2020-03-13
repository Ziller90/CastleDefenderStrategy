using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public ShopProductsScriptableObject shopProductsScriptableObject;
    public GameObject Shop;
    public GameObject MainButtons;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public int PageIndex;
    public Button NextButton;
    public Button PreviousButton;
    public Text GemsAmount;
    public Text GemsAmountShad;
    public int ShopAcessLevel;


    void Start()
    {
        PageIndex = 1;
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
