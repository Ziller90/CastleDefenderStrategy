using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessagesManager : MonoBehaviour
{
    public GameObject[] Messages;
    MusicManager Music;
    GameObject PlayingUIElements;
    int CurrentMessageNumber;
    GameObject NewMessageButton;
    int MessageButtonMessageNumber;
    public bool HaveStartMessage;
    public bool HideUIPlayElements;
    void Awake ()
    {

    }
    void Start()
    {
        NewMessageButton = LinksContainer.instance.NewMessageButton;
        PlayingUIElements = LinksContainer.instance.PlayingUIElements;
        NewMessageButton.SetActive(false);
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
        Debug.Log("fefef " + MessageNumber);
        NewMessageButton.SetActive(true);
        MessageButtonMessageNumber = MessageNumber;
    }
    public void ShowNewMessageButtonOnClick ()
    {
        NewMessageButton.SetActive(false);
        ShowMessage(MessageButtonMessageNumber);
        CurrentMessageNumber = MessageButtonMessageNumber;
        Debug.Log("Bitton  " + CurrentMessageNumber);
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
