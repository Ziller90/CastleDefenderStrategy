using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
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
    public Transform Rotator;
    public Transform Barrel;
    GlobalEnemiesManager globalEnemiesManager;
    public int RotationSpeedOfRotator;
    public int RotationSpeedOfBarrel;
    public ParticleSystem Fire;
    bool Flaming;
    int CountToStopFire;
    public GameObject Flamer;


    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        Flamer.SetActive(false);
    }
    void Update()
    {
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
        if (Enemy == null || globalEnemiesManager.IsEnemyAttackAble(Enemy, gameObject.transform.position, TowerAttackDistance) == false || Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
        {
            if (CountToStopFire == 100)
            {
                Flaming = false;
                StartCoroutine("FlameOff");
                CountToStopFire = 0;

            }
            else
            {
                CountToStopFire++; 
            }
           
            Enemy = globalEnemiesManager.EnemyToAttack(gameObject.transform.position, TowerAttackDistance);
        }
        else
        {
            CountToStopFire = 0;
            EnemyPosition = Enemy.transform.position;
            Vector3 EnemyPositionProjection = new Vector3(EnemyPosition.x, Rotator.position.y, EnemyPosition.z);
            Quaternion RotateToEnemy = Quaternion.LookRotation(Rotator.position - EnemyPositionProjection);
            Rotator.rotation = Quaternion.RotateTowards(Rotator.rotation, RotateToEnemy, Time.deltaTime * RotationSpeedOfRotator);

            Vector3 EnemyPositionProjection2 = new Vector3(EnemyPosition.x, EnemyPosition.y, EnemyPosition.z);
            Quaternion RotateToEnemy2 = Quaternion.LookRotation(Barrel.position - EnemyPositionProjection2);
            Quaternion EulerRotation = Quaternion.Euler(RotateToEnemy2.x * 100, 0, 0);

            Barrel.localRotation = Quaternion.RotateTowards(Barrel.localRotation, EulerRotation, Time.deltaTime * RotationSpeedOfBarrel);
            if (Flaming == false)
            {
                StartCoroutine("FlameOn");
                Flaming = true;
            }
        }
    }
    IEnumerator FlameOn()
    {
        yield return new WaitForSeconds(1);
        Fire.Play();
        yield return new WaitForSeconds(0.5f);
        Flamer.SetActive(true);
    }
    IEnumerator FlameOff()
    {
        yield return new WaitForSeconds(0.1f);
        Flamer.SetActive(false);
        Fire.Stop();
    }
}
