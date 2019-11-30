using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    public int RouteNumber;
    public int WayIndexNumber;
    public bool RightTurner;
    public GlobalEnemiesManager globalEnemiesManager;
     
    void Start ()
    {
        globalEnemiesManager = GameObject.Find("GlobalEnemiesManager").GetComponent<GlobalEnemiesManager>();
    }
    void Update ()
    {
        var EnemyToTurn = globalEnemiesManager.EnemyToTurn(gameObject.transform.position, RouteNumber, WayIndexNumber);
        if (EnemyToTurn != null)
        {
            if (RightTurner == true)
                EnemyToTurn.GetComponent<EnemyBehaviour>().TurnRight();
            if (RightTurner == false)
                EnemyToTurn.GetComponent<EnemyBehaviour>().TurnLeft();
            EnemyToTurn.GetComponent<EnemyBehaviour>().WayIndex++;
        }
    }
}
