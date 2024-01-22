using Plugin.Geofence;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WeCharge.Helpers;
using WeCharge.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Services
{

    public class GeolocationService : IGeofenceListener
    {
        public Position LastKnownLocation { get; private set; }

        public GeolocationService()
        {

        }

        public void OnMonitoringStarted(string region)
        {
        }

        public void OnMonitoringStopped()
        {
        }

        public void OnMonitoringStopped(string identifier)
        {
        }

        public void OnError(string error)
        {
        }

        public void OnLocationChanged(GeofenceLocation geofenceLocation)
        {

        }

        // Note that you must call CrossGeofence.GeofenceListener.OnAppStarted() from your app when you want this method to run.
        public void OnAppStarted()
        {
        }

        public void OnRegionStateChanged(GeofenceResult result)
        {
            if (result == null)
                return;

            RegionChangedCall(result, 1);
        }

        public async void RegionChangedCall(GeofenceResult result, int count)
        {
            Device.BeginInvokeOnMainThread(() => { 
            App.Current.MainPage.DisplayAlert(result.Transition == GeofenceTransition.Entered ? "Entered" : "Exit", "Test", "OK");
            });
        }

        public async Task Start()
        {
            Debug.WriteLine($"Geo located");
            try
            {
                PermissionStatus permissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
                if (permissionStatus == PermissionStatus.Granted && CrossGeolocator.Current.IsGeolocationAvailable)
                {
                    await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(10), 0, true, new Plugin.Geolocator.Abstractions.ListenerSettings
                    {
                        ActivityType = ActivityType.Other,
                        PauseLocationUpdatesAutomatically = false,
                        AllowBackgroundUpdates = false,
                        ListenForSignificantChanges = true,
                    });
                    CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
                    var LastLocation = await Geolocation.GetLastKnownLocationAsync();
                    if (LastLocation != null && LastKnownLocation == null)
                    {
                        LastKnownLocation = new Position { Latitude = LastLocation.Latitude, Longitude = LastLocation.Longitude };
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        StoppableTimer stoppableTimer;
        public void StartTimer()
        {
            if (stoppableTimer != null)
            {
                stoppableTimer.Stop();
            }
            if (stoppableTimer == null)
            {
                stoppableTimer = new StoppableTimer(TimeSpan.FromSeconds(10), CheckPermissionIfGranted);
            }
            stoppableTimer.Start();

        }

        async void CheckPermissionIfGranted()
        {
            if (LastKnownLocation == null)
            {
                await Start();
                if (LastKnownLocation != null)
                    stoppableTimer.Stop();
            }
            else
                stoppableTimer.Stop();
        }


        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            LastKnownLocation = e.Position;

        }

        public void Stop()
        {
            //_listener?.Dispose();
        }

        public async void UpdateState()
        {
            // Check if user still eligible to the geolocation feature
            if (await Permissions.CheckStatusAsync<Permissions.LocationAlways>() == PermissionStatus.Granted && CrossGeolocator.Current.IsGeolocationAvailable)
            {
                // Start the geolocation ping if not already running
                // if (_listener == null)
                //SetGeoTimer();

                return;
            }

            // Stop geofences service
            this.Stop();
            Debug.WriteLine("Geofence service stopped");
        }
    }

    //public class GeofencesEnteredEventArgs : EventArgs
    //{
    //    public Geofence Geofence { get; set; }
    //    public DateTime TimeEntered { get; set; }
    //}
    //public class GeofencesLeftEventArgs : EventArgs
    //{
    //    public Geofence Geofence { get; set; }
    //    public DateTime TimeEntered { get; set; }
    //}
}
