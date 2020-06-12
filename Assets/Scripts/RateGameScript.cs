using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RateGameScript : MonoBehaviour
{
    public Texture EmptyStar;
    public Texture Star;
    public RawImage[] StarsImages;
    void Start()
    {
        
    }
    void ActivateStars(int AmountOfStars)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i <= AmountOfStars)
                StarsImages[i].texture = Star;
            else
                StarsImages[i].texture = EmptyStar;
        }
    }
    public void Rate (int AmountOfStars)
    {
        ActivateStars(AmountOfStars);
    }
    public void GoToStore()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.Abuksigun.CastleDefenderStrategy");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.Abuksigun.CastleDefenderStrategy"); // Change it when the game is released on IOS
        }
        else
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.Abuksigun.CastleDefenderStrategy");
        }
    }
}
