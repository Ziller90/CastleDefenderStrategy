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
    WayManager wayManager;



    void Start()
    {
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
        yield return new WaitForSeconds(SquadTime[SquadCounter]);
        if (MessageTrigger[SquadCounter] > 0)
        {
            StartCoroutine("ButtonShowing");
        }
        for (CripsCounter = 0; CripsCounter < AmountOFCrips[SquadCounter]; CripsCounter++)
        {
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
        yield return new WaitForSeconds(3);
        MessagesManager.ShowNewMessageButton(MessageTrigger[SquadCounter]);
    }
}
