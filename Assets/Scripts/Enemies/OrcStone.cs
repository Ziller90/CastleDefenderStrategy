using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcStone : MonoBehaviour
{
    public GameObject Castle;
    public float Speed;
    public float StoneDamage;
    public float TurningSpeed;
    void Start()
    {
        Castle = GameObject.Find("Castle");
    }

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        Vector3 EnemyVector = Vector3.RotateTowards(transform.forward, (Castle.transform.position - transform.position), 0.3f, 1F);
        Quaternion EnemyQuaternion = Quaternion.LookRotation(EnemyVector);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, EnemyQuaternion, TurningSpeed * Time.deltaTime);
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
        Castle.GetComponent<CastleScript>().HP = Castle.GetComponent<CastleScript>().HP - StoneDamage;
        Destroy(gameObject);
    }
}
