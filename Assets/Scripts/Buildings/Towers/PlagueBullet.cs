using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueBullet : MonoBehaviour
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
    public MeshRenderer MeshRender;
    public Transform PlaguePiece;
    public float TimeToUnEnableEffect;
    public float Groundheightlevel;





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
        if (gameObject.transform.position.y < Groundheightlevel && AlwaysExploud == false)
        {
            StartCoroutine("Growing");
            AlwaysExploud = true;
        }
    }

    IEnumerator Destroing ()
    {
        ExplosionArea.GetComponent<EffectBulletExplosion>().Explose(Damage, EffectPower, EffectTime);
        MeshRender.enabled = false;
        FrozenParticle.Play();
        yield return new WaitForSeconds(TimeToUnEnableEffect);
        Destroy(gameObject);
    }
    IEnumerator Growing()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.02f);
            PlaguePiece.localScale = new Vector3(PlaguePiece.localScale.x + 0.004f, PlaguePiece.localScale.y + 0.004f, PlaguePiece.localScale.z + 0.004f);
        }
        StartCoroutine("Destroing");
    }
}