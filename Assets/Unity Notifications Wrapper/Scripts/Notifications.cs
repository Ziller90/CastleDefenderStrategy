using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotificationSamples;
using System;

public class Notifications : MonoBehaviour
{
    public GameNotificationsManager notificationsManager;
    int NotificationDelay;
    void InitializeNotification ()
    {
        GameNotificationChannel channel = new GameNotificationChannel("ReturnToGame", "MainNotification", "Need to return player in the game");
        notificationsManager.Initialize(channel);
    }
    void Start()
    {
        InitializeNotification();
        DontDestroyOnLoad(gameObject);
        CreateNotification();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTimeInput(string text)
    {
        if (int.TryParse(text, out int sec))
        {
            NotificationDelay = sec;
        }
    }
    public void CreateNotification()
    {
        CreateNotification("Don't stop :)", "Hey! You are on Level 7 in War Tower. Your kingdom waits for you, sir!", DateTime.Now.AddSeconds(10));
    }
    public void CreateNotification(string title, string body, DateTime time)
    {

        IGameNotification notification = notificationsManager.CreateNotification();
        if (notification != null)
        {
            Debug.Log("Work");
            notification.Title = title;
            notification.Body = body;
            notification.DeliveryTime = time;
            notification.LargeIcon = "orc";
            notificationsManager.ScheduleNotification(notification);
        }
    }

}
