using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotificationSamples;
using System;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    private void Start()
    {

    }
    void CreateNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    void SendNotification()
    {
   
        var notification = new AndroidNotification();
        notification.Title = "War Tower";
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            notification.Text = "Отличное время для битвы!";
        }
        else
        {
            notification.Text = "Great time for battle!";
        }
        notification.LargeIcon = "orc";
        notification.FireTime = System.DateTime.Now.AddHours(24);
        notification.RepeatInterval = new TimeSpan(24, 0, 0);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
    private void OnApplicationPause(bool pause)
    {
        SendNotification();
    }
    private void OnApplicationQuit()
    {
        SendNotification();
    }
    
}
