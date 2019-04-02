using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Cubemaker : MonoBehaviour
{
    public GameObject Cube;
    private GameObject Grid;
    void Update()
    {
        Grid = GameObject.Find("Grid");
        if (Cube != null )
        {
            var NewCube = Instantiate(Cube, gameObject.transform);
            NewCube.transform.SetParent(Grid.transform);
            DestroyImmediate(gameObject);

        }
    }
}
