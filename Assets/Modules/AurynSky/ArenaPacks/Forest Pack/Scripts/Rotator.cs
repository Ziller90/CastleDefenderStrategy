using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed;

	// Use this for initialization
	 
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}
}
