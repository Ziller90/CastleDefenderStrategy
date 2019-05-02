using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Transform EnemyPosition;
    public float ArrowPosition;
    public float Speed;
    public Transform ArrowSpawnPoint;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        gameObject.transform.LookAt(EnemyPosition);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
