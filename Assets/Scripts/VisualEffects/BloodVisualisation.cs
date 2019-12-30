using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVisualisation : MonoBehaviour
{
    public ParticleSystem BloodParticles;
    public float LastDamageTime;
    public float StopBloodDelay;
    bool CanBlood;
     

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastDamageTime > StopBloodDelay)
        {
            CanBlood = true;
        }
    }
    public void ShowParticles()
    {
        if (CanBlood)
        {
            LastDamageTime = Time.time;
            CanBlood = false;
            BloodParticles.Play();
        }
    }

}
