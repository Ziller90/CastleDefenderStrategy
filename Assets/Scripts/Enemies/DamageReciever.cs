using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour
{
    public float MagicDamageModificator;
    public float PenetrationDamageModificator;
    public float ExplosionDamageModificator;
    public EnemyBehaviour Enemy;
    public float FinalDamage;
    public BloodVisualisation DamageVisual;



    void Start()
    {
        Enemy = gameObject.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame

    public void DamageResistance (float Damage, CardScriptableObject.DamageType damageType)
    {
        switch(damageType)
        {
            case (CardScriptableObject.DamageType.PenetrationDamage):
                DamageVisual.ShowParticles();
                FinalDamage = Damage * PenetrationDamageModificator;   break;
            case (CardScriptableObject.DamageType.ExplosionDamage):
                DamageVisual.ShowParticles();
                FinalDamage = Damage * ExplosionDamageModificator; break;
            case (CardScriptableObject.DamageType.MagicDamage):
                DamageVisual.ShowParticles();
                FinalDamage = Damage * MagicDamageModificator; break;
        }
        RecieveDamage();
    }
    public void RecieveDamage ()
    {
        Enemy.HP -= FinalDamage;
    }

}
