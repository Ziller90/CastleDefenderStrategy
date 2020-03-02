using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSarter : MonoBehaviour
{
    public ConfigScriptableObject Config;
    public Transform MapPosition;
    public GameObject Camera;
    public GameObject NewMap;
    public bool TouchCamera;
    public GameObject StartOrc;
    public int CurrentLevelCampaignIndex;

    void Start()
    {
        StartCoroutine(AnimationInstancing.AnimationManager.GetInstance().LoadAnimationAssetBundle(Application.streamingAssetsPath + "/AssetBundle/animationtexture"));
        MapLoader(LevelLoader.LevelToLoad);
        Instantiate(StartOrc, new Vector3(1000, 1000, 1000), Quaternion.identity);
    }

    // Update is called once per frame
    void MapLoader (int MapID)
    {
        NewMap = Instantiate(Config.CamapaignMaps[MapID], MapPosition.position, Quaternion.identity);
        NewMap.GetComponent<MapSetting>().SetUseTouchCamera(TouchCamera);
        NewMap.transform.Rotate(0, NewMap.GetComponent<MapSetting>().Rotate,0);
        CurrentLevelCampaignIndex = MapID;
    }
    public void GameReloader ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void NextMission ()
    {
        LevelLoader.LevelToLoad = NewMap.GetComponent<MapSetting>().LevelNumber + 1;
        SceneManager.LoadScene(3);
    }
}

