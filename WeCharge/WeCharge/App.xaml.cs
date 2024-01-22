using System;
using System.Threading.Tasks;
using WeCharge.APIServices.WebServices;
using WeCharge.CustomControls;
using WeCharge.Services;
using WeCharge.Views;
using WeCharge.Views.Accounts;
using WeCharge.Views.BottomTab;
using WeCharge.Views.MakeBooking;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.Popup;
using WeCharge.Model.MakeBooking;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using WeCharge.Models.Booking;
using WeCharge.ViewModels;
using WeCharge.Models.RequestModels;

namespace WeCharge
{
    public partial class App : Application
    {

        public static string BookingId { get; set; }
        public static string cancelBookingDate { get; set; }
        public static Position position { get; set; }
        public static Position CurrentPosition { get; set; }
        public static CustomPin customPin { get; set; }
        public static string emailPattern = @"^(?!\.)[\w\-+.]+@(?!-)[\w\-]+\.[a-zA-Z]{2,7}(?<!-)$";

        public static ChargingLocationsResponse chargingLocationsResponses;
        public static List<CustomPin> pinLocations { get; set; }
        public const string DateFormat = "yyyy-MM-ddTHH:mm:ss.ffffff";
        public const string UtcOffsetFormat = "zzz";
        public static string Token;
        public static bool IsApiBusy;
        public const string DateTimeHeaderKey = "Lotus-Agent-LocalDateTime";
        public const string DateTimeOffSetHeaderKey = "Lotus-Agent-LocalDateTimeUtcOffset";
        public static IWeChargeService weChargeService;
        public static ChargeEstimateRequest chargeEstimateRequest { get; set; }
        public static Booking booking { get; set; }
        public static Booking book { get; set; }
        public static MakeBooking MakeBookingLocation;
        public static GeolocationService GeoService { get; set; }
        public static TimerManager TimerManagerInstance { get; private set; }
        public App()
        {
            InitializeComponent();
            TimerManagerInstance = new TimerManager(TimeSpan.FromMinutes(15));
            TimerManagerInstance.Start();

            CheckAndRequestLocationPermission();
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            NetworkHelper.CallConnectivityChangedHandler();
            Permissions.RequestAsync<Permissions.LocationAlways>();
            weChargeService = new WeChargeService();
            CheckCredentialsAndNavigate();

        }

        private void CheckCredentialsAndNavigate()
        {
            var authToken = Preferences.Get("AuthToken", string.Empty);
            //var savedPassword = Preferences.Get("Password", string.Empty);

            if (!string.IsNullOrWhiteSpace(authToken))
            {
                // Navigate to AppShell if credentials are saved
                App.Current.MainPage = new AppShell();
            }
            else
            {
                // Navigate to LoginPage if credentials are not saved
                MainPage = new LoginPage(); // Ensure you have a LoginPage in your Views
            }
        }
        public static async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            //var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }

        protected async override void OnStart()
        {
            // Handle when your app starts

            GeoService = new GeolocationService();
            await GeoService.Start();
            GeoService.StartTimer();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            base.OnResume();
            GeoService.UpdateState();
            // Handle when your app resumes
        }
    }
}
