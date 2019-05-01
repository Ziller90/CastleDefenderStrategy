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
    public int TowerDamage;
    public GameObject Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay (Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            EnemyPosition = Col.gameObject.transform;
            ArrowInstantiate();
        }
    }
    void ArrowInstantiate ()
    {
        if (Reloaded == true)
        {
            NewArrow = Instantiate(Arrow, ArrowSpawnPoint.transform);
            NewArrow.GetComponent<ArrowScript>().EnemyPosition = EnemyPosition;
            NewArrow.GetComponent<ArrowScript>().ArrowSpawnPoint = ArrowSpawnPoint;
            NewArrow.GetComponent<Damager>().Damage = TowerDamage;
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
