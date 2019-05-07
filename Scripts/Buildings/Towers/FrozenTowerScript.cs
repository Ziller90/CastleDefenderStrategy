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
    public float TowerSpeedDeBuff;
    public float TowerAttackDistance;
    public BuildingStats Stats;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
        TowerAttackDistance = Stats.AttackDistance;
        TowerSpeedDeBuff = Stats.SpeedDeBuff;
    }
    void OnTriggerStay(Collider Col)
    {

        if (Col.gameObject.tag == "Enemy")
        {
            EnemyPosition = Col.gameObject.transform.position;
            BulletInstantiate();
        }

    }
    void BulletInstantiate()
    {
        if (Reloaded == true)
        {

            NewBullet = Instantiate(Bullet, BulletSpawnPoint.transform);
            NewBullet.GetComponent<FrozenBulletScript>().EnemyPosition = EnemyPosition;
            NewBullet.GetComponent<FrozenBulletScript>().Damage = TowerDamage;
            NewBullet.GetComponent<FrozenBulletScript>().SpeedDeBuff = TowerSpeedDeBuff;
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