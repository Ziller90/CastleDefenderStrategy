using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsResistance : MonoBehaviour
{
    EnemyBehaviour Enemy;
    float LastFreezingTime;
    float LastBurningTime;
    float LastPoisonEffectTime;
    float FreezingTime;
    float BurningTime;
    float PoisonTime;

    public float FreezingEffectModificator;
    public float BurningEffectModificator;
    public float PoisonEffectModificator;



    void Start()
    {
        Enemy = gameObject.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LastFreezingTime  != 0 && Time.time - LastFreezingTime > FreezingTime)
        {
            FreezingEffectStop();
        }
    }
    public void EffectCast(CardScriptableObject.EffectType EffectType, float EffectPower, float EffectTime)
    {
        if (EffectType == CardScriptableObject.EffectType.FreezingEffect)
        {
            EffectPower = EffectPower * FreezingEffectModificator;
            EffectTime = EffectTime * FreezingEffectModificator;

            FreezingEffect(EffectPower, EffectTime);
        }
        if (EffectType == CardScriptableObject.EffectType.BurningEffect)
        {

        }
        if (EffectType == CardScriptableObject.EffectType.PoisonEffect)
        {

        }
    }
    public void FreezingEffect (float SpeedDeBuff, float EffectTime)
    {
        Enemy.speed = Enemy.NormalSpeed * SpeedDeBuff;
        Enemy.EnemyAnimator.SetFloat("Speed", SpeedDeBuff);
        LastFreezingTime = Time.time;
        FreezingTime = EffectTime;
    }
    public void FreezingEffectStop ()
    {
        Enemy.speed = Enemy.NormalSpeed;
        Enemy.EnemyAnimator.SetFloat("Speed", 1);
    }
}
