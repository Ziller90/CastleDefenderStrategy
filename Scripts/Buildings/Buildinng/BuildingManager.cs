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

    public BuilderManager Manager;
    void Start()
    {
        Manager = HighLightedCube.GetComponent<BuilderManager>();
    }

    public void ChangedHighLightedCube()
    {
        Manager = HighLightedCube.GetComponent<BuilderManager>();
        if (Manager.CubeTypeIndex == 1)
        {
            Debug.Log("popo");
            FieldBuildings.SetActive(true);
            RoadBuildings.SetActive(true);
            GoldenBuildings.SetActive(false);
        }
        if (Manager.CubeTypeIndex == 2)
        {
            FieldBuildings.SetActive(false);
            RoadBuildings.SetActive(false);
            GoldenBuildings.SetActive(true);
        }
        if (Manager.CubeTypeIndex == 3)
        {
            FieldBuildings.SetActive(false);
            RoadBuildings.SetActive(true);
            GoldenBuildings.SetActive(false);
        }
    }
    void Update ()
    {
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
