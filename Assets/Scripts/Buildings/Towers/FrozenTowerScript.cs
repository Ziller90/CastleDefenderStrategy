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
    public BuildingStats Stats;
    public float EffectPower;
    public float EffectTime;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
        EffectPower = Stats.EffectPower;
        EffectTime = Stats.EffectTime;


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