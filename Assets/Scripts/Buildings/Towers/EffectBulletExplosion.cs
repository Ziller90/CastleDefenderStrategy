using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List <GameObject>();
    int i = 0;
    public CardScriptableObject.EffectType EffectType;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
             AttackGoals.Add(col.gameObject);
        }
    }
    public void Explose (float Damage, float EffectPower, float EffectTime)
    {
        gameObject.GetComponent<AudioSource>().Play();
        for(int q = 0; q < AttackGoals.Count; q++)
        {
            Debug.Log("ofof");
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
