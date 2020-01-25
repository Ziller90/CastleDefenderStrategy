using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcArrowScipt : MonoBehaviour
{
    public GameObject Castle;
    public float Speed;
    public float ArrowDamage;
    public float MinimuDistance;

     

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        gameObject.transform.LookAt(Castle.transform.position);
        if (Vector3.Distance(gameObject.transform.position, Castle.transform.position) < MinimuDistance)
        {
            StartCoroutine("DamageDeliver");
        }
    }
    IEnumerator DamageDeliver ()
    {
        yield return new WaitForSeconds(0.1f);
        Castle.GetComponent<CastleScript>().DamageReceive(ArrowDamage, gameObject.transform.position);
        Castle.GetComponent<CastleScript>().HitSound(gameObject.GetComponent<AttackSounds>().AttackSound);
        Destroy(gameObject);
    }
}
