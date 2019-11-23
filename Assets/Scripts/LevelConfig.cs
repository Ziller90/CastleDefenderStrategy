using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLEvel", menuName = "Level")]
public class LevelConfig : ScriptableObject
{
    public int LevelNumber;
    public string LevelName;
    public int CrystalsRewardForWin;
}
