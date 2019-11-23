using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchersTower : MonoBehaviour
{
    public bool Reloaded = true;
    public Transform EnemyPosition;
    public Transform ArrowSpawnPoint;
    public GameObject Arrow;
    public bool SeeTheEnemy;
    public GameObject NewArrow;
    public float TowerReloadingSpeed;
    public float TowerDamage;
    public float TowerAttackDistance;
    public GameObject Enemy;
    public BuildingStats Stats;
     

    // Update is called once per frame
    void Update()
    {
        TowerDamage = Stats.Damage;
        TowerReloadingSpeed = Stats.ReloadingSpeed;
    }
    void OnTriggerStay (Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            Enemy = Col.gameObject;
            ArrowInstantiate();
        }
    }

    void ArrowInstantiate ()
    {
        if (Reloaded == true)
        {
            NewArrow = Instantiate(Arrow, ArrowSpawnPoint.transform);
            NewArrow.GetComponent<ArrowScript>().Enemy = Enemy;
            NewArrow.GetComponent<ArrowScript>().ArrowSpawnPoint = ArrowSpawnPoint;
            NewArrow.GetComponent<ArrowScript>().Damage = TowerDamage;

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
