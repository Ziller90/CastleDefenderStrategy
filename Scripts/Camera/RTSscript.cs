using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICameraPresentation : MonoBehaviour
{
    public delegate void CameraMovedEvent(Vector3 offset, Vector3 cameraPosition);
    public event CameraMovedEvent cameraMovedEvent;
    public void postCameraMovedEvent(Vector3 offset, Vector3 cameraPosition)
    {
        if (cameraMovedEvent != null)
            cameraMovedEvent(offset, cameraPosition);
    }

    public abstract Vector3 cameraPosition();

    public abstract void moveCamera(float vertical, float horizontal);
    public abstract void zoomCamera(float value);
    public abstract void setZoom(float value);
    public abstract float getZoom();

    public abstract Vector3 worldToScreenPoint(Vector3 point);
    public abstract Ray screenPointToRay(Vector2 point);
    public virtual Ray viewPortPointToRay(Vector2 point) { return new Ray(); }
    public abstract bool isWorldPointInScreenRect(Vector3 point, Rect rect);

    public abstract Vector2 screenSize();
}

public class RTSscript : ICameraPresentation
{

    public Camera mainCamera;
    public Transform cameraCenter;
    public float cameraSpeed = 1.0f;
    public float zoomSpeed = 5.0f;
    public float minFieldOfView = 10.0f;
    public float maxFieldOfView = 24.0f;
    public float initialFieldOfView = 30.0f;
    public float portraitFieldOfViewCoef = 1.0f;
    Bounds bounds;
    bool boundsDefined = false;
    float currentFieldOfView = 0.0f;

    void OnEnable()
    {
        currentFieldOfView = initialFieldOfView;
    }

    private void Update()
    {
        float k = mainCamera.aspect <= 1.0f ? portraitFieldOfViewCoef : 1.0f;
        mainCamera.fieldOfView = currentFieldOfView * k;
    }

    void OnDisable()
    {

    }

    void onPlayerRegistered()
    {
        var oldPosition = mainCamera.transform.position;
        var cameraOffset = cameraCenter.transform.position - oldPosition;
    }

    public override Vector3 cameraPosition()
    {
        return mainCamera.transform.position;
    }

    public override void moveCamera(float vertical, float horizontal)
    {
        var newCameraPos = mainCamera.transform.position;
        newCameraPos += new Vector3(1.0f, 0.0f, 1.0f) * Time.deltaTime * cameraSpeed * vertical;
        newCameraPos += new Vector3(1.0f * horizontal, 0.0f, -1.0f * horizontal) * Time.deltaTime * cameraSpeed;
        newCameraPos = getBounds().ClosestPoint(newCameraPos);
        postCameraMovedEvent(newCameraPos - mainCamera.transform.position, newCameraPos);
        mainCamera.transform.position = newCameraPos;
    }

    Vector3 projection(Vector3 viewportPos)
    {
        var ray1 = mainCamera.ViewportPointToRay(viewportPos);
        var plane = new Plane(Vector3.zero, Vector3.forward, Vector3.left);
        float enter1;
        plane.Raycast(ray1, out enter1);
        return ray1.GetPoint(enter1);
    }

    Bounds getBounds()
    {
        if (!boundsDefined)
        {
            var dist = mainCamera.transform.position.y / Mathf.Sin(mainCamera.transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
            var point = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, dist));
            var offset = Vector3.Distance(new Vector3(mainCamera.transform.position.x, 0.0f, mainCamera.transform.position.z), point) / Mathf.Sqrt(2.0f);
            boundsDefined = true;
        }
        return bounds;
    }

    public override void zoomCamera(float value)
    {
        currentFieldOfView = Mathf.Clamp(Camera.main.fieldOfView - value * zoomSpeed, minFieldOfView, maxFieldOfView);
    }

    public override void setZoom(float value)
    {
        float diff = maxFieldOfView - minFieldOfView;
        float offset = value * diff;
        currentFieldOfView = Mathf.Clamp(Camera.main.fieldOfView + offset, minFieldOfView, maxFieldOfView);
    }

    public override float getZoom()
    {
        float currentOffset = currentFieldOfView - minFieldOfView;
        float diff = maxFieldOfView - minFieldOfView;
        return currentOffset / diff;
    }

    public override Vector3 worldToScreenPoint(Vector3 point)
    {
        return mainCamera.WorldToScreenPoint(point);
    }

    public override Ray screenPointToRay(Vector2 point)
    {
        return mainCamera.ScreenPointToRay(point);
    }

    public override Ray viewPortPointToRay(Vector2 point)
    {
        return mainCamera.ViewportPointToRay(point);
    }

    public override bool isWorldPointInScreenRect(Vector3 point, Rect rect)
    {
        var itemScreenPos = worldToScreenPoint(point);
        return rect.Contains(itemScreenPos, true);
    }

    public override Vector2 screenSize()
    {
        return new Vector2(mainCamera.scaledPixelWidth, mainCamera.scaledPixelHeight);
    }
}