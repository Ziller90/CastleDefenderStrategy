using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject BuidlingImproveButton;
    public GameObject BuidlingDestroyButton;
    public BuildingStats BuildingToImprove;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowBuidlingButtons ()
    {
        BuidlingImproveButton.SetActive(true);
        BuidlingDestroyButton.SetActive(true);
    }
    public void HideBuildingButtons()
    {
        BuidlingImproveButton.SetActive(false);
        BuidlingDestroyButton.SetActive(false);
    }

    public void BuildingLevelUP ()
    {
        BuildingToImprove.LevelUP ();
    }
    public void BuildingDestroy()
    {
        HideBuildingButtons();
        BuildingToImprove.Destroy();
    }
}
