using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public MusicManager musicManager;
    public GameSarter gameSarter;
    public static LinksContainer instance;
    public GameObject NewMessageButton;
    public GameObject PlayingUIElements;
    public Image HpBar;
    public GameObject RTSCamera;
    public GameObject TouchCamera;
    public GameObject CameraControl;
    public WayManager wayManager;

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
