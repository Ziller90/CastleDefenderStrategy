using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    public int Gold;
    public Text GoldText;
    public Text CrystlasText;
    public Animator CoinAnimator;
    public Animator CrystalsAnimator;


    int OldGold;
    int OldCrystals;



     

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Crystals > 9999)
        {
            PlayerStats.Crystals = 9999;
        }
        if (PlayerStats.Crystals - OldCrystals > 0)
        {
            CrystalsAnimator.SetTrigger("MoreCoins");
        }
        OldCrystals = PlayerStats.Crystals;

        if (Gold - OldGold  > 0)
        {
            CoinAnimator.SetTrigger("MoreCoins");
        }
        OldGold = Gold;

        CrystlasText.text = "" + PlayerStats.Crystals;
        GoldText.text = "" + Gold;
    }
}
