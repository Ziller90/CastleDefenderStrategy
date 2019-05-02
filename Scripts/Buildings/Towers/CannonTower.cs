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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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