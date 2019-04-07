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
    void Start()
    {
        BuildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (AlwaysCreated == false && BuildingManager.PointerOnUI == false) 
        {
            BuildingManager.HighLightedCube = gameObject;
            Frame = Instantiate(HighLightFrame, HighlightFramepoint.transform.position, Quaternion.identity);
        }
        AlwaysCreated = true;
    }
    void OnMouseExit()
    {
        Destroy(Frame);
        AlwaysCreated = false;

    }
  
    public void BuildTheBuilding (int BuildingId)
    {
        if (BuildingFiled < 0)
        {
            Debug.Log("Buided" + BuildingId);
            Instantiate(Buildings[BuildingId], BuildPoint);
            BuildingFiled = BuildingId;
        }
    }
}
