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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
