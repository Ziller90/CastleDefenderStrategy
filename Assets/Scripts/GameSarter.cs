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

    void Start()
    {
        MapLoader(LevelLoader.LevelToLoad);
        Instantiate(StartOrc, new Vector3(1000, 1000, 1000), Quaternion.identity);
    }

    void MapLoader(int MapID)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        NewMap = Instantiate(Config.CamapaignMaps[MapID], MapPosition.position, Quaternion.identity);
        NewMap.GetComponent<MapSetting>().SetUseTouchCamera(TouchCamera);
        watch.Stop();
        Debug.Log("MapLoader" + watch.ElapsedMilliseconds);
    }
    public void GameReloader()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void NextMission()
    {
        LevelLoader.LevelToLoad = NewMap.GetComponent<MapSetting>().LevelNumber + 1;
        SceneManager.LoadScene(3);
    }
}

