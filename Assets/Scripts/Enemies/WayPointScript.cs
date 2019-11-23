using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    public int RouteNumber;
    public bool RightTurner;
     

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && col.GetComponent<EnemyBehaviour>().RouteNumber == RouteNumber)
        {
            if (RightTurner == true)
                col.GetComponent<EnemyBehaviour>().StartCoroutine("TurnRight");
            if (RightTurner == false)
                col.GetComponent<EnemyBehaviour>().StartCoroutine("TurnLeft");
        }
    }
}
