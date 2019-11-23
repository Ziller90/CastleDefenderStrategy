using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessagesManager : MonoBehaviour
{
    public GameObject[] Messages;
    public GameObject MessagesBox;
    MusicManager Music;
    GameObject PlayingUIElements;
    int CurrentMessageNumber;
    GameObject NewMessageButton;
    int MessageButtonMessageNumber;
    public bool HaveStartMessage;
    public bool HideUIPlayElements;
    void Awake ()
    {
        MessagesBox = GameObject.Find("MessageBox");
        for (int i = 0; i < MessagesBox.transform.childCount; i++)
        {
            MessagesBox.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void Start()
    {
        NewMessageButton = GameObject.Find("NewMessageButton");
        NewMessageButton.SetActive(false);
        PlayingUIElements = GameObject.Find("PlayingUIElements");
        if (HaveStartMessage)
        {
            StartCoroutine("StartMessage", 2);
        }
        if (HideUIPlayElements == true)
        {
            HideUI();
        }
    }

    // Update is called once per frame
    public void ShowMessage(int MessageNumber)
    {
        Messages[MessageNumber].SetActive(true);
        CurrentMessageNumber = MessageNumber;
    }
    public void HideMessageButton ()
    {
        Messages[CurrentMessageNumber].gameObject.SetActive(false);
    }
    public void ShowNewMessageButton (int MessageNumber)
    {
        NewMessageButton.SetActive(true);
        MessageButtonMessageNumber = MessageNumber;
    }
    public void ShowNewMessageButtonOnClick ()
    {
        NewMessageButton.SetActive(false);
        ShowMessage(MessageButtonMessageNumber);
        CurrentMessageNumber = MessageButtonMessageNumber;
        StartCoroutine("StopTimeAfterMessage");
    }
    public IEnumerator StartMessage(float Time)
    {
        yield return new WaitForSeconds(Time);
        ShowMessage(0);
        GameObject.Find("OK!").GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.5f);
        StopTime();
        GameObject.Find("OK!").GetComponent<Button>().interactable = true;
    }
    public void StopTime ()
    {
        Time.timeScale = 0;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
    public IEnumerator StopTimeAfterMessage ()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }
    public void HideUI()
    {
        PlayingUIElements.SetActive(false);
    }
    public void ShowUI()
    {
        PlayingUIElements.SetActive(true);

    }

}
