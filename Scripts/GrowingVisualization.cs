using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingVisualization : MonoBehaviour
{
    public Animator TowerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Grow (int GrowIndex)
    {
        Debug.Log("Grow");
        TowerAnimator.SetInteger("GrowIndex", GrowIndex);
    }
}
