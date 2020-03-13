using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPanelScript : MonoBehaviour
{
    public GameObject MenuButtons;
    public LevelLoader levelLoader;
    public MainMenuButtons mainMenuButtons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseLevelsPanel()
    {
        gameObject.SetActive(false);
        MenuButtons.SetActive(true);
    }
    public void LoadLevel(int LevelIndex)
    {
        if (PlayerStats.GameWasFinished == true)
        {
            levelLoader.LoadLevel(LevelIndex);
        }
        else
        {
            PlayerStats.CampaignProgressIndex = LevelIndex;
            levelLoader.LoadLevel(LevelIndex);
        }
        mainMenuButtons.StartCoroutine("Fading", 3);
    }
}
