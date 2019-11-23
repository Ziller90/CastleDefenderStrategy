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

    // Update is called once per frame
    IEnumerator GoldProduce ()
    {
        for (int i = 0; i < MineResource; i++)
        {
            yield return new WaitForSeconds(IncomeDelay);
            ResourceManager.Gold += IncomeSize;
            GoldLeft -= IncomeSize;
        }

    }
}
