using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBulletExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List <GameObject>();
    int i = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
             AttackGoals.Add(col.gameObject);
        }
    }
    public void Explose (float Damage, float SpeedDeBuff)
    {
        for(int q = 0; q < AttackGoals.Count; q++)
        {
            Debug.Log("ofof");
            AttackGoals[q].GetComponent<EnemyBehaviour>().HP = AttackGoals[q].GetComponent<EnemyBehaviour>().HP - Damage;
            AttackGoals[q].GetComponent<EnemyBehaviour>().speed = AttackGoals[q].GetComponent<EnemyBehaviour>().NormalSpeed * SpeedDeBuff;
        }
    }
}
