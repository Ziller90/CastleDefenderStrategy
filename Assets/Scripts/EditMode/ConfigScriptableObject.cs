﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConfig", menuName = "Config")]
public class ConfigScriptableObject : ScriptableObject
{
    public GameObject[] CamapaignMaps;
}
