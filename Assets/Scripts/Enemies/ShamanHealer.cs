using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanHealer : MonoBehaviour
{
    public List<EnemyBehaviour> EnemiesToHeal;
    public float HealingPower;
    public EnemyBehaviour Enemy;
    void Start()
    {
        StartCoroutine("Healing");
    }

    // Update is called once per frame

    IEnumerator Healing ()
    {
        if (Enemy.FullFreezed != true)
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
        if (EnemiesToHeal.Count != 0)
        {
            for (int i = 0; i < EnemiesToHeal.Count; i++)
            {
                if (EnemiesToHeal[i].AlreadyDead == false)
                EnemiesToHeal[i].Heal(HealingPower);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemiesToHeal.Add(col.gameObject.GetComponent<EnemyBehaviour>());
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemiesToHeal.Remove(col.gameObject.GetComponent<EnemyBehaviour>());
        }
    }
}
