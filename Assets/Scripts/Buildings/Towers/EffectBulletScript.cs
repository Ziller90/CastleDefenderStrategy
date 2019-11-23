using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletScript : MonoBehaviour
{
    public float speed;
    public Vector3 EnemyPosition;
    public float TurningSpeed;
    public float Damage;
    public GameObject ExplosionArea;
    public bool AlwaysExploud;
    public float EffectPower;
    public float EffectTime;
    public ParticleSystem FrozenParticle;

     

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AlwaysExploud == false)
        {
            gameObject.transform.position += transform.forward * speed;
            Vector3 EnemyVector = Vector3.RotateTowards(transform.forward, (EnemyPosition - transform.position), 0.3f, 1F);
            Quaternion EnemyQuaternion = Quaternion.LookRotation(EnemyVector);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, EnemyQuaternion, TurningSpeed * Time.deltaTime);
        }

    }
    void OnTriggerEnter (Collider col)
    {
        if ((col.gameObject.tag == "Cube") && AlwaysExploud == false)
        {
            StartCoroutine("Destroing");
            ExplosionArea.GetComponent<EffectBulletExplosion>().Explose(Damage, EffectPower, EffectTime);
            AlwaysExploud = true;
        }
    }
    IEnumerator Destroing ()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        FrozenParticle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
