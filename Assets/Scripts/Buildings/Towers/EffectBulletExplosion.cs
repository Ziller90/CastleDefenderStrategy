using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List <GameObject>();
    int i = 0;
    public CardScriptableObject.EffectType EffectType;
    public GlobalEnemiesManager globalEnemiesManager;
    public float RangeOfExplosion;
    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
    }

    public void Explose (float Damage, float EffectPower, float EffectTime)
    {
        gameObject.GetComponent<AudioSource>().Play();
        AttackGoals = globalEnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfExplosion);
        for (int q = 0; q < AttackGoals.Count; q++)
        {
            AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
            if (EffectType == CardScriptableObject.EffectType.FreezingEffect)
            AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.FreezingEffect, EffectPower, EffectTime);
            if (EffectType == CardScriptableObject.EffectType.PoisonEffect)
                AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.PoisonEffect, EffectPower, EffectTime);
            if (EffectType == CardScriptableObject.EffectType.BurningEffect)
                AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.BurningEffect, EffectPower, EffectTime);
        }
    }
}
