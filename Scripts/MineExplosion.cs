using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List<GameObject>();
    public bool Frozen;
    public ParticleSystem Particle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && AttackGoals.Count <= 6)
        {
            AttackGoals.Add(col.gameObject);
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            AttackGoals.Remove(col.gameObject);
        }
    }
    public void Explose(float Damage)
    {
        gameObject.GetComponent<AudioSource>().Play();
        for (int q = 0; q < AttackGoals.Count; q++)
        {
            if (AttackGoals[q] != null)
            {
                if (Frozen == false)
                    AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
                else
                {
                    AttackGoals[q].GetComponent<EffectsResistance>().EffectCast(CardScriptableObject.EffectType.FreezingEffect, 0.4f, 20);
                }
                Particle.Play();
            }
        }
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BuildingStats>().FilledCube.GetComponent<BuilderManager>().BuildingFiled = -1;
        Destroy(gameObject, 1f);

    }

}
