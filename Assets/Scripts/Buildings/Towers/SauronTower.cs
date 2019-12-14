using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauronTower : MonoBehaviour
{
    public LineRenderer Renderer;
    public Transform EnemyPosition;
    public Transform FirePoint;
    public float Damage;
    public GameObject Enemy;
    public bool ray;
    public BuildingStats Stats;
    public float TowerAttackDistance;
    GlobalEnemiesManager globalEnemiesManager;



    void Start()
    {
        globalEnemiesManager = GameObject.Find("GlobalEnemiesManager").GetComponent<GlobalEnemiesManager>();
    }
    void FixedUpdate()
    {
        if (Enemy == null || globalEnemiesManager.IsEnemyAttackAble(Enemy, gameObject.transform.position, TowerAttackDistance) == false || Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
        {
            StopRay();
            Enemy = globalEnemiesManager.EnemyToAttack(gameObject.transform.position, TowerAttackDistance);
        }
        else
        {
            EnemyPosition = Enemy.transform;
            MakeRay();
        }
     }
    
    void MakeRay()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        Renderer.SetPosition(0, FirePoint.position);
        Renderer.SetPosition(1, EnemyPosition.position);
        Enemy.GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.MagicDamage);
    }
    void StopRay()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;
        Renderer.SetPosition(0, FirePoint.position);
        Renderer.SetPosition(1, FirePoint.position);
    }
}
