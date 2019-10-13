using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GraphicSettingsManager : MonoBehaviour
{
    public Button LowB;
    public Button MediumB;
    public Button HighB;


    void Start()
    {
        if (QualitySettings.GetQualityLevel() == 1)
        {
            LowB.interactable = false;
            MediumB.interactable = true;
            HighB.interactable = true;
        }
        if (QualitySettings.GetQualityLevel() == 2)
        {
            LowB.interactable = true;
            MediumB.interactable = false;
            HighB.interactable = true;
        }
        if (QualitySettings.GetQualityLevel() == 4)
        {
            LowB.interactable = true;
            MediumB.interactable = true;
            HighB.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Low ()
    {
        QualitySettings.SetQualityLevel(1);
        LowB.interactable = false;
        MediumB.interactable = true;
        HighB.interactable = true;
        PlayerPrefs.SetInt("GraphicSettingsIndex", 1);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(2);
        LowB.interactable = true;
        MediumB.interactable = false;
        HighB.interactable = true;
        PlayerPrefs.SetInt("GraphicSettingsIndex", 2);
    }
    public void High()
    {
        QualitySettings.SetQualityLevel(4);
        LowB.interactable = true;
        MediumB.interactable = true;
        HighB.interactable = false;
        PlayerPrefs.SetInt("GraphicSettingsIndex", 3);
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
