using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ImprovingsShop : MonoBehaviour
{
    public int StartCapitalCost = 200;
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
        }
    }
}
