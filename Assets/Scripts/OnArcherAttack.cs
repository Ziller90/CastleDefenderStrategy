using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnArcherAttack : MonoBehaviour
{
    ArcherDistanceAttack Archer;
    void Start()
    {
        Archer = gameObject.transform.parent.GetComponent<ArcherDistanceAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ArcherAttack()
    {
        Archer.MakeArrow();
    }
}
