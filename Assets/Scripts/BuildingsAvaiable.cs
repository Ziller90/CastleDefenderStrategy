using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsAvaiable : MonoBehaviour
{
    public bool[] BuildingAvaiable;
    public ShopProductsScriptableObject Shop;


    void Start ()
    {
        if (PlayerStats.GameWasFinished == true)
        {
            for (int i = 0; i < BuildingAvaiable.Length; i++ )
            {
                BuildingAvaiable[i] = true;
            }
        }
        if (Shop.GetProductPurchaseState("Spikes") == true)
        {
            BuildingAvaiable[5] = true;
        }
        else
        {
            BuildingAvaiable[5] = false;
        }
    }
}
