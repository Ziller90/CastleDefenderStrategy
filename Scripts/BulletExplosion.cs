using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
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
    public void Explose (float Damage)
    {
        for(int q = 0; q < AttackGoals.Count; q++)
        {
            Debug.Log("ofof");
            AttackGoals[q].GetComponent<EnemyBehaviour>().HP = AttackGoals[q].GetComponent<EnemyBehaviour>().HP - Damage;          
        }
    }
}
