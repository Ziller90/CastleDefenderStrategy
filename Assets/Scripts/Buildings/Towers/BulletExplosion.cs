using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List <GameObject>();
    int i = 0;

     

    // Update is called once per frame

    public void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
             AttackGoals.Add(col.gameObject);
        }
    }
    IEnumerator Explose (float Damage)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<AudioSource>().Play();
        for(int q = 0; q < AttackGoals.Count; q++)
        {
            if (ShopManager.BigBalls == true)
                AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage + 0.3f, CardScriptableObject.DamageType.ExplosionDamage);
            else
                AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
        }
    }
}
