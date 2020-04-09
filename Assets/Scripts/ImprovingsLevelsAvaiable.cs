using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovingsLevelsAvaiable : MonoBehaviour
{
    public int ImprovingsAvaiableLevel;

    void Start()
    {
        if (PlayerStats.GameWasFinished == true)
        {
            ImprovingsAvaiableLevel = 3;
        }
    }
}
