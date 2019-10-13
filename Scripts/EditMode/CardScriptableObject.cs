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
    public float[] LevelUpReloadingSpeedBonus;
    public int[] SellCost;

    public float[] LevelUpEffectTime;
    public float[] LevelUpEffectPower;

    public enum DamageType
    {
        PenetrationDamage, ExplosionDamage, MagicDamage
    }
    public enum EffectType
    {
        FreezingEffect, BurningEffect, PoisonEffect, None
    }
    public DamageType damageType;
    public EffectType effectType;

    public float GoldenDamageBonus;
    public float GoldenAttackDistanceBonus;
    public float GoldenReloadingSpeedBonus;
    public float GoldenSpeedDeBuffBonus;

}
