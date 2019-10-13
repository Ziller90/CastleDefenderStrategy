using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBulletScript : MonoBehaviour
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            gameObject.transform.position += transform.forward * speed;
            Vector3 EnemyVector = Vector3.RotateTowards(transform.forward, (EnemyPosition - transform.position), 0.3f, 1F);
            Quaternion EnemyQuaternion = Quaternion.LookRotation(EnemyVector);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, EnemyQuaternion, TurningSpeed * Time.deltaTime);
    }
    void OnTriggerEnter (Collider col)
    {
        if ((col.gameObject.tag == "Cube") && AlwaysExploud == false)
        {
            StartCoroutine("Destroing");
            ExplosionArea.GetComponent<FrozenBulletExplosion>().Explose(Damage, EffectPower, EffectTime);
            AlwaysExploud = true;
        }
    }
    IEnumerator Destroing ()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        FrozenParticle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
