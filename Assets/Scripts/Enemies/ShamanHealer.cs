using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanHealer : MonoBehaviour
{
    public List<GameObject> EnemiesToHeal;
    public float HealingPower;
    public EnemyBehaviour Enemy;
    public GlobalEnemiesManager globalEnemiesManager;
    public float RangeOfHealing;

    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        StartCoroutine("Healing");
    }

    // Update is called once per frame

    IEnumerator Healing ()
    {
        yield return new WaitForSeconds(0.5f);
        if (Enemy.FullFreezed == false)
        {
            if (Enemy.EnemyAnimator.GetBool("Attack") != true)
            {
                yield return new WaitForSeconds(5);
                Enemy.Go = false;
                Enemy.EnemyAnimator.SetBool("Heal", true);
                yield return new WaitForSeconds(1.33f);
                Enemy.EnemyAnimator.SetBool("Heal", false);
                Enemy.Go = true;
                StartCoroutine("Healing");
            }
        }
        else
        {
            StartCoroutine("Healing");
        }
    }
    public void Heal()
    {
        EnemiesToHeal = globalEnemiesManager.EnemiesInRadius(gameObject.transform.position, RangeOfHealing);
        if (EnemiesToHeal != null)
        {
            for (int i = 0; i < EnemiesToHeal.Count; i++)
            {
                if (EnemiesToHeal[i].GetComponent<EnemyBehaviour>().AlreadyDead == false)
                EnemiesToHeal[i].GetComponent<EnemyBehaviour>().Heal(HealingPower);
            }
        }
    }
}
