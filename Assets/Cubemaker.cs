using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class Cubemaker : MonoBehaviour
{
#if UNITY_EDITOR
    public GameObject Cube;
    public GameObject Grid;
    public bool ChangeCube = false;
    void Start ()
    {
        Grid = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        if (Application.isPlaying == false)
        {
            if (ChangeCube == true)
            {
                Grid = gameObject.transform.parent.gameObject;
                var NewCube = Instantiate(Cube);
                NewCube.transform.SetParent(Grid.transform);
                NewCube.transform.position = gameObject.transform.position;
                NewCube.transform.localRotation = gameObject.transform.localRotation;
                ChangeCube = false;
                gameObject.transform.position = new Vector3(0, -10, 0);
                PrefabUtility.ApplyPrefabInstance(NewCube, InteractionMode.AutomatedAction);
            }
        }
    }
#endif 
}
