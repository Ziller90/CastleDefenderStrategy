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
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Damage = Stats.Damage;
        if (Enemy == null)
        {
            StopRay();
        }
        if (ray == true && Enemy != null)
        {
            Renderer.SetPosition(0, FirePoint.position);
            Renderer.SetPosition(1, EnemyPosition.position);
            Enemy.GetComponent<EnemyBehaviour>().HP = Enemy.GetComponent<EnemyBehaviour>().HP - Damage;
        }
 
    }
    void OnTriggerStay(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            if (Enemy == null)
            {
                Enemy = Col.gameObject;
            }
            EnemyPosition = Enemy.transform;
            ray = true;
        }
    }
    void OnTriggerExit (Collider col)
    {
        StopRay();
        ray = false;
    }

    void Ray ()
    {

        Renderer.SetPosition(0, FirePoint.position);
        Renderer.SetPosition(1, EnemyPosition.position);
        Enemy.GetComponent<EnemyBehaviour>().HP = Enemy.GetComponent<EnemyBehaviour>().HP - Damage;
    }

    void StopRay()
    {
        Renderer.SetPosition(0, FirePoint.position);
        Renderer.SetPosition(1, FirePoint.position);
    }
}
