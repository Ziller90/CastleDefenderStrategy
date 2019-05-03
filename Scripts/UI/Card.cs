using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Card : MonoBehaviour
{
    
    public CardScriptableObject CardInfo;
    public Text GoldPrice;
    public Text WoodPrice;
    public RawImage BuildingImage;
    private int BuildingID;
    private BuildingManager BuildingManager;
    public Text BuildingDescription;
    public Text BuildingDamage;
    public Text BuildingAttackDistance;
    public Text BuildingName;
    void Start()
    {
        BuildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        BuildingID = CardInfo.BuildingId;
        GoldPrice.text = (" " + CardInfo.GoldPrice);
        BuildingImage.texture = CardInfo.BuildingImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCardClick()
    {
        var Builder = BuildingManager.HighLightedCube.GetComponent<BuilderManager>();
        Builder.BuildTheBuilding(BuildingID, CardInfo.GoldPrice);
    }
}
