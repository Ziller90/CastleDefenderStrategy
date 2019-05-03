using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfanityAttackBehavior : MonoBehaviour
{
    GameObject Castle;
    public float Damage;
    public Animator InfanityAnimator;
    public bool Reloaded = true;
    void Start()
    {
        Castle = GameObject.Find("Castle");
    }

    // Update is called once per frame
    public void Update()
    {

    }

    IEnumerator Attack(GameObject ObjectToAttack)
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        InfanityAnimator.SetBool("Attack", true);
        gameObject.GetComponent<EnemyBehaviour>().Go = false;

        if (ObjectToAttack == Castle)
        {
            Castle.GetComponent<CastleScript>().HP = Castle.GetComponent<CastleScript>().HP - Damage;
            StartCoroutine("Attack", ObjectToAttack);
        }
    }
}
