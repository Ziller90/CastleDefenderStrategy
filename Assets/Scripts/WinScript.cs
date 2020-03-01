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
        Castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<CastleScript>();

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
        if (PlayerStats.CampaignProgressIndex == 10)
        {
            GameObject.Find("FireWorks").GetComponent<FinalWinScript>().StartCoroutine("SalutStarts");
        }
        else
        {
            Win = true;
            WinPanel.SetActive(true);
            PlayerStats.Crystals += CrystalsRewardForWin;
            PlayerStats.CampaignProgressIndex++;
            Music.StartCoroutine("StopMusic", 3);
            AlreadyWon = true;
        }
    }
    IEnumerator WinWindowShow()
    {
        if (PlayerStats.CampaignProgressIndex == 10)
        {
            GameObject.Find("FireWorks").GetComponent<FinalWinScript>().StartCoroutine("SalutStarts");
        }
        else
        {
            yield return new WaitForSeconds(2);
            Win = true;
            WinPanel.SetActive(true);
            PlayerStats.Crystals += CrystalsRewardForWin;
            PlayerStats.CampaignProgressIndex++;
            SavingSystem.SavePlayerData();
            CrystalsForWin.text = CrystalsRewardForWin.ToString();
            CrystalsForWinShad.text = CrystalsRewardForWin.ToString();
            Music.StartCoroutine("StopMusic", 3);
            AlreadyWon = true;
        }
    }
}
