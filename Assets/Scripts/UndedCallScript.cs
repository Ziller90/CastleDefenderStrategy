using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndedCallScript : MonoBehaviour
{
    public Golem golem;
    public AudioSource Audio;
    public AudioClip[] StepsSounds;
    public EnemyBehaviour Enemy;
    void Start()
    {
        
    }
    void Call()
    {
        golem.Call();
    }
    void FootStep()
    {
        int Rand = Random.Range(0, StepsSounds.Length);
        Audio.clip = StepsSounds[Rand];
        Audio.Play();
    }
    void OnAttack()
    {
        Enemy.OnAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
