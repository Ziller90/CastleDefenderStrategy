using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsManager : MonoBehaviour
{
    public GameObject GreenCrystal;
    public GameObject BlueCrystal;
    public GameObject RedCrystal;
    public int EnemyValue;
    int ProbabilytyOfGreenCrystal;
    int ProbabilytyOfBlueCrystal;
    int ProbabilityOfRedCrystal;



    public int ProbabilityOfCrystalDrop;
    void Start()
    {
        ProbabilytyOfGreenCrystal = 65;
        ProbabilytyOfBlueCrystal = 35;
        ProbabilityOfRedCrystal = -5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IfCrystalsDrop ()
    {
        int RandomNumber;
        RandomNumber = Random.Range(0, 100);
        if (RandomNumber < ProbabilityOfCrystalDrop)
        {
            Debug.Log("ChangeCrystal...");
            ChangeCrystalsType();
        }
    }
    void ChangeCrystalsType()
    {
        int RandomNumber;
        RandomNumber = Random.Range(0, 100);
        if (RandomNumber + EnemyValue <= ProbabilytyOfGreenCrystal)
            DropCrystal(GreenCrystal);
        if (RandomNumber + EnemyValue > ProbabilytyOfGreenCrystal && RandomNumber + EnemyValue < ProbabilytyOfGreenCrystal + ProbabilytyOfBlueCrystal)
            DropCrystal(BlueCrystal);
        if (RandomNumber + EnemyValue > 100 - ProbabilityOfRedCrystal)
            DropCrystal(RedCrystal);
    }
    void DropCrystal(GameObject CrystalType)
    {
        Instantiate(CrystalType, gameObject.transform.position, Quaternion.identity);
    }
}
