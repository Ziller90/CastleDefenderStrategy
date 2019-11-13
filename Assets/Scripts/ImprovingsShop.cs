using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ImprovingsShop : MonoBehaviour
{
    public int StartCapitalCost = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShopQuit ()
    {
        SceneManager.LoadScene(0);
    }

    public void StartCapital ()
    {
        if (PlayerStats.Crystals >= StartCapitalCost)
        {
            PlayerStats.Crystals -= StartCapitalCost;
            PlayerStats.StartCapitalOpened = true;
            Debug.Log(PlayerStats.StartCapitalOpened);
        }
        else
        {
            Debug.Log(PlayerStats.StartCapitalOpened);
        }
    }
}
