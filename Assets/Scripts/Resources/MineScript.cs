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
    bool CoinEnabled;

    void Start()
    {
        if (ShopManager.GoldFever == true)
        {
            IncomeDelay++;
            IncomeSize = IncomeSize + 2;
        }
        ResourceManager = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();
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
}
