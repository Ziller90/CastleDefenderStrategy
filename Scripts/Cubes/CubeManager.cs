using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeManager : MonoBehaviour
{
    public CubeScriptableObject Cube;
    public GameObject HighLightFrame;
    public GameObject HighlightFramepoint;
    public GameObject Frame;
    [ExecuteInEditMode]


    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material = Cube.CubeMaterial;
    }
    void OnMouseDown()
    {
        Frame = Instantiate(HighLightFrame, HighlightFramepoint.transform.position, Quaternion.identity);
    }
    void OnMouseExit()
    {
        Destroy(Frame);
    }
}
