using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTranslation", menuName = "Translation")]
[ExecuteInEditMode]
public class Translation : ScriptableObject
{
    [TextArea]
    public string EnglishVersion;
    [TextArea]
    public string RussianVersion;
    [TextArea]
    public string JapanVersion;
    [TextArea]
    public string KoreanVersion;
    [TextArea]
    public string SpanishVersion;
    [TextArea]
    public string CurrentLanguageVersion;




    public string GetTranslatedText()
    {
        if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.English)
            return EnglishVersion;
        else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Russian)
            return RussianVersion;
        //else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Japan)
        //    return JapanVersion;
        //else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Korean)
        //    return KoreanVersion;
        //else if (GlobalLanguageManager.Language == GlobalLanguageManager.GloabalLanguage.Spanish)
        //    return SpanishVersion;
        else
            return "#####";
    }


    // Update is called once per frame
}
