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
       
    }
    public IEnumerator AttackDelay()
    {
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
            Enemy.EnemyAnimator.SetBool("Attack", true);
        }
    }
    public void Shot()
    {
        GameObject NewStone = Instantiate(CatapultStone, CatapultStoneAppearPoint);
    }
}
