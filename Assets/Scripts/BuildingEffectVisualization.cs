using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEffectVisualization : MonoBehaviour
{
    public ParticleSystem StandartEffect;
    public ParticleSystem GoldenEffect;

    void Start()
    {
        if (gameObject.GetComponent<BuildingStats>().FilledCube.GetComponent<BuilderManager>().CubeTypeIndex == 2)
        {
            ActivateGoldEffect();
        }
        else
        {
            ActivateStandartEffect();
        }
    }
    public void ActivateGoldEffect()
    {
        GoldenEffect.Play();
        GoldenEffect.gameObject.GetComponent<AudioSource>().Play();
    }
    public void ActivateStandartEffect()
    {
        StandartEffect.Play();
    }

}
