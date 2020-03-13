using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public ResourcesManager ResourceManager;
    public int MineResource;
    public float IncomeDelay;
    public int IncomeSize;
    public float GoldLeft;
    public GameObject GoldenCoin;
    public ShopProductsScriptableObject Shop;
    bool CoinEnabled;

    void Start()
    {
        if (Shop.GetProductPurchaseState("GoldFever") == true)
        {
            IncomeSize = IncomeSize + 3;
        }
        ResourceManager = LinksContainer.instance.resourcesManager;
        StartCoroutine("GoldProduce");
        GoldLeft = MineResource;
    }

    IEnumerator GoldProduce ()
    {
        yield return new WaitForSeconds(IncomeDelay);
        GameObject NewCoin = Instantiate(GoldenCoin, gameObject.transform.position, Quaternion.identity);
        Coin CoinManager = NewCoin.transform.GetChild(0).GetComponent<Coin>();
        CoinManager.CoinCost = IncomeSize;
        CoinManager.Mine = gameObject.GetComponent<MineScript>();
    }
    public void MomentaryGoldProduce()
    {
        GameObject NewCoin = Instantiate(GoldenCoin, gameObject.transform.position, Quaternion.identity);
        Coin CoinManager = NewCoin.transform.GetChild(0).GetComponent<Coin>();
        CoinManager.IsTutorial = true;
        CoinManager.CoinCost = IncomeSize;
        CoinManager.Mine = gameObject.GetComponent<MineScript>();
    }
}
