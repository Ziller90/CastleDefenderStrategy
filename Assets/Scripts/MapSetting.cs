using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetting : MonoBehaviour
{
    public TouchCamera touchCamera;
    public int CameraFieldSizeX;
    public int CameraFieldSizeY;
    public Vector3 Offset;
    public Vector3 StartCameraOffset;
    public bool UseStartOffset;
    public RTS_Cam.RTS_Camera Camera;
    public int StartGold;
    public ResourcesManager Manager;
    public CripsSpawner[] Spawners;
    public int CrystalsRewardForWin;
    private bool UseTouchCamera;
    public int LevelNumber;
    public int Rotate;
    public CripsSpawner MainSpawner;
    public ShopProductsScriptableObject Shop;

    [ContextMenu("Double")]
    public void Double()
    {
        CrystalsRewardForWin = CrystalsRewardForWin * 2;
    }
    public void SetUseTouchCamera(bool UsingTouchCamera)
    {
        UseTouchCamera = UsingTouchCamera;
    }
    void Start()
    {
        LinksContainer.instance.Level = gameObject;
        if (Shop.GetProductPurchaseState("StartUpCapital") == true)
        {
            StartGold = StartGold + 50;
        }
        Camera = LinksContainer.instance.RTSCamera.GetComponent<RTS_Cam.RTS_Camera>();
        LinksContainer.instance.winScript.Spawners = Spawners;
        LinksContainer.instance.winScript.CrystalsRewardForWin = CrystalsRewardForWin;
        LinksContainer.instance.resourcesManager.Gold = StartGold;
        if (PlayerStats.StartCapitalOpened == true)
        {
            LinksContainer.instance.resourcesManager.GetComponent<ResourcesManager>().Gold += 30;
        }

        if (UseTouchCamera == true)
        {
            touchCamera = LinksContainer.instance.TouchCamera.GetComponent<TouchCamera>();
            touchCamera.XStop = CameraFieldSizeX;
            touchCamera.ZStop = CameraFieldSizeY;
        }
        else
        {
            Camera = LinksContainer.instance.RTSCamera.GetComponent<RTS_Cam.RTS_Camera>();
            Camera.limitX = CameraFieldSizeX;
            Camera.limitY = CameraFieldSizeY;
        }
        if (UseStartOffset == true)
        {
            if (UseTouchCamera)
            {
                touchCamera.transform.position = StartCameraOffset;
            }
            else
            {
                Camera.transform.position = StartCameraOffset;

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Offset;
    }

}
