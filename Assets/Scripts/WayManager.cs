using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WayManager : MonoBehaviour
{
    [System.Serializable]
    public class Way
    {
        public Transform[] WayPoints;
    }

    public Way[] Ways;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
