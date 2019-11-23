using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHealingStart : MonoBehaviour
{
    public ShamanHealer Enemy;

    // Update is called once per frame
    public void OnHeal ()
    {
        Enemy.Heal();
    }
}
