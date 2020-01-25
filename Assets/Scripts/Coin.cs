using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinCost;
    public bool IsTutorial;
    ResourcesManager resourcesManager;
    public MineScript Mine;


    void Start()
    {
        resourcesManager = LinksContainer.instance.resourcesManager;
    }

    public void TakeCoin()
    {
        if (IsTutorial == true)
        {
            GameObject.Find("TutorialManager").GetComponent<TutorialManager>().StartCoroutine("GoldenCoinTook");
        }
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("CoinIsTaken", true);
        AddCoinsToResourcesManager();
        Mine.StartCoroutine("GoldProduce");
        gameObject.GetComponent<AudioSource>().Play();
    }
    void AddCoinsToResourcesManager()
    {
        resourcesManager.Gold = resourcesManager.Gold + CoinCost;
        enabled = false;
    }
}
