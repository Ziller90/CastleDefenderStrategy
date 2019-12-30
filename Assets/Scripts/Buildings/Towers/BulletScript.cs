using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public Vector3 EnemyPosition;
    public float Distance;
    public float TurningSpeed;
    public float Damage;
    public GameObject ExplosionArea;
    public bool AlwaysExploud;
    public ParticleSystem ExplosionEffect;
    public ParticleSystem ExplosionEffect2;


     
    void Start()
    {
        if(ShopManager.BigBalls == true)
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
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
        if (col.gameObject.tag == "Cube" && AlwaysExploud == false)
        {
            StartCoroutine("Destroing");
            ExplosionArea.GetComponent<BulletExplosion>().StartCoroutine("Explose", Damage);
            AlwaysExploud = true;
        }
    }
    IEnumerator Destroing ()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        ExplosionEffect.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
