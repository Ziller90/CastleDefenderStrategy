using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenTowerScript : MonoBehaviour
{
    public bool Reloaded = true;
    public Vector3 EnemyPosition;
    public Transform BulletSpawnPoint;
    public GameObject Bullet;
    public bool SeeTheEnemy;
    public GameObject NewBullet;
    public float TowerReloadingSpeed;
    public float TowerDamage;
    public float TowerAttackDistance;
    public BuildingStats Stats;
    public float EffectPower;
    public float EffectTime;
    GlobalEnemiesManager globalEnemiesManager;
    public GameObject Enemy;

    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
        EffectPower = Stats.EffectPower;
        EffectTime = Stats.EffectTime;
    }
    void Update()
    {
        if (Enemy == null || globalEnemiesManager.IsEnemyAttackAble(Enemy, gameObject.transform.position, TowerAttackDistance) == false || Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
        {
            Enemy = globalEnemiesManager.EnemyToAttack(gameObject.transform.position, TowerAttackDistance);
        }
        else
        {
            EnemyPosition = Enemy.transform.position;
            BulletInstantiate();
        }
    }
    void BulletInstantiate()
    {
        if (Reloaded == true)
        {
            NewBullet = Instantiate(Bullet, BulletSpawnPoint.transform);
            NewBullet.GetComponent<EffectBulletScript>().EnemyPosition = EnemyPosition;
            NewBullet.GetComponent<EffectBulletScript>().Damage = TowerDamage;
            NewBullet.GetComponent<EffectBulletScript>().EffectPower = EffectPower;
            NewBullet.GetComponent<EffectBulletScript>().EffectTime = EffectTime;
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