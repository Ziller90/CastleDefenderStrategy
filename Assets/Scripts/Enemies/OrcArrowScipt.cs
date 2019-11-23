using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcArrowScipt : MonoBehaviour
{
    public GameObject Castle;
    public float Speed;
    public float ArrowDamage;

     

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        gameObject.transform.LookAt(Castle.transform.position);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Castle")
        {
            StartCoroutine("DamageDeliver");
        }
    }
    IEnumerator DamageDeliver ()
    {
        yield return new WaitForSeconds(0.5f);
        Castle.GetComponent<CastleScript>().DamageReceive(ArrowDamage, gameObject.transform.position);
        Destroy(gameObject);
    }
}
