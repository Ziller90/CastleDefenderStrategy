﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingVisualization : MonoBehaviour
{
    public Animator TowerAnimator;

    // Update is called once per frame
    public void Grow (int GrowIndex)
    {
        Debug.Log("Grow");
        TowerAnimator.SetInteger("GrowIndex", GrowIndex);
    }
}
