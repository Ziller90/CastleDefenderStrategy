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

    public int AmountOfLevels;

    public int[] LevelUpPrice;
    public float[] LevelUpDamageBonus;
    public float[] LevelUpAttackDistanceBonus;
    public float[] LevelUpReloadingSpeedBonus;
    public float[] LevelUpSpeedDeBuffBonus;

    public float GoldenDamageBonus;
    public float GoldenAttackDistanceBonus;
    public float GoldenReloadingSpeedBonus;
    public float GoldenSpeedDeBuffBonus;


}
