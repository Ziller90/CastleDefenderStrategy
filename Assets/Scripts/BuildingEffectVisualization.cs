using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEffectVisualization : MonoBehaviour
{
    public GameObject StandartEffect;
    public GameObject GoldenEffect;

    void Start()
    {
        if (gameObject.GetComponent<BuildingStats>().FilledCube.GetComponent<BuilderManager>().CubeTypeIndex == 2)
        {
            StandartEffect.SetActive(false);
        }
        else
        {
            GoldenEffect.SetActive(false);
        }
    }

    // Update is called once per frame

}
