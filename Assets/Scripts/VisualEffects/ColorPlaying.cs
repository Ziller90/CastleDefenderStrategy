using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorPlaying : MonoBehaviour
{
    Color TextColor;
    public Text text;
    void Start()
    {
        TextColor.a = 255;
        StartCoroutine("Darker");
    }

    IEnumerator Darker()
    {
        for (int i = 255; i > 100; i--)
        {
            yield return new WaitForSeconds(0.01f);
            TextColor.r = i;
            TextColor.b = i;
            TextColor.g = i;
            text.color = TextColor;
        }
        StartCoroutine("Lighter");

    }
    IEnumerator Lighter()
    {
        for (int i = 100; i < 255; i++)
        {
            yield return new WaitForSeconds(0.01f);
            TextColor.r = i;
            TextColor.b = i;
            TextColor.g = i;
        }
        StartCoroutine("Darker");
    }
}
