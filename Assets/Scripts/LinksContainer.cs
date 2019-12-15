using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksContainer : MonoBehaviour
{
    public WinScript winScript;
    public ResourcesManager resourcesManager;
    public GlobalEnemiesManager globalEnemiesManager;
    public GameObject CameraViewPoint;
    public AudioManager audioManager;
    public static LinksContainer instance;
    public LinksContainer()
    {
        instance = this;
    }
    private void OnDestroy ()
    {
        instance = null;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
