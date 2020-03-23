using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List<GameObject>();
    public bool Frozen;
    public ParticleSystem Particle;
    public GlobalEnemiesManager globalEnemiesManager;
    public float RangeOfExplosion;
    public ShopProductsScriptableObject Shop;
    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        if (Shop.GetProductPurchaseState("SuperMine") == true)
        {
            gameObject.GetComponent<BoxCollider>().size = gameObject.GetComponent<BoxCollider>().size * 2;
        }
    }

    void Update()
    {
        AttackGoals = globalEnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfExplosion);
    }

    public void Explose(float Damage)
    {
        gameObject.GetComponent<AudioSource>().Play();
        Particle.Play();
        for (int q = 0; q < AttackGoals.Count; q++)
        {
            if (AttackGoals[q] != null)
            {
                if (Frozen == false)
                    AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
                else
                {
                    if (Shop.GetProductPurchaseState("FullFreeze") == true)
                    {
                        AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.FreezingEffect, 0, 7);
                        AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
                    }
                    else
                    {
                        AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.FreezingEffect, 0.4f, 20);
                        AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
                    }
                }
            }
        }
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BuildingStats>().FilledCube.GetComponent<BuilderManager>().BuildingFiled = -1;
        Destroy(gameObject, 1f);

    }

}
