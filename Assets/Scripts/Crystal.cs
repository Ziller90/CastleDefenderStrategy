using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int CrystalCost;
    public int SecondsToDisappear;
    ResourcesManager resourcesManager;

    void Start()
    {
        resourcesManager = LinksContainer.instance.resourcesManager;

    }

    public void TakeCoin()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("CoinIsTaken", true);
        gameObject.GetComponent<AudioSource>().Play();
        AddCrystalsToResourcesManager();
    }
    void AddCrystalsToResourcesManager()
    {
        PlayerStats.Crystals = PlayerStats.Crystals + CrystalCost;
        enabled = false;
    }
}
