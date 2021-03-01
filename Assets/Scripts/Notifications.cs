using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Assertions;
using System.Globalization;

public static class Notifications
{
    static int hoursToSendNotification = 8;
    
    public static void GetNotification()
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
        notification.Text = "Вас давно не было в игре, мы соскучились!";
        notification.FireTime = System.DateTime.Now.AddHours(hoursToSendNotification);

        if (PlayerPrefs.HasKey("TimeOnExit"))
        {
            System.TimeSpan timePassed = System.DateTime.Now - System.DateTime.ParseExact(PlayerPrefs.GetString("TimeOnExit"), "u", CultureInfo.InvariantCulture); //получаем разницу между настоящим временем и последним запуском
            if (timePassed.Hours > hoursToSendNotification)
            {
                AndroidNotificationCenter.SendNotification(notification, "channel_id");
            }
            else
            {
                AndroidNotificationCenter.CancelNotification(notification.Number);
            }
        }
    }
}
