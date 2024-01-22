using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;

namespace WeCharge.Droid.Services
{
    [Service(Exported =false)]
    public class GeofenceService : Service
    {
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10001;
        public override void OnCreate()
        {
            base.OnCreate();

            System.Diagnostics.Debug.WriteLine("Geofence Service - Created");
        }

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Started");
            return StartCommandResult.Sticky;
        }

        public override Android.OS.IBinder OnBind(Android.Content.Intent intent)
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Binded");
            return null;
        }

        public override void OnDestroy()
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Destroyed");
            base.OnDestroy();
        }
    }
}

