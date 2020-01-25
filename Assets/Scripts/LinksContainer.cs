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
    public GameObject Level;
    public GameUIManager UIManager;
    public BuildingManager buildingManager;
    public CastleScript Castle;
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
        instance = this;
        Level = GameObject.FindGameObjectWithTag("Level");
        Castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<CastleScript>();
    }
    void Awake ()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
