using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    public int RouteNumber;
    public bool RightTurner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("efef");
        if (col.gameObject.tag == "Enemy" && col.GetComponent<EnemyBehaviour>().RouteNumber == RouteNumber)
        {
            Debug.Log("efef1");
            if (RightTurner == true)
                col.GetComponent<EnemyBehaviour>().StartCoroutine("TurnRight");
            if (RightTurner == false)
                col.GetComponent<EnemyBehaviour>().StartCoroutine("TurnLeft");
        }
    }
}
