using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public ResourcesManager ResourceManager;
    public int MineResource;
    void Start()
    {
        ResourceManager = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();
        StartCoroutine("GoldProduce");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GoldProduce ()
    {
        for (int i = 0; i < MineResource; i++)
        {
            yield return new WaitForSeconds(0.3f);
            ResourceManager.Gold++;

        }

    }
}
