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

    void Start()
    {
        Debug.Log("Loaded " + LevelLoader.LevelToLoad);
        MapLoader(LevelLoader.LevelToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MapLoader (int MapID)
    {
        NewMap = Instantiate(Config.CamapaignMaps[MapID], MapPosition.position, Quaternion.identity);
        NewMap.GetComponent<MapSetting>().SetUseTouchCamera(TouchCamera);
        NewMap.transform.Rotate(0, NewMap.GetComponent<MapSetting>().Rotate,0);

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

