using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CripsSpawner : MonoBehaviour
{
    public int SquadCounter;
    public int CripsCounter;
    public int[] SquadTime;
    public int[] AmountOFCrips;
    public GameObject[] Crips;
    public int[] RoutesNumber;
    public float[] SpawningTime;
    public int[] MessageTrigger;
    public EnemyBehaviour NewEnemyController;
    public bool IsEmpty;
    public MessagesManager MessagesManager;
    bool AlreadyStartedCoroutine;
    public WayManager wayManager;
    public bool StartedSpawning;



    void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.746f, gameObject.transform.position.z);
        wayManager = GameObject.Find("WayManager").GetComponent<WayManager>();
        MessagesManager = GameObject.FindGameObjectWithTag("Level").GetComponent<MessagesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AlreadyStartedCoroutine == false)
        {
            StartCoroutine("SquadLoader");
            AlreadyStartedCoroutine = true;
        }
        if (SquadCounter == SquadTime.Length && CripsCounter == AmountOFCrips[SquadCounter - 1])
        {
            IsEmpty = true;
        }
    }
    IEnumerator SquadLoader ()
    {
        if (SquadCounter == 0)
        {
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(SquadTime[SquadCounter]);
        StartedSpawning = true;
        if (MessageTrigger[SquadCounter] > 0)
        {
            if (PlayerStats.GameWasFinished == false)
            StartCoroutine("ButtonShowing");
        }
        for (CripsCounter = 0; CripsCounter < AmountOFCrips[SquadCounter]; CripsCounter++)
        {
            float Rand = Random.Range(0, 0.1f);
            yield return new WaitForSeconds(Rand);
            GameObject NewCrip = Instantiate(Crips[SquadCounter], gameObject.transform.transform);
            NewEnemyController = NewCrip.transform.GetChild(1).gameObject.GetComponent<EnemyBehaviour>();
            NewEnemyController.RouteNumber = RoutesNumber[SquadCounter];
            NewEnemyController.WayPoints = wayManager.Ways[NewEnemyController.RouteNumber].WayPoints;
            yield return new WaitForSeconds(SpawningTime[SquadCounter]);
        }
        SquadCounter++;
        AlreadyStartedCoroutine = false;
    }
    IEnumerator ButtonShowing()
    {
        Debug.Log("Problem " + MessageTrigger[SquadCounter]);
        yield return new WaitForSeconds(0.1f);
        MessagesManager.ShowNewMessageButton(MessageTrigger[SquadCounter]);
    }
}
