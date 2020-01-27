using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Difficulty : MonoBehaviour
{
    public Button EasyB;
    public Button MediumB;
    public Button HighB;


    void Start()
    {
        if (PlayerStats.DifficultyLevelIndex == 0)
        {
            PlayerStats.DifficultyLevelIndex = 2;
        }
        if (PlayerStats.DifficultyLevelIndex == 1)
        {
            EasyB.interactable = false;
            MediumB.interactable = true;
            HighB.interactable = true;
        }
        if (PlayerStats.DifficultyLevelIndex == 2)
        {
            EasyB.interactable = true;
            MediumB.interactable = false;
            HighB.interactable = true;
        }
        if (PlayerStats.DifficultyLevelIndex == 3)
        {
            EasyB.interactable = true;
            MediumB.interactable = true;
            HighB.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Easy()
    {
        PlayerStats.DifficultyLevelIndex = 1;
        EasyB.interactable = false;
        MediumB.interactable = true;
        HighB.interactable = true;
        PlayerPrefs.SetInt("DifficultyLevel", 1);

    }
    public void Normal()
    {
        PlayerStats.DifficultyLevelIndex = 2;
        EasyB.interactable = true;
        MediumB.interactable = false;
        HighB.interactable = true;
        PlayerPrefs.SetInt("DifficultyLevel", 2);

    }
    public void Hardcore()
    {
        PlayerStats.DifficultyLevelIndex = 3;
        EasyB.interactable = true;
        MediumB.interactable = true;
        HighB.interactable = false;
        PlayerPrefs.SetInt("DifficultyLevel", 3);

    }
}


