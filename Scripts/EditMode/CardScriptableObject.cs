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
    public string BuildingDescription;
    public string BuildingDamage;
    public string BuildingAttackDistance;
    public string BuildingName;

    public int Levelup2Price;
    public float Levelup2DamageBonus;
    public float Levelup2DistanceBonus;

    public int Levelup3Price;
    public float Levelup3DDamageBonus;
    public float Levelup3DistanceBonus;
}
