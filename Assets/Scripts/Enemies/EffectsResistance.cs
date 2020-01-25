using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsResistance : MonoBehaviour
{
    EnemyBehaviour Enemy;
    public Animator FrozenEffectAnimator;
    public ParticleSystem FireParticles;
    public GameObject FrozenSpikes;
    float LastFreezingTime;
    float LastBurningTime;
    float LastPoisonEffectTime;
    float FreezingTime;
    float BurningTime;
    float PoisonTime;


    public float FreezingEffectModificator;
    public float BurningEffectModificator;
    public float PoisonEffectModificator;
    bool FullFreeze;


    void Start()
    {
        FrozenEffectAnimator.gameObject.SetActive(false);
        Enemy = gameObject.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LastFreezingTime  != 0 && Time.time - LastFreezingTime > FreezingTime)
        {
            FreezingEffectStop();
        }
        if (LastPoisonEffectTime != 0 && Time.time - LastPoisonEffectTime > PoisonTime)
        {
            Enemy.Poisoned = false;
        }
        if (LastBurningTime != 0 && Time.time - LastBurningTime > BurningTime)
        {
            StopBurning();
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
            EffectPower = EffectPower * BurningEffectModificator;
            EffectTime = EffectTime * BurningEffectModificator;
            BurningEffect(EffectPower, EffectTime);
        }
        if (EffectType == CardScriptableObject.EffectType.PoisonEffect)
        {
            EffectPower = EffectPower * PoisonEffectModificator;
            EffectTime = EffectTime * PoisonEffectModificator;
            PoisonEffect(EffectPower, EffectTime);
        }
    }
    public void FreezingEffect (float SpeedDeBuff, float EffectTime)
    {
        if (FreezingEffectModificator == 0)
        {
            return;
        }
        if (SpeedDeBuff > 0 && FullFreeze == false)
        {
            FrozenSpikes.SetActive(true);
            FrozenEffectAnimator.gameObject.SetActive(true);
            FrozenEffectAnimator.SetBool("Freezed", true);
            Enemy.speed = Enemy.NormalSpeed * SpeedDeBuff;
            LastFreezingTime = Time.time;
            FreezingTime = EffectTime;
        }
        if (SpeedDeBuff == 0)
        {
            Enemy.FullFreeezeEnable();
            FullFreeze = true;
            LastFreezingTime = Time.time;
            FreezingTime = EffectTime;
        }
    }
    public void FreezingEffectStop ()
    {
        if (FullFreeze == true)
        {
            Enemy.FullFreeezeDisable();
            FullFreeze = false;
        }
        Enemy.speed = Enemy.NormalSpeed;
        FrozenEffectAnimator.SetBool("Freezed", false);
    }

    public void PoisonEffect(float Damage, float EffectTime)
    {
        if (PoisonEffectModificator == 0)
        {
            return;
        }
        if (Enemy.Poisoned == false)
        {
            Enemy.Poisoned = true;
            Enemy.StartCoroutine("Poison", Damage);
            LastPoisonEffectTime = Time.time;
            PoisonTime = EffectTime;
        }
    }
    void BurningEffect(float Damage, float EffectTime)
    {
        if (BurningEffectModificator == 0)
        {
            return;
        }
        FireParticles.Play();
        Enemy.Burning = true;
        Enemy.StartCoroutine("Burn", Damage);
        LastBurningTime = Time.time;
        BurningTime = EffectTime;
    }
    void StopBurning()
    {
        FireParticles.Stop();
        Enemy.Burning = false;
    }
    public void DieEffects()
    {
        if (FrozenEffectAnimator.GetBool("Freezed") == true)
        {
            FrozenEffectAnimator.SetBool("Freezed", false);
        }
    }
}
