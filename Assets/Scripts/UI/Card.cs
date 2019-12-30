using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Card : MonoBehaviour
{
    
    public CardScriptableObject CardInfo;
    public int CardID;
    public Text GoldPrice;
    public Text WoodPrice;
    public RawImage BuildingImage;
    private int BuildingID;
    private BuildingManager BuildingManager;
    private ResourcesManager manager;
    void Start()
    {
        manager = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();
        if (LinksContainer.instance.Level.GetComponent<BuildingsAvaiable>().BuildingAvaiable[CardID] == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        BuildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        BuildingID = CardInfo.BuildingId;
        GoldPrice.text = (" " + CardInfo.GoldPrice);
        BuildingImage.texture = CardInfo.BuildingImage;

    }
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Gold < CardInfo.GoldPrice)
        {
            gameObject.GetComponent<Button>().interactable = false;
        } 
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
    public void OnCardClick()
    {
        var Builder = BuildingManager.HighLightedCube.GetComponent<BuilderManager>();
        Builder.BuildTheBuilding(BuildingID, CardInfo.GoldPrice);
    }
}
