using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewProductsList", menuName = "ProductsList")]

public class ShopProductsScriptableObject : ScriptableObject
{
    public List<ProductInfoScriptableObject> ProductsList = new List<ProductInfoScriptableObject>();
    void Start()
    {

    }
    public static Purchases purchases = new Purchases();
    [System.Serializable]
    public class Purchases
    {
        public List<string> BoughtProducts = new List<string>();
    }
    // Update is called once per frame
    void Update()
    {

    } 
    public void NewPurchase(string ProductId)
    {
        purchases.BoughtProducts.Add(ProductId);
    }
    public bool GetProductPurchaseState(string ProductId)
    {
        for (int i = 0; i < purchases.BoughtProducts.Count; i++)
        {
            if (purchases.BoughtProducts[i] == ProductId)
            {
                return true;
            }
        }
        return false;
    } 
}
