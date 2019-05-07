using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : MonoBehaviour
{

    public CardScriptableObject BuildingCard;
    public GameUIManager UIManager;
    public ResourcesManager ResourceManager;
    public GameObject FilledCube;
    public int Currentlevel = 0;

    public float Damage;
    public float AttackDistance;
    public float ReloadingSpeed;
    public float SpeedDeBuff;
    bool HasGoldenBonus = false;
    void Start()
    {
        UIManager = GameObject.Find("GameUIManager").GetComponent<GameUIManager>();
        ResourceManager = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();

        Damage = BuildingCard.LevelUpDamageBonus[Currentlevel];
        AttackDistance = BuildingCard.LevelUpAttackDistanceBonus[Currentlevel];
        ReloadingSpeed = BuildingCard.LevelUpReloadingSpeedBonus[Currentlevel];
        SpeedDeBuff = BuildingCard.LevelUpSpeedDeBuffBonus[Currentlevel];
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
        UIManager.ShowBuidlingButtons();
    }
    public void BuildingHighLightRemove()
    {
        UIManager.HideBuildingButtons();

    }

    public void LevelUP ()
    {
       if (BuildingCard.AmountOfLevels >= Currentlevel + 1)
        {
            if (ResourceManager.Gold >= BuildingCard.LevelUpPrice[Currentlevel + 1])
            {
                Debug.Log("I Work cool");
                Currentlevel++;
                ResourceManager.Gold = ResourceManager.Gold - BuildingCard.LevelUpPrice[Currentlevel];
                Damage = Damage + BuildingCard.LevelUpDamageBonus[Currentlevel];
                AttackDistance = AttackDistance + BuildingCard.LevelUpAttackDistanceBonus[Currentlevel];
                ReloadingSpeed = ReloadingSpeed + BuildingCard.LevelUpReloadingSpeedBonus[Currentlevel];
                SpeedDeBuff = SpeedDeBuff + BuildingCard.LevelUpSpeedDeBuffBonus[Currentlevel];
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
        Debug.Log("GoldenBonuWork");
        Damage = Damage + BuildingCard.GoldenDamageBonus;
        AttackDistance = AttackDistance + BuildingCard.GoldenAttackDistanceBonus;
        ReloadingSpeed = ReloadingSpeed + BuildingCard.GoldenReloadingSpeedBonus;
        SpeedDeBuff = SpeedDeBuff + BuildingCard.GoldenSpeedDeBuffBonus;

    }
}
