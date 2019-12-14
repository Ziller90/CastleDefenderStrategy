using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTower : MonoBehaviour
{
    public bool Reloaded = true;
    public Transform EnemyPosition;
    public Transform PoisonSpawnPoint;
    public GameObject Poison;
    public bool SeeTheEnemy;
    public GameObject NewPoison;
    public float TowerReloadingSpeed;
    public float TowerDamage;
    public float TowerAttackDistance;
    public GameObject Enemy;
    public BuildingStats Stats;
    public float EffectPower;
    public float EffectTime;
    GlobalEnemiesManager globalEnemiesManager;
    void Start()
    {
        globalEnemiesManager = GameObject.Find("GlobalEnemiesManager").GetComponent<GlobalEnemiesManager>();
        EffectPower = Stats.EffectPower;
        EffectTime = Stats.EffectTime;
    }

    // Update is called once per frame
    void Update()
    {
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
        if (Enemy == null || globalEnemiesManager.IsEnemyAttackAble(Enemy, gameObject.transform.position, TowerAttackDistance) == false || Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
        {
            Enemy = globalEnemiesManager.EnemyToAttack(gameObject.transform.position, TowerAttackDistance);
        }
        else
        {
            PoisonInstantiate();
        }

    }

    void PoisonInstantiate ()
    {
        if (Reloaded == true)
        {
            NewPoison = Instantiate(Poison, PoisonSpawnPoint.transform);
            NewPoison.GetComponent<EffectBulletScript>().EnemyPosition = Enemy.transform.position;
            NewPoison.GetComponent<EffectBulletScript>().Damage = TowerDamage;
            NewPoison.GetComponent<EffectBulletScript>().EffectPower = EffectPower;
            NewPoison.GetComponent<EffectBulletScript>().EffectTime = EffectTime;
            Reloaded = false;
            StartCoroutine("Reloading");
        }
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(TowerReloadingSpeed);
        Reloaded = true;
    }
}
