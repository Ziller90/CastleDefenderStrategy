using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCube", menuName = "Cube")]
public class CubeScriptableObject : ScriptableObject
{
    public string CubeType;

    public Material CubeMaterial;
}
