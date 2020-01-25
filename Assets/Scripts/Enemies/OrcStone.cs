using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcStone : MonoBehaviour
{
    public CastleScript Castle;
    public float Speed;
    public float StoneDamage;
    public float TurningSpeed;
    public float MinimuDistance;
    bool AlreadyAttacked = false;


    void Start()
    {
        Castle = LinksContainer.instance.Castle;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += transform.forward * Speed;
        Vector3 EnemyVector = Vector3.RotateTowards(transform.forward, (Castle.transform.position - transform.position), 0.3f, 1F);
        Quaternion EnemyQuaternion = Quaternion.LookRotation(EnemyVector);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, EnemyQuaternion, TurningSpeed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, Castle.transform.position) < MinimuDistance && AlreadyAttacked == false)
        {
            StartCoroutine("DamageDeliver");
            AlreadyAttacked = true;
        }
    }
    IEnumerator DamageDeliver ()
    {
        yield return new WaitForSeconds(0.5f);
        Castle.DamageReceive(StoneDamage, gameObject.transform.position);
        Castle.HitSound(gameObject.GetComponent<AttackSounds>().AttackSound);
        Destroy(gameObject,2);
    }
}
