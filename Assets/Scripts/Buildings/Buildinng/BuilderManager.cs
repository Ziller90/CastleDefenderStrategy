using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{
    public GameObject[] Buildings;
    public GameObject HighLightFrame;
    private GameObject Frame;
    public GameObject HighlightFramepoint;
    private bool AlwaysCreated = false;
    public Transform BuildPoint;
    public BuildingManager BuildingManager;
    public int BuildingFiled = -1;
    public bool MouseOver = false;
    public ResourcesManager ResourcesManager;
    public int CubeTypeIndex;
    public GameObject ListOfBuildings;
    public bool BuildAbility;
    public bool HaveDeliteAbleObject;
    public GameObject DeliteAbleObject;
    public bool IsHighLighted;
    void Start()
    {
        BuildingManager = LinksContainer.instance.buildingManager;
        ResourcesManager = LinksContainer.instance.resourcesManager;
        if (CubeTypeIndex == 2 || CubeTypeIndex == 1)
        {
            Buildings = BuildingManager.BuildingsForField.Buildings;
        }
        if (CubeTypeIndex == 3)
        {
            Buildings = BuildingManager.BuildingsForWay.Buildings;
        }
    }

    // Update is called once per frame

    public void CubeHighLighting ()
    {
        if (BuildAbility == true)
        {
            IsHighLighted = true;
            BuildingManager.HighLightedCube = gameObject;
            Frame = Instantiate(HighLightFrame, HighlightFramepoint.transform.position, Quaternion.identity);
        }
    }
    public void CubeRemoveHightLighting()
    {
        IsHighLighted = false;
        Destroy(Frame);
    }
    public void BuildTheBuilding (int BuildingId, int GoldPrice)
    {
        if (BuildingFiled < 0 && ResourcesManager.Gold >= GoldPrice)
        {
            if (BuildingId == 2 && CubeTypeIndex == 2)
            {
                StandartBuilding(BuildingId, GoldPrice);
            }
            if (BuildingId != 2 && CubeTypeIndex == 2)
            {
                StandartBuilding(BuildingId, GoldPrice);
            }
            if (CubeTypeIndex != 2) 
            {
                StandartBuilding(BuildingId, GoldPrice);
            }
            if (HaveDeliteAbleObject == true)
            {
                DeliteDecoration();
            }
        }

    }
    public void StandartBuilding (int BuildingId, int GoldPrice)
    {
        ResourcesManager.Gold = ResourcesManager.Gold - GoldPrice;
        GameObject NewBuilding = Instantiate(Buildings[BuildingId], BuildPoint);
        NewBuilding.transform.rotation = Quaternion.Euler(0, 0, 0);
        BuildingFiled = BuildingId;

        NewBuilding.transform.parent = null;
        NewBuilding.GetComponent<BuildingStats>().FilledCube = gameObject;
    }
    public void DeliteDecoration ()
    {
        Destroy(DeliteAbleObject);
    }
}
