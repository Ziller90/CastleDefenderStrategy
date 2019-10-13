using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LanguageText : MonoBehaviour
{
    Text Text;
    public Translation Translation;
    void Awake()
    {
        Text = gameObject.GetComponent<Text>();
        Text.text = Translation.GetTranslatedText();
    }
    void Start()
    {
        Text = gameObject.GetComponent<Text>();
        Text.text = Translation.GetTranslatedText();
    }
    void Update ()
    {
        //Text.text = Translation.GetTranslatedText();
    }
}
