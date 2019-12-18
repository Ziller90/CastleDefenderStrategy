using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinCost;
    ResourcesManager resourcesManager;
    public MineScript Mine;

    void Start()
    {
        resourcesManager = LinksContainer.instance.resourcesManager;
    }

    public void TakeCoin()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("CoinIsTaken", true);
        AddCoinsToResourcesManager();
        Mine.StartCoroutine("GoldProduce");
    }
    void AddCoinsToResourcesManager()
    {
        resourcesManager.Gold = resourcesManager.Gold + CoinCost;
        enabled = false;
    }
}
