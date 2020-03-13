using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Product : MonoBehaviour
{
    public ShopProductsScriptableObject shopProductsScriptableObject;
    public ProductInfoScriptableObject productInfoScriptableObject;
    public Text Name;
    public Text Description;
    public Text DescriptionShadow;
    public Image Image;
    public int Price;
    public Text PriceText;
    public Button BuyButton;
    public GameObject SoldOut;
    public AudioSource Bought;
    void Awake()
    {
        if (Application.isPlaying == true)
        {
            Name.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementName;
            Description.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementDescription;
            DescriptionShadow.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementDescription;
            Image.sprite = productInfoScriptableObject.ImprovementImage;
            Price = productInfoScriptableObject.Price;
            PriceText.text = Price.ToString();
        }
    }

    void Start()
    {
        if (Application.isPlaying == true)
        {
            if (shopProductsScriptableObject.GetProductPurchaseState(productInfoScriptableObject.ID) == true)
            {
                Debug.Log(shopProductsScriptableObject.GetProductPurchaseState(productInfoScriptableObject.ID) + " ");
                BuyButton.interactable = false;
                SoldOut.SetActive(true);
            }
            BuyButton.onClick.AddListener(BuyProduct);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying == false)
        {
            Name.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementName;
            Description.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementDescription;
            DescriptionShadow.GetComponent<LanguageText>().Translation = productInfoScriptableObject.ImprovementDescription;
            Image.sprite = productInfoScriptableObject.ImprovementImage;
            Price = productInfoScriptableObject.Price;
            PriceText.text = Price.ToString();
        }
    }


    public void BuyProduct()
    {
        if (PlayerStats.Crystals - Price >= 0)
        {
            Bought.Play();
            PlayerStats.Crystals = PlayerStats.Crystals - Price;
            shopProductsScriptableObject.NewPurchase(productInfoScriptableObject.ID);
            BuyButton.interactable = false;
            SoldOut.SetActive(true);
            BuyButton.onClick.RemoveAllListeners();
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
    }
}
    




