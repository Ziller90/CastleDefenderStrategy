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
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
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
            EnemyPosition = Enemy.transform;
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
            NewPoison.GetComponent<PlagueBullet>().EnemyPosition = new Vector3(EnemyPosition.position.x, 0, EnemyPosition.position.z);
            NewPoison.GetComponent<PlagueBullet>().Damage = TowerDamage;
            NewPoison.GetComponent<PlagueBullet>().EffectPower = EffectPower;
            NewPoison.GetComponent<PlagueBullet>().EffectTime = EffectTime;
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
