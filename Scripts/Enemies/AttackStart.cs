using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStart : MonoBehaviour
{
    public EnemyBehaviour Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAttack()
    {
        Enemy.OnAttack();
    }
}
