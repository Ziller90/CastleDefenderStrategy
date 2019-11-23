using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDistanceAttack : MonoBehaviour
{
    public EnemyBehaviour Enemy;
    public Transform EnemyTransform;
    public GameObject OrcArrow;

    public IEnumerator AttackDelay()
    {
        float Delay = Random.Range(0f, 3.5f);
        yield return new WaitForSeconds(Delay);
        StartCoroutine("Attack");

    }
    public IEnumerator Attack ()
    {
        if (gameObject.GetComponent<EnemyBehaviour>().AlreadyDead == false)
        {
            Enemy.Go = false;
            EnemyTransform.LookAt(Enemy.Castle.transform.position);
            Enemy.EnemyAnimator.SetBool("Attack", true);
            yield return new WaitForSeconds(1.3f);
            GameObject NewArrow = Instantiate(OrcArrow, gameObject.transform);
            NewArrow.GetComponent<OrcArrowScipt>().Castle = Enemy.Castle;
            NewArrow.GetComponent<OrcArrowScipt>().ArrowDamage = Enemy.EnemyDamage;
            StartCoroutine("Attack");
        }
    }
}
