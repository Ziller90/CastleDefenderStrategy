using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : MonoBehaviour
{

    public CardScriptableObject BuildingCard;
    public GameUIManager UIManager;
    public ResourcesManager ResourceManager;
    public int ImprovingsAvaiableLevel;
    public GameObject FilledCube;
    public int Currentlevel = 0;
    public GameObject AttackZone;

    public float Damage;
    public float ReloadingSpeed;
    public CardScriptableObject.DamageType DamageType;
    public CardScriptableObject.EffectType EffectType;
    public float EffectTime;
    public float EffectPower;


    bool HasGoldenBonus = false;
    void Start()
    {
        ImprovingsAvaiableLevel = LinksContainer.instance.Level.GetComponent<ImprovingsLevelsAvaiable>().ImprovingsAvaiableLevel;
        UIManager = LinksContainer.instance.UIManager;
        ResourceManager = LinksContainer.instance.resourcesManager;
        Damage = BuildingCard.LevelUpDamageBonus[Currentlevel];
        ReloadingSpeed = BuildingCard.LevelUpReloadingSpeedBonus[Currentlevel];
        DamageType = BuildingCard.damageType;
        EffectType = BuildingCard.effectType;
        EffectPower = BuildingCard.LevelUpEffectPower[Currentlevel];
        EffectTime = BuildingCard.LevelUpEffectTime[Currentlevel];
    }

    // Update is called once per frame
    void Update()
    {
        if (FilledCube.GetComponent<BuilderManager>().CubeTypeIndex == 2 && HasGoldenBonus == false)
        {
            GoldenBonus();
            HasGoldenBonus = true;
        }
    }
    public void BuildingIsHignLighted ()
    {
        UIManager.BuildingToImprove = gameObject.GetComponent<BuildingStats>();
        UIManager.ShowDestroyButton();
        if (ImprovingsAvaiableLevel != 0)
        {
            UIManager.ShowImproveButton();
        }
        AttackZone.SetActive(true);
    }
    public void BuildingHighLightRemove()
    {
        Debug.Log("Hide");
        UIManager.HideDestroyButton();
        UIManager.HideImproveButton();
        AttackZone.SetActive(false);

    }

    public void LevelUP ()
    {
       if (BuildingCard.AmountOfLevels >= Currentlevel + 1)
        {
            if (ResourceManager.Gold >= BuildingCard.LevelUpPrice[Currentlevel + 1])
            {
                Currentlevel++;
                ResourceManager.Gold = ResourceManager.Gold - BuildingCard.LevelUpPrice[Currentlevel];
                Damage = Damage + BuildingCard.LevelUpDamageBonus[Currentlevel];
                ReloadingSpeed = ReloadingSpeed + BuildingCard.LevelUpReloadingSpeedBonus[Currentlevel];
                EffectPower = EffectPower + BuildingCard.LevelUpEffectPower[Currentlevel];
                EffectTime = EffectTime + BuildingCard.LevelUpEffectTime[Currentlevel];
            }
        }
        

    }
    public void Destroy ()
    {
        Destroy(gameObject);
        FilledCube.GetComponent<BuilderManager>().BuildingFiled = -1;
    }
    public void GoldenBonus ()
    {
        Damage = Damage + BuildingCard.GoldenDamageBonus;
        ReloadingSpeed = ReloadingSpeed + BuildingCard.GoldenReloadingSpeedBonus;
    }
    
}
