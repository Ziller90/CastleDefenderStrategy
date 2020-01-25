using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject Enemy;
    public Transform EnemyTransform;
    public float ArrowPosition;
    public float Speed;
    public float Damage;
    public Transform ArrowSpawnPoint;
    public GameObject FireParticles;
    public float MinimumDistance;
    void Start()
    {
        EnemyTransform = Enemy.transform;
        if (ShopManager.BurningArrows == true)
        {
            FireParticles.SetActive(true);
        }
        StartCoroutine("Look");
    }

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        if (Vector3.Distance(gameObject.transform.position, EnemyTransform.position) < MinimumDistance)
        {
            Enemy.GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.PenetrationDamage);
            if (ShopManager.BurningArrows == true)
            {
                Enemy.gameObject.GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.BurningEffect, 1.5f, 5);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator Look()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Enemy.GetComponent<EnemyBehaviour>().AlreadyDead == false)
            {
                yield return new WaitForSeconds(0.02f);
                gameObject.transform.LookAt(Enemy.transform.position);
            }
        }
    }
}