using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Cubemaker : MonoBehaviour
{
    public GameObject Cube;
    private GameObject Grid;
    void Start ()
    {
        Grid = GameObject.Find("Grid");
    }
    void Update()
    {
        if (Cube != null )
        {
            var NewCube = Instantiate(Cube, gameObject.transform.position, Quaternion.identity);
            NewCube.transform.SetParent(Grid.transform);
            DestroyImmediate(gameObject);
            Cube = null;
        }
    }
}
