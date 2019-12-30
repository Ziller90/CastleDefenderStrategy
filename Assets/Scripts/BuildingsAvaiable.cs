using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsAvaiable : MonoBehaviour
{
    public bool[] BuildingAvaiable;

    void Start ()
    {
        if (ShopManager.Spikes == true)
        {
            BuildingAvaiable[5] = true;
        }
    }
}
