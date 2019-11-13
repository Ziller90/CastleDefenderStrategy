using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageButton : MonoBehaviour
{
    public Texture[] Flags;
    RawImage ButtonImage;
    public LanguageText[] Texts;
    void Start()
    {
        ButtonImage = gameObject.GetComponent<RawImage>();
        if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.English)
        {
            ButtonImage.texture = Flags[0];
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Russian)
        {
            ButtonImage.texture = Flags[1];
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Japan)
        {
            ButtonImage.texture = Flags[2];
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Korean)
        {
            ButtonImage.texture = Flags[3];;
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Spanish)
        {
            ButtonImage.texture = Flags[4];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.English)
        {
            ButtonImage.texture = Flags[1];
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Russian;
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Russian)
        {
            ButtonImage.texture = Flags[2];
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Japan;
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Japan)
        {
            ButtonImage.texture = Flags[3];
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Korean;
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Korean)
        {
            ButtonImage.texture = Flags[4];
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.Spanish;
        }
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Spanish)
        {
            ButtonImage.texture = Flags[0];
            GlobalLanguageManager.Language = GlobalLanguageManager.GloabalLanguage.English;
        }
        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].ChangeLanguage();
        }

    }
}
