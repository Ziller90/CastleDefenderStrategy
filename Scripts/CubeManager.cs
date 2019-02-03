using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeScriptableObject Cube;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = Cube.CubeMaterial;
    }

    void Update()
    {
        
    }
}
