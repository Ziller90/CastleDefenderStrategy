using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SaveData");
        DontDestroyOnLoad(gameObject);
    }
    IEnumerator SaveData()
    {
        yield return new WaitForSeconds(10);
        SavingSystem.SavePlayerData();
        Debug.Log("Saving...");
        StartCoroutine("SaveData");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
