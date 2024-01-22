
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Plugin.Geofence;
using WeCharge.Droid.Services;
using WeCharge.Services;

namespace WeCharge.Droid
{
    [Android.App.Application]
    public class MainApplication : Android.App.Application
    {
        public static Context AppContext;
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            AppContext = this.ApplicationContext;

            CrossGeofence.Initialize<GeolocationService>();
            CrossGeofence.GeofenceListener.OnAppStarted();
            //StartService();
        }

        private bool isMyServiceRunning(System.Type cls)
        {
            ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);

            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
                {
                    return true;
                }
            }
            return false;
        }

        public static void StartService()
        {
            ActivityManager manager = (ActivityManager)MainApplication.AppContext.GetSystemService(Context.ActivityService);

            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(typeof(GeofenceService)).CanonicalName))
                {
                    return;
                }
            }
            AppContext.StartService(new Intent(AppContext, typeof(GeofenceService)));

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                PendingIntentFlags flags = 0;  // Default flag

                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
                {
                    flags |= (PendingIntentFlags)Android.App.PendingIntentFlags.Immutable;  // For Android 12 and above
                }

                PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(GeofenceService)), flags);
                AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }


        public static void StopService()
        {
            AppContext.StopService(new Intent(AppContext, typeof(GeofenceService)));

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                PendingIntentFlags flags = 0;  // Default flag

                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
                {
                    flags |= (PendingIntentFlags)Android.App.PendingIntentFlags.Immutable;  // For Android 12 and above
                }

                PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(GeofenceService)), flags);
                AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }

    }
}
