using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public int BuildingId;
    public GameObject HighLightedCube;
    public bool PointerOnUI = false;
    public GameObject UI;

    public GameObject RoadBuildings;
    public GameObject FieldBuildings;
    public GameObject GoldenBuildings;

    void Start()
    {
        
    }

    void Update()
    {
        if (HighLightedCube.GetComponent<BuilderManager>().CubeTypeIndex == 1)
        {
            Debug.Log("popo");
            FieldBuildings.SetActive(true);
            RoadBuildings.SetActive(true);
            GoldenBuildings.SetActive(false);
        }
        if (HighLightedCube.GetComponent<BuilderManager>().CubeTypeIndex == 2)
        {
            FieldBuildings.SetActive(false);
            RoadBuildings.SetActive(false);
            GoldenBuildings.SetActive(true);
        }
        if (HighLightedCube.GetComponent<BuilderManager>().CubeTypeIndex == 3)
        {
            FieldBuildings.SetActive(false);
            RoadBuildings.SetActive(true);
            GoldenBuildings.SetActive(false);
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerOnUI = true;
        }
        else
        {
            PointerOnUI = false; 
        }


    }
}
