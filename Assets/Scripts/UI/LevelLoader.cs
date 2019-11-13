using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int LevelsWereUnBlocked;
    public static int LevelToLoad;
    void Start()
    {
        
    }

    // Update is called once per framess
    void Update()
    {
        
    }
    public IEnumerator LoadLevel (int LevelIndex)
    {
        LevelToLoad = LevelIndex;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(3);
    }
}
