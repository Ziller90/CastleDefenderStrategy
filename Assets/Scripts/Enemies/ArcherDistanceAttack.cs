using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDistanceAttack : MonoBehaviour
{
    public EnemyBehaviour Enemy;
    public Transform EnemyTransform;
    public GameObject OrcArrow;
    public Transform ArrowSpawnPoint;

    public IEnumerator AttackDelay()
    {
        Enemy.AlreadyAttack = true;
        float Delay = Random.Range(0f, 3.5f);
        yield return new WaitForSeconds(Delay);
        Attack();

    }
    public void Attack ()
    {
        if (gameObject.GetComponent<EnemyBehaviour>().AlreadyDead == false)
        {
            Enemy.Go = false;
            EnemyTransform.LookAt(Enemy.Castle.transform.position);
            Enemy.AnimationIndex = 0;
        }
    }
    public void MakeArrow()
    {
        GameObject NewArrow = Instantiate(OrcArrow, ArrowSpawnPoint);
        NewArrow.GetComponent<OrcArrowScipt>().Castle = Enemy.Castle.gameObject;
        NewArrow.GetComponent<OrcArrowScipt>().ArrowDamage = Enemy.EnemyDamage;
        NewArrow.transform.parent = null;
    }
}
