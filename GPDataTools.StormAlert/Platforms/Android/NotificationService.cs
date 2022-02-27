using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using AndroidX.Core.App;
using GPDataTools.StormAlert.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPDataTools.StormAlert.Platforms.Android
{
    /// <summary>
    /// Android implementation of INotificationService
    /// </summary>
    public class NotificationService : INotificationService
    {
        private static Context Context;
        public const string CHANNEL_ID = "1";
        private const string CHANNEL_NAME = "Storm Alerts";

        public static void Init(Context context)
        {
            Context = global::Android.App.Application.Context;            
            var channel = new NotificationChannel(CHANNEL_ID, CHANNEL_NAME, NotificationImportance.Default);
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager.CreateNotificationChannel(channel);
        }

        public bool IsPushAllowed()
        {
            // not needed on Android
            return true;
        }
        public void RequestPermission()
        {
            // not needed on Android
        }

        public void ShowNotification(string title, string body)
        {
            // Set up an intent so that tapping the notifications returns to this app:
            Intent intent = new Intent(Context, typeof(MainActivity));

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =

            PendingIntent.GetActivity(Context, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements
            NotificationCompat.Builder builder = new NotificationCompat.Builder(Context, CHANNEL_ID)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(body)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                .SetDefaults((int)(NotificationDefaults.Sound | NotificationDefaults.Vibrate))
                .SetColorized(true)
                .SetSmallIcon(Resource.Drawable.error)
                .SetLargeIcon(BitmapFactory.DecodeResource(Context.Resources, Resource.Drawable.storm));

            // Build the notification
            Notification notification = builder.Build();

            //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)            
            //    builder.SetVisibility(Notification.Public);

            // Turn on vibrate:
            //notification.Defaults |= NotificationDefaults.Vibrate;

            // Get the notification manager
            NotificationManager notificationManager = Context.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);

            //            var alarmservice = Context.GetSystemService(Context.AlarmService);
            //            AlarmManager alarmManager = alarmservice.JavaCast<AlarmManager>();
            //            var timeToDisplay = DateTime.Now.ToString("HH:mm");
            //            var message = $"Beginn {timeToDisplay}";
            //            var alarmIntent = new Intent(Context, typeof(BroadcastReceiver));            
            //            alarmIntent.PutExtra("title", title);
            //            alarmIntent.PutExtra("message", body);
            //            alarmIntent.PutExtra("id", 1);

            //            DateTime dateTime;
            //#if DEBUG
            //            dateTime = DateTime.Now + new TimeSpan(0, 0, 3);
            //#else
            //                int minutesFromSettings = (int)AppSettings.ViewModel.NotificationMinutesBevorBand;
            //                dateTime = band.DateTime - new TimeSpan(0, minutesFromSettings, 0);
            //#endif
            //            DateTimeOffset dateOffsetValue = DateTimeOffset.Parse(dateTime.ToString());
            //            long millisecondsToBegin = 0;// dateOffsetValue.ToUnixTimeMilliseconds();

            //            PendingIntent pending = PendingIntent.GetBroadcast(Context, 1, alarmIntent, PendingIntentFlags.UpdateCurrent);
            //            Context.SendBroadcast(alarmIntent);

            //            // Add push
            //            //if (band.IsFavorite && dateTime > DateTime.Now && band.DateTime.Month != 1 && band.DateTime.Day != 1)
            //            //{
            //                alarmManager.Set(AlarmType.RtcWakeup, millisecondsToBegin, pending);
            //            //}
            //            //else
            //            //{
            //            //    pending.Cancel();
            //            //}
        }
    }
}
