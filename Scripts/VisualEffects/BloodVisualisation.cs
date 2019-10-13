using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVisualisation : MonoBehaviour
{
    public ParticleSystem BloodParticles;
    public float LastDamageTime;
    public float StopBloodDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastDamageTime > StopBloodDelay)
        {
            HideParticles();
        }
    }
    public void ShowParticles()
    {
        LastDamageTime = Time.time;
        if (BloodParticles.isPlaying == false)
        {
            BloodParticles.Play();
        }
    }
    public void HideParticles()
    {
        BloodParticles.Stop();
    }
}
