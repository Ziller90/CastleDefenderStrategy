using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseResumeScript : MonoBehaviour
{
    public Texture PauseTexture;
    public Texture ResumeTexture;
    public RawImage ButtonImange;
    public bool Paused;

    // Update is called once per frame
    public void OnClick ()
    {
        if (Paused == false)
        {
            Paused = true;
            Time.timeScale = 0;
            ButtonImange.texture = ResumeTexture;
            ButtonImange.color = Color.red;
        }
        else
        {
            Paused = false;
            Time.timeScale = 1;
            ButtonImange.texture = PauseTexture;
            ButtonImange.color = Color.white;

        }

    }
}
