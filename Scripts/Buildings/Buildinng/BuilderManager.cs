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
    void Start()
    {
        BuildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        ResourcesManager = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (AlwaysCreated == false && BuildingManager.PointerOnUI == false && MouseOver == true)
            {
                BuildingManager.HighLightedCube = gameObject;
                Frame = Instantiate(HighLightFrame, HighlightFramepoint.transform.position, Quaternion.identity);
            }
            AlwaysCreated = true;
        }
    }

    public void CubeHighLighting ()
    {
        BuildingManager.HighLightedCube = gameObject;
        Frame = Instantiate(HighLightFrame, HighlightFramepoint.transform.position, Quaternion.identity);
    }
    public void CubeRemoveHightLighting()
    {
        Destroy(Frame);
    }
    public void BuildTheBuilding (int BuildingId, int GoldPrice)
    {
        if (BuildingFiled < 0 && ResourcesManager.Gold >= GoldPrice)
        {
            if (BuildingId == 2 && CubeTypeIndex == 2)
            {
                ResourcesManager.Gold = ResourcesManager.Gold - GoldPrice;
                Debug.Log("Buided" + BuildingId);
                GameObject NewBuilding = Instantiate(Buildings[BuildingId], BuildPoint);
                BuildingFiled = BuildingId;
                NewBuilding.transform.parent = null;
            }
            if (BuildingId == 2 && CubeTypeIndex != 2)
            {
 
            }
            if (BuildingId != 2) 
            {
                ResourcesManager.Gold = ResourcesManager.Gold - GoldPrice;
                Debug.Log("Buided" + BuildingId);
                GameObject NewBuilding = Instantiate(Buildings[BuildingId], BuildPoint);
                BuildingFiled = BuildingId;
                NewBuilding.transform.parent = null;
            }
        }
    }
}
