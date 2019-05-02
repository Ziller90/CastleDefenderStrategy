using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfanityAttackBehavior : MonoBehaviour
{
    public bool Attack;
    GameObject Castle;
    public float Damage;
    public GameObject ObjectToAttack;
    public Animator InfanityAnimator;
    void Start()
    {
        Castle = GameObject.Find("Castle");
    }

    // Update is called once per frame
    public void Update()
    {
        if (Attack == true)
        {
            InfanityAnimator.SetBool("Attack", true);
            if (ObjectToAttack == Castle)
            {
                Castle.GetComponent<CastleScript>().HP = Castle.GetComponent<CastleScript>().HP - Damage;
            }
            if (ObjectToAttack != Castle)
            {
                Debug.Log("AttackTower");
            }
        }
        if (Attack == false)
        {
            InfanityAnimator.SetBool("Attack", false);
        }
    }
}
