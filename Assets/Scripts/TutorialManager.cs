using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TutorialManager : MonoBehaviour
{
    public GameObject PlayingUIElements;
    public GameObject[] Messages;
    public Transform CameraStartPositipn;
    public Transform MainCamera;
    public RTS_Cam.RTS_Camera MainCameraC;
    public TouchCamera TouchCameraC;
    public GameObject ArrowUnderGoldenMineCard;
    public GameObject ArrowTowerArcherCard;
    public GameObject ArrowBelowMomey;
    public GameObject ArrowUnderBombTower;
    public GameObject ArrowGoldenCoin;
    public GameObject TaskTextObj;
    public Text TaskText;
    public Text TaskTextBlack;
    public GameObject DoNotTouchPanel;
    public GameObject[] TowersCards;
    bool AlreadyStarted = false;
    bool AlreadyHighlighted = false;
    bool AlreadyFinded = false;
    bool AlreadyFindedFrame = false;
    bool AlreadyWin1 = false;
    bool AlreadyWin2 = false;
    bool AlreadyBuilded = false;
    bool AlreadyShowed = false;
    bool TimeToHighLight = false;
    public GameObject HighlightFrame;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject GoldenCube1;
    public GameObject GoldenCube2;
    public bool OrcsOnTheMap;
    public WinScript WinManager;
    public Translation[] ConsoleMessages;
    public MusicManager Music;



    void Start()
    {
        PlayingUIElements = LinksContainer.instance.PlayingUIElements;
        StartCoroutine(AnimationInstancing.AnimationManager.GetInstance().LoadAnimationAssetBundle(Application.streamingAssetsPath + "/AssetBundle/animationtexture"));
        Time.timeScale = 1;

        DoNotTouchPanel.SetActive(true);
        TouchCameraC.isFreezed = true;
        PlayingUIElements.SetActive(false);
        StartCoroutine(ShowMessage(0, 1.8f));
        TowersCards[0].SetActive(false);
        TowersCards[1].SetActive(false);
        TowersCards[2].SetActive(false);
        TowersCards[3].SetActive(false);
        TowersCards[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TaskTextBlack.text = TaskText.text;
        GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (GameObject.FindGameObjectWithTag("Crystal") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Crystal"));
        }
        if (Spawner3.GetComponent<CripsSpawner>().IsEmpty == true && WinManager.NoEnemies == true && AlreadyWin2 == false)
        {
            Music.StartCoroutine("StopMusic", 3);
            StartCoroutine("Win");
            AlreadyWin2 = true;
        }
        if (Spawner2.GetComponent<CripsSpawner>().IsEmpty == true && WinManager.NoEnemies == true && AlreadyShowed == false)
        {
            Messages[4].SetActive(true);
            PlayingUIElements.SetActive(false);
            AlreadyShowed = true;
        }
        if (GoldenCube2.GetComponent<BuilderManager>().BuildingFiled == 0 && AlreadyBuilded == false)
        {
            ArrowUnderBombTower.SetActive(false);
            StartCoroutine("NewGoldTower");
            GoldenCube2.GetComponent<BuilderManager>().IsHighLighted = false;
            GoldenCube2.GetComponent<Animator>().enabled = false;

            AlreadyBuilded = true;
        }
        if (OrcsOnTheMap == true && WinManager.NoEnemies == true && AlreadyWin1 == false)
        {
            PlayingUIElements.SetActive(false);
            Messages[3].SetActive(true);
            AlreadyWin1 = true;
        }
        if (GoldenCube2.GetComponent<BuilderManager>().IsHighLighted == true)
        {
            ArrowUnderBombTower.SetActive(true);
            TowersCards[2].SetActive(true);
            TowersCards[3].SetActive(true);
            TowersCards[2].GetComponent<Button>().enabled = true;

        }
        else
        {
            ArrowUnderBombTower.SetActive(false);
        }
        if (TimeToHighLight == true)
        {
            HighlightFrame = GameObject.FindGameObjectWithTag("HighLightFrame");
            if (HighlightFrame != null & AlreadyFindedFrame == false)
            {
                TaskText.text = ConsoleMessages[5].GetTranslatedText();
                ArrowTowerArcherCard.SetActive(true);
                GoldenCube2.GetComponent<BuilderManager>().BuildAbility = false;
                AlreadyFindedFrame = true;
            }
        }
        if (Towers.Length > 1 && AlreadyFinded == false)
        {
            TowersCards[1].SetActive(false);
            ArrowTowerArcherCard.SetActive(false);
            TaskText.text = ConsoleMessages[6].GetTranslatedText();
            TowersCards[1].GetComponent<Button>().interactable = false;
            Spawner1.SetActive(true);
            
            TouchCameraC.isFreezed = false;
            StartCoroutine("CameraUsing");
            AlreadyFinded = true;
        }
        if (GoldenCube1.GetComponent<BuilderManager>().IsHighLighted == true && AlreadyHighlighted == false)
        {
            DoNotTouchPanel.SetActive(false);
            TowersCards[4].SetActive(true);
            ArrowUnderGoldenMineCard.SetActive(true);
            TaskText.text = ConsoleMessages[1].GetTranslatedText();
            AlreadyHighlighted = true;
        }
        if (GoldenCube1.GetComponent<BuilderManager>().BuildingFiled == 2 && AlreadyStarted == false) // когда появилась шахта
        {
            GoldenCube1.GetComponent<Animator>().enabled = false;
            StartCoroutine("AboutResources");
            AlreadyStarted = true;
        }
    }
    IEnumerator ShowMessage(int MessageNumber, float Delay)
    {
        yield return new WaitForSeconds(Delay);
        Messages[MessageNumber].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Messages[MessageNumber - 1].SetActive(false);
    }
    public void NextOrcAttackMessage()
    {
        StartCoroutine(ShowMessage(1, 0));
    }
    public void NextFinalTipMessage()
    {
        PlayingUIElements.SetActive(true);
        Messages[4].SetActive(false);
        Spawner3.SetActive(true);
        TowersCards[0].SetActive(true);
        TowersCards[1].SetActive(true);
        TowersCards[2].SetActive(true);
        TowersCards[3].SetActive(true);
        TowersCards[4].SetActive(true);
        TowersCards[0].GetComponent<Button>().enabled = true;
        TowersCards[1].GetComponent<Button>().enabled = true;
        TowersCards[2].GetComponent<Button>().enabled = true;
        TowersCards[3].GetComponent<Button>().enabled = true;
        TowersCards[4].GetComponent<Button>().enabled = true;
        StartCoroutine("ThreeTwoOne");
    }
    public void NextMoreMoneyMessage()
    {
        DoNotTouchPanel.SetActive(false);
        Messages[1].SetActive(false);
        PlayingUIElements.SetActive(true);
        GoldenCube1.GetComponent<Animator>().enabled = true;
        TaskTextObj.SetActive(true);
        TaskText.text = ConsoleMessages[0].GetTranslatedText();
    }
    IEnumerator AboutResources()
    {
        MineScript Mine = GameObject.Find("Mine(Clone)").GetComponent<MineScript>();
        Destroy(GameObject.FindGameObjectWithTag("HighLightFrame"));
        TaskText.text = ConsoleMessages[2].GetTranslatedText();
        yield return new WaitForSeconds(1);
        Mine.MomentaryGoldProduce();
        Mine.StopAllCoroutines();
        ArrowUnderGoldenMineCard.SetActive(false);
        yield return new WaitForSeconds(0.9f);
        TaskText.text = ConsoleMessages[15].GetTranslatedText();
        ArrowGoldenCoin.SetActive(true);
        DoNotTouchPanel.SetActive(false);
    }
    IEnumerator GoldenCoinTook()
    {
        ArrowGoldenCoin.SetActive(false);
        TaskText.text = ConsoleMessages[3].GetTranslatedText();
        ArrowBelowMomey.SetActive(true);
        yield return new WaitForSeconds(5f);
        TaskTextObj.SetActive(false);
        ArrowBelowMomey.SetActive(false);
        PlayingUIElements.SetActive(false);
        Messages[2].SetActive(true);
    }

    
    public void NextArchersTowerMessage()
    {
        TaskTextObj.SetActive(true);
        PlayingUIElements.SetActive(true);
        Messages[2].SetActive(false);
        TowersCards[1].SetActive(true);
        TaskText.text = ConsoleMessages[4].GetTranslatedText();
        TimeToHighLight = true;
        DoNotTouchPanel.SetActive(false);
    }
    public void NextFirstWinMessage()
    {
        Messages[3].SetActive(false);
        PlayingUIElements.SetActive(true);
        StartCoroutine("BombTowerOnGoldenCell");
    }
    IEnumerator CameraUsing()
    {
        yield return new WaitForSeconds(3);
        TaskText.text = ConsoleMessages[7].GetTranslatedText();
        OrcsOnTheMap = true;
    }
    IEnumerator BombTowerOnGoldenCell()
    {
        TowersCards[0].GetComponent<Button>().enabled = false;
        TowersCards[1].GetComponent<Button>().enabled = false;
        TowersCards[2].GetComponent<Button>().enabled = false;
        TowersCards[3].GetComponent<Button>().enabled = false;
        TowersCards[4].GetComponent<Button>().enabled = false;

        TaskText.text = ConsoleMessages[8].GetTranslatedText();
        yield return new WaitForSeconds(4);
        TaskText.text = ConsoleMessages[9].GetTranslatedText();
        DoNotTouchPanel.SetActive(false);               // можно выбирать золотой куб
        GoldenCube2.GetComponent<Animator>().enabled = true;
        GoldenCube2.GetComponent<BuilderManager>().BuildAbility = true;
        TowersCards[0].GetComponent<Button>().enabled = false;
        TowersCards[3].GetComponent<Button>().enabled = false;
        TowersCards[4].GetComponent<Button>().enabled = false;

    }
    IEnumerator NewGoldTower()
    {
        TaskText.text = ConsoleMessages[10].GetTranslatedText();
        yield return new WaitForSeconds(3);
        TaskText.text = ConsoleMessages[11].GetTranslatedText(); 
        yield return new WaitForSeconds(5);
        TaskText.text = TaskText.text = ConsoleMessages[12].GetTranslatedText();
        Spawner2.SetActive(true);
    }
    IEnumerator ThreeTwoOne()
    {
        TaskText.text = ConsoleMessages[13].GetTranslatedText();
        yield return new WaitForSeconds(3);
        TaskText.text = "3..";
        yield return new WaitForSeconds(1);
        TaskText.text = "2..";
        yield return new WaitForSeconds(1);
        TaskText.text = "1..";
        yield return new WaitForSeconds(1);
        TaskText.text = TaskText.text = ConsoleMessages[14].GetTranslatedText(); 
    }
    IEnumerator Win ()
    {
        yield return new WaitForSeconds(1);
        Messages[5].SetActive(true);
        PlayingUIElements.SetActive(false);
        PlayerStats.Crystals = PlayerStats.Crystals + 10;
        PlayerStats.CampaignProgressIndex = 1;
        SavingSystem.SavePlayerData();
    }
    public void NextWin()
    {
        LevelLoader.LevelToLoad = 1;
        SceneManager.LoadScene(3);
    }
    public void Restart()
    {
        SceneManager.LoadScene(5);
    }
}
