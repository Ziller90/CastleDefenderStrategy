using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    public float Damage;
    public bool Reloaded;
    public float RangeOfDetection;
    public float ReloadingTime;
    GlobalEnemiesManager globalEnemiesManager;
    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
    }

    void Update()
    {
        if (globalEnemiesManager.IsEnemyInRadius(gameObject.transform.position, RangeOfDetection) && Reloaded == true)
        {
            StartCoroutine("Attack");
            Reloaded = false;
        }
    }
    public IEnumerator Attack ()
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", true);
        yield return new WaitForSeconds(0.2f);
        if (globalEnemiesManager.EnemyToAttack(gameObject.transform.position, RangeOfDetection) != null)
        {
             globalEnemiesManager.EnemyToAttack(gameObject.transform.position, RangeOfDetection).GetComponent<DamageReciever>().DamageResistance(Damage, CardScriptableObject.DamageType.PenetrationDamage);
        }
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", false);
        yield return new WaitForSeconds(ReloadingTime);
        Reloaded = true;
    }
}
