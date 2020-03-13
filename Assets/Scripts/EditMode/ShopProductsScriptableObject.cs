using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewProductsList", menuName = "ProductsList")]
public class ShopProductsScriptableObject : ScriptableObject
{
    public List<ProductInfoScriptableObject> ProductsList = new List<ProductInfoScriptableObject>();
    public static List<string> BoughtProducts = new List<string>();
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewPurchase(string ProductId)
    {
        BoughtProducts.Add(ProductId);
    }
    public bool GetProductPurchaseState(string ProductId)
    {
        for (int i = 0; i < BoughtProducts.Count; i++)
        {
            if (BoughtProducts[i] == ProductId)
            {
                return true;
            }
        }
        return false;
    } 
}
