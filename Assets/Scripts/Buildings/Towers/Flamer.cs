using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamer : MonoBehaviour
{
    GlobalEnemiesManager EnemiesManager;
    public float RangeOfFlaming;
    void Start()
    {
        EnemiesManager = LinksContainer.instance.globalEnemiesManager;
    }

    // Update is called once per frame
    void Update()
    {
       List<GameObject> EnemieseToAttack = EnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfFlaming);
       for (int i = 0; i < EnemieseToAttack.Count; i++)
       { 
            EnemieseToAttack[i].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.BurningEffect, 0.05f, 10f);
            EnemieseToAttack[i].GetComponent<DamageReciever>().DamageResistance(0.01f, CardScriptableObject.DamageType.MagicDamage);
       }
    }
}
