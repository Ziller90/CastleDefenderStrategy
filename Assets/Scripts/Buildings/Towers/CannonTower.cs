using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
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
    public GameObject Enemy;
    GlobalEnemiesManager globalEnemiesManager;

    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;

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
        TowerDamage = Stats.Damage;

        TowerReloadingSpeed = Stats.ReloadingSpeed;
    }

    void BulletInstantiate()
    {
        if (Reloaded == true)
        {
            NewBullet = Instantiate(Bullet, BulletSpawnPoint.transform);
            NewBullet.GetComponent<BulletScript>().EnemyPosition = EnemyPosition;
            NewBullet.GetComponent<BulletScript>().Damage = TowerDamage;
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