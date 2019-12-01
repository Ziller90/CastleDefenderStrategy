using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WayPointScript : MonoBehaviour
{
    public int RouteNumber;
    public int WayIndexNumber;
    public WayManager WayManager;

    void Start ()
    {
        if (Application.isPlaying == true)
        {
            gameObject.GetComponent<WayPointScript>().enabled = false;
        }
    }
    void Update ()
    {
       WayManager.Ways[RouteNumber].WayPoints[WayIndexNumber] = gameObject.transform;
    }
}
