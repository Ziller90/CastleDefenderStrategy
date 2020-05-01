using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Text CrystalsForWin;
    public Text CrystalsForWinShad;
    void Start()
    {
        Castle = LinksContainer.instance.Castle;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CrystalsForWin.text = "+" + CrystalsRewardForWin.ToString();
        CrystalsForWinShad.text = "+" + CrystalsRewardForWin.ToString();
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
            StartCoroutine("WinWindowShow");
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
    public void MomomentaryWin ()
    {
        if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber == 10)
        {
            GameObject.Find("FireWorks").GetComponent<FinalWinScript>().StartCoroutine("SalutStarts");
        }
        else
        {
            Win = true;
            WinPanel.SetActive(true);
            if (PlayerStats.GameWasFinished == false)
            {
                PlayerStats.CampaignProgressIndex = LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber + 1;
            }
            Music.StartCoroutine("StopMusic", 3);
            AlreadyWon = true;
        }
    }
    IEnumerator WinWindowShow()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        if (LinksContainer.instance.gameSarter.CurrentLevelCampaignIndex == 10)
        {
            GameObject.Find("FireWorks").GetComponent<FinalWinScript>().StartCoroutine("SalutStarts");
            PlayerStats.CampaignProgressIndex = LinksContainer.instance.gameSarter.CurrentLevelCampaignIndex + 1;
        }
        else
        {
            yield return new WaitForSeconds(2);
            Win = true;
            WinPanel.SetActive(true);
            Music.StartCoroutine("StopMusic", 3);
            if (PlayerStats.GameWasFinished == false)
            {
                PlayerStats.CampaignProgressIndex++;
            }
            GiveRewardToPlayer();
            SavingSystem.SavePlayerData();
            AlreadyWon = true;
        }
        Debug.Log("GameUIManager " + watch.ElapsedMilliseconds);
    }
    public void GiveRewardToPlayer()
    {
        PlayerStats.Crystals = PlayerStats.Crystals + CrystalsRewardForWin;
    }
}
