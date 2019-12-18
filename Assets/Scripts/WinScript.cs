﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public MusicManager Music;
    public CripsSpawner[] Spawners;
    public bool AllpawnersAreEmpty;
    public bool Win;
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject WinPanel;
    public int CrystalsRewardForWin;
    bool AlreadyWon = false;
    public bool NoEnemies;
    CastleScript Castle;
    void Start()
    {
        Castle = LinksContainer.instance.Castle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Enemies.Count == 0)
        {
            NoEnemies = true;
        }
        else
        {
            NoEnemies = false;
        }

        AllSpawnersAreEmpty();
        if (AllpawnersAreEmpty == true && Enemies.Count == 0 && AlreadyWon == false && Castle.HP > 0) 
        {
            Win = true;
            WinPanel.SetActive(true);
            PlayerStats.Crystals += CrystalsRewardForWin;
            PlayerStats.CampaignProgressIndex++;
            Music.StartCoroutine("StopMusic", 3);
            AlreadyWon = true;
        }
      
    }
    void AllSpawnersAreEmpty ()
    {
        for (int i = 0; i < Spawners.Length; i++)
        {
            if (Spawners[i].GetComponent<CripsSpawner>().IsEmpty == true)
            {
                if (i == (Spawners.Length - 1)) 
                    AllpawnersAreEmpty = true;
            }
            else
            {
                return;
            }
        }
    }

}
