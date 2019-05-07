using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Cubemaker : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Grid;
    void Start ()
    {
        Grid = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        if (Cube != null )
        {
            Grid = gameObject.transform.parent.gameObject;
            var NewCube = Instantiate(Cube, gameObject.transform.position, Quaternion.identity);
            NewCube.transform.SetParent(Grid.transform);
            DestroyImmediate(gameObject);
            Cube = null;
        }
    }
}
