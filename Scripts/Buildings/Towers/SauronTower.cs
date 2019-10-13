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
        if (Enemy != null)
        {
            if (Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
            {
                StopRay();
            }
        }
        if (Enemy != null)
        {
            if (ray == true && Enemy.GetComponent<EnemyBehaviour>().HP > 0)
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                Renderer.SetPosition(0, FirePoint.position);
                Renderer.SetPosition(1, EnemyPosition.position);
                Enemy.GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.MagicDamage);
            }
        }
    }
    void OnTriggerStay(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            if (Enemy != null)
            {
                if (Enemy.GetComponent<EnemyBehaviour>().HP <= 0)
                {
                    Enemy = Col.gameObject;
                    EnemyPosition = Enemy.transform;
                    ray = true;
                }
            }
            else
            {
                Enemy = Col.gameObject;
                EnemyPosition = Enemy.transform;
                ray = true;
            }
        }
    }
    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            StopRay();
            ray = false;
            Enemy = null;
        }
    }

    void StopRay()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;

        Renderer.SetPosition(0, FirePoint.position);
        Renderer.SetPosition(1, FirePoint.position);
    }
}
