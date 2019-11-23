﻿// Just add this script to your camera. It doesn't need any configuration.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchCamera : MonoBehaviour
{

    public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    public Camera camera;
    public GameObject CameraObject;
    public bool isFreezed = false;
    public Text text;
    public bool Waited = true;
    Vector2?[] oldTouchPositions = {
        null,
        null
    };
    public Vector2 NewPos;
    Vector2 oldTouchVector;
    float oldTouchDistance;
    float OldDistance;

    public int XStop;
    public int ZStop;

     
    IEnumerator Wait(float Time)
    {
        Waited = false;
        yield return new WaitForSeconds(Time);
        Waited = true;
    }
    
    void Update()
    {

        if (isFreezed == false)
        {

            if (Input.touchCount == 2)
            {
                // Store both touches.
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


                // Otherwise change the field of view based on the change in distance between the touches.
                camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 30f, 75f);
                StartCoroutine("Wait", 0.2f);
            }
            else if (Input.touchCount == 1 && Waited == true)
            {
                if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
                {
                    oldTouchPositions[0] = Input.GetTouch(0).position;
                    oldTouchPositions[1] = null;
                }
                else
                {
                    Vector2 newTouchPosition = Input.GetTouch(0).position;

                    transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * camera.orthographicSize / camera.pixelHeight * 2f));


                    oldTouchPositions[0] = newTouchPosition;
                }
            }
            else
            {
                oldTouchPositions[0] = null;
                oldTouchPositions[1] = null;
            }
        }
    }
    void LateUpdate()
    {
        if (gameObject.transform.position.x > XStop)
        {
            gameObject.transform.position = new Vector3(XStop, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x < -XStop)
        {
            gameObject.transform.position = new Vector3(-XStop, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z > ZStop)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, ZStop);
        }
        if (gameObject.transform.position.z < -ZStop)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -ZStop);
        }
    }

}
