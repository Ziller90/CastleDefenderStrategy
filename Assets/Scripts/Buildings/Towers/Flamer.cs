using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamer : MonoBehaviour
{
    GlobalEnemiesManager EnemiesManager;
    public float RangeOfFlaming;
    public BuildingStats buildingStats;
    void Start()
    {
        EnemiesManager = LinksContainer.instance.globalEnemiesManager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
       List<GameObject> EnemieseToAttack = EnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfFlaming);
       for (int i = 0; i < EnemieseToAttack.Count; i++)
       {
            if (EnemieseToAttack[i].GetComponent<EnemyBehaviour>().Burning == false)
            {
                EnemieseToAttack[i].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.BurningEffect, buildingStats.EffectPower, buildingStats.EffectTime);
            }
            EnemieseToAttack[i].GetComponent<DamageReciever>().DamageResistance(buildingStats.Damage, CardScriptableObject.DamageType.MagicDamage);
       }
    }
}
