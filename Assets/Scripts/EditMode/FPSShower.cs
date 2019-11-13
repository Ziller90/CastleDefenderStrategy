using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class FPSShower : MonoBehaviour
{
    public Text text;

    void Start ()
    {
        StartCoroutine("Repite");
    }
    void Update()
    {

    }
    IEnumerator Repite()
    {
        yield return new WaitForSeconds(0.3f);
        text.text = "FPS: " + ((int)(1f / Time.deltaTime));
        StartCoroutine("Repite");
    }
}
