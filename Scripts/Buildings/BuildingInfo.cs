using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public GameObject BuildingInfoPanel;
    public GameObject ListOfBuildings;
    public CardScriptableObject BuildingCard;
    public BuildingInfoPanel Panel;
    void Start()
    {
        BuildingInfoPanel = GameObject.Find("BuildingInfo");
        ListOfBuildings = GameObject.Find("ListOfBuildings");
        Panel = BuildingInfoPanel.GetComponent<BuildingInfoPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InfoHide()
    {
        ListOfBuildings.SetActive(true);

    }
    public void InfoShowing ()
    {
        BuildingInfoPanel.SetActive(true);
        ListOfBuildings.SetActive(false);
        Panel.BuildingName.text = BuildingCard.BuildingName;
        Panel.BuildingImage.texture = BuildingCard.BuildingImage;
        Panel.BuildingDescription.text = BuildingCard.BuildingDescription;
        Panel.BuildingDamage.text  = "Damage: " + BuildingCard.BuildingDamage;
        Panel.BuildingAttackDistance.text = "Attack Distance: " + BuildingCard.BuildingAttackDistance;
    }
}
