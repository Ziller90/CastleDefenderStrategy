using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    List<GameObject> AttackGoals = new List <GameObject>();
    public GlobalEnemiesManager globalEnemiesManager;
    public float RangeOfExplosion;
    int i = 0;
    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        if (ShopManager.BigBalls == true)
            RangeOfExplosion = RangeOfExplosion * 1.5f;
    }

    IEnumerator Explose (float Damage)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<AudioSource>().Play();
        AttackGoals = globalEnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfExplosion);
        for (int q = 0; q < AttackGoals.Count; q++)
        {
            if (ShopManager.BigBalls == true)
                AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage + 0.3f, CardScriptableObject.DamageType.ExplosionDamage);
            else
                AttackGoals[q].GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.ExplosionDamage);
        }
    }
}
