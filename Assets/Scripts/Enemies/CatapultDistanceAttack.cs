using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultDistanceAttack : MonoBehaviour
{
    public EnemyBehaviour Enemy;
    public Transform EnemyTransform;
    public GameObject CatapultStone;
    public Transform CatapultStoneAppearPoint;
    public bool AlreadyAttacked;
    public float ReloadingSpeed;

     

    // Update is called once per frame
    void Update()
    {
        if (Enemy.EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Orc_catapult_03_attack") && AlreadyAttacked == false)
        {
            Debug.Log("Fuck");
            AlreadyAttacked = true;
        }
    }
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
            yield return new WaitForSeconds(ReloadingSpeed);
            ReloadingSpeed = 1.55f;
            Debug.Log(Enemy.EnemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Debug.Log("Make new stone");
            GameObject NewArrow = Instantiate(CatapultStone, CatapultStoneAppearPoint);
            StartCoroutine("Attack");
        }
    }
}
