using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStart : MonoBehaviour
{
    public EnemyBehaviour Enemy;

    // Update is called once per frame
    public void StartAttack()
    {
        Enemy.OnAttack();
    }
}
