using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartButton : MonoBehaviour
{
    public LevelLoader Loader;
    public int ButtonIndex;
    void Start()
    {
        Loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick ()
    {
        Loader.StartCoroutine("LoadLevel", ButtonIndex);
    }
}
