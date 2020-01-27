using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomMessage : MonoBehaviour
{
    public Translation[] Messages;
    public Text Text;
    public Text TextShadow;

    void Awake()
    {
        int RandomNumber = Random.Range(0, Messages.Length);
        Text.text = Messages[RandomNumber].GetTranslatedText();
        TextShadow.text = Messages[RandomNumber].GetTranslatedText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
