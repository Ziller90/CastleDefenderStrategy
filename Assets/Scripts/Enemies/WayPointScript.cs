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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.746f , gameObject.transform.position.z);
            gameObject.GetComponent<WayPointScript>().enabled = false;
        }
    }
    void Update ()
    {
        if (Application.isPlaying == false)
        {
            switch (RouteNumber)
            {
                case 0:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
                    break;
                case 1:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.6f, gameObject.transform.position.z);
                    break;
                case 2:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.7f, gameObject.transform.position.z);
                    break;
                case 3:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.8f, gameObject.transform.position.z);
                    break;
                case 4:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.9f, gameObject.transform.position.z);
                    break;
                case 5:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.0f, gameObject.transform.position.z);
                    break;
                case 6:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.1f, gameObject.transform.position.z);
                    break;
                case 7:
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.2f, gameObject.transform.position.z);
                    break;
            }
            WayManager.Ways[RouteNumber].WayPoints[WayIndexNumber] = gameObject.transform;
        }
    }
    void OnDrawGizmos()
    {
        switch (RouteNumber)
        {
            case 0:
                Gizmos.color = Color.white;
                break;
            case 1:
                Gizmos.color = Color.red;
                break;
            case 2:
                Gizmos.color = Color.blue;
                break;
            case 3:
                Gizmos.color = Color.black;
                break;
            case 4:
                Gizmos.color = Color.yellow;
                break;
            case 5:
                Gizmos.color = Color.green;
                break;
            case 6:
                Gizmos.color = Color.grey;
                break;
            case 7:
                Gizmos.color = Color.magenta;
                break;
        }
        if (WayManager != null)
            if(WayManager.Ways[RouteNumber].WayPoints[WayIndexNumber + 1] != null)
        Gizmos.DrawLine(gameObject.transform.position, WayManager.Ways[RouteNumber].WayPoints[WayIndexNumber + 1].position);
    }
}
