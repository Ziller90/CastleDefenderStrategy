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


    public void SetUseTouchCamera(bool UsingTouchCamera)
    {
        UseTouchCamera = UsingTouchCamera;
    }
    void Start()
    {
        if (ShopManager.StartUpCapital == true)
        {
            StartGold = StartGold + 50;
        }
        Camera = GameObject.Find("MainCamera").GetComponent<RTS_Cam.RTS_Camera>();
        GameObject.Find("WinManager").GetComponent<WinScript>().Spawners = Spawners;
        GameObject.Find("WinManager").GetComponent<WinScript>().CrystalsRewardForWin = CrystalsRewardForWin;
        GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>().Gold = StartGold;
        if (PlayerStats.StartCapitalOpened == true)
        {
            GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>().Gold += 30;
        }

        if (UseTouchCamera == true)
        {
            touchCamera = GameObject.Find("Camera").GetComponent<TouchCamera>();
            touchCamera.XStop = CameraFieldSizeX;
            touchCamera.ZStop = CameraFieldSizeY;
        }
        else
        {
            Camera = GameObject.Find("MainCamera").GetComponent<RTS_Cam.RTS_Camera>();
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
