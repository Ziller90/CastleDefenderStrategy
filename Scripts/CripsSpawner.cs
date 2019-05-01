using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CripsSpawner : MonoBehaviour
{
    public int SquadCounter;
    public int[] SquadTime;
    public int[] AmountOFCrips;
    public GameObject[] Crips;
    public float[] SpawningTime;
    void Start()
    {
        StartCoroutine("SquadLoader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SquadLoader ()
    {
        for (SquadCounter = 0; SquadCounter < SquadTime.Length; SquadCounter++)
        {
            yield return new WaitForSeconds(SquadTime[SquadCounter]);
            StartCoroutine("SquadMaker");
            yield return new WaitForSeconds(SpawningTime[SquadCounter] * AmountOFCrips[SquadCounter] + 1);
            Debug.Log("shit1");
        }
    }
    IEnumerator SquadMaker ()
    {
        Debug.Log(SquadCounter);
        for (int CripsCounter = 0; CripsCounter < AmountOFCrips[SquadCounter]; CripsCounter++)
        {
            Instantiate(Crips[SquadCounter], gameObject.transform.transform);
            yield return new WaitForSeconds(SpawningTime[SquadCounter]);
        }
        Debug.Log("Squad was maded");
    }
}
