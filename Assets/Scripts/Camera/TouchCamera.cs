// Just add this script to your camera. It doesn't need any configuration.

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
    public float XStopToUse;
    public float ZStopToUse;
    public float ModificatorForPlus;
    public float ModificatorForMinus;




    IEnumerator Wait(float Time)
    {
        Waited = false;
        yield return new WaitForSeconds(Time);
        Waited = true;
    }
    
    void Update()
    {
        if (camera.fieldOfView > 60)
        {
            XStopToUse = XStop - ((camera.fieldOfView - 60) * ModificatorForPlus);
            ZStopToUse = ZStop - ((camera.fieldOfView - 60) * ModificatorForPlus);
        }
        if (camera.fieldOfView < 60)
        {
            XStopToUse = XStop + ((60 - camera.fieldOfView) * ModificatorForMinus);
            ZStopToUse = ZStop + ((60 - camera.fieldOfView) * ModificatorForMinus);
        }
        if (camera.fieldOfView == 60)
        {
            XStopToUse = XStop;
            ZStopToUse = ZStop;
        }

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
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 30f, 65f);
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
        if (gameObject.transform.position.x > XStopToUse)
        {
            gameObject.transform.position = new Vector3(XStopToUse, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x < -XStopToUse)
        {
            gameObject.transform.position = new Vector3(-XStopToUse, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z > ZStopToUse)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, ZStopToUse);
        }
        if (gameObject.transform.position.z < -ZStopToUse)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -ZStopToUse);
        }
    }

}
