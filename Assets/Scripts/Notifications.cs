using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Assertions;
using System.Globalization;

public static class Notifications
{
    static int hoursToSendNotification = 8;
    
     static AndroidNotification GetNotification()
    {
        var not = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default channel",
            Importance = Importance.High,
            Description = "Generic notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(not);

        var notification = new AndroidNotification();
        notification.Title = "KnifeHitCopy";
        notification.SmallIcon = "icon_0";
        notification.Text = "¬ас давно не было в игре, мы соскучились!";
        notification.FireTime = System.DateTime.Now.AddHours(hoursToSendNotification);

        return notification;
    }

    public static void SendNotification()
    {
        AndroidNotificationCenter.SendNotification(GetNotification(), "channel_id");
    }

    public static void CancelNotification()
    {
        AndroidNotificationCenter.CancelNotification(GetNotification().Number);
    }
}
