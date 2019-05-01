using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardScriptableObject : ScriptableObject
{
    public Texture BuildingImage;
    public int  GoldPrice;
    public int BuildingId;

}
