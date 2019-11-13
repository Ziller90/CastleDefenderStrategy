using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHealingStart : MonoBehaviour
{
    public ShamanHealer Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHeal ()
    {
        Enemy.Heal();
    }
}
