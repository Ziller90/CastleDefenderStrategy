using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRayCast : MonoBehaviour
{
    public Ray CameraRay;
    public RaycastHit[] hits;
    public GameObject OldHitObject;
    public bool AlwaysDetected;
    public GameUIManager UIManager;
    void Start()
    {
        
    }

    public static bool IsOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<CanvasRenderer>())
                {
                    return true;
                }
            }
        }

        return false;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && IsOverUI() == false)
        {
            if (OldHitObject != null && OldHitObject.tag == "Cube")
            {
                OldHitObject.GetComponent<BuilderManager>().CubeRemoveHightLighting();
            }
            if (OldHitObject != null && OldHitObject.tag == "Tower")
            {
                OldHitObject.GetComponent<BuildingStats>().BuildingHighLightRemove();
            }

            CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(CameraRay.origin, CameraRay.direction * 30, Color.yellow);
            hits = Physics.RaycastAll(CameraRay);
            Debug.Log("Rayed");
            if (hits.Length > 0)
            {
                Debug.Log("HaveObjectsToCheck");
                DetectedObjectsManager();
            }
            
        }
    }
    void DetectedObjectsManager ()
    {
        for (int i = 0; i < hits.Length; i++)
        {


            if (hits[i].collider.gameObject.tag == "Tower" && AlwaysDetected == false)
            {
                Debug.Log("DetectedCube");
                AlwaysDetected = true;
                Debug.Log(hits[i].collider.gameObject.name);
                hits[i].collider.gameObject.GetComponent<BuildingStats>().BuildingIsHignLighted();
                OldHitObject = hits[i].collider.gameObject;
            }

        }

        for (int i = 0; i < hits.Length; i++)
        {

            if (hits[i].collider.gameObject.tag == "Cube" && AlwaysDetected == false)
            {
                Debug.Log("DetectedCube");
                AlwaysDetected = true;
                Debug.Log(hits[i].collider.gameObject.name);
                hits[i].collider.gameObject.GetComponent<BuilderManager>().CubeHighLighting();
                OldHitObject = hits[i].collider.gameObject;
            }

        }
        AlwaysDetected = false;
    }
}
