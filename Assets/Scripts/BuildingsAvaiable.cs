using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsAvaiable : MonoBehaviour
{
    public bool[] BuildingAvaiable;
    public ShopProductsScriptableObject Shop;


    void Start ()
    {
        if (Shop.GetProductPurchaseState("Spikes") == true)
        {
            BuildingAvaiable[5] = true;
        }
    }
}
