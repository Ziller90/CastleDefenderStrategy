using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public EnemyBehaviour Enemy;
    bool AleradyStopped;
    public ParticleSystem FireFromMounth;
    public GameObject MiniGolem;
    public Transform MinionSpawnPoint;
    void Start()
    {
        StartCoroutine("UndedCall");
    }
    void Update()
    {
        if ((Enemy.EnemyAnimator.GetBool("Attack") == true || Enemy.EnemyAnimator.GetBool("Dead") == true) && AleradyStopped == false)
        {
            StopCoroutine("UndedCall");
            AleradyStopped = true;
        }
    }
    // Update is called once per frame

    IEnumerator UndedCall ()
    {
        yield return new WaitForSeconds(10f);
        Enemy.EnemyAnimator.SetBool("SuperAbility", true);
        Enemy.Go = false;
        yield return new WaitForSeconds(3.5f);
        GameObject NewMinion = Instantiate(MiniGolem, MinionSpawnPoint.position, MinionSpawnPoint.rotation);

        NewMinion.transform.parent = null;
        NewMinion.transform.GetChild(1).GetComponent<EnemyBehaviour>().WayPoints = Enemy.WayPoints;
        NewMinion.transform.GetChild(1).GetComponent<EnemyBehaviour>().WayIndex = Enemy.WayIndex;
        yield return new WaitForSeconds(3.5f);
        FireFromMounth.Stop();
        yield return new WaitForSeconds(0.4f);
        Enemy.Go = true; ;
        Enemy.EnemyAnimator.SetBool("SuperAbility", false);

        StartCoroutine("UndedCall");
    }
    public void Call()
    {
        FireFromMounth.Play();
    }
}
