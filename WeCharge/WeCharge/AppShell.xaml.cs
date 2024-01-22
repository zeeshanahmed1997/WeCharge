using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCharge.Models;
using WeCharge.Models.APIResponse;
using WeCharge.Views.Accounts;
using WeCharge.Views.Booking;
using WeCharge.Views.BottomTab;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge
{
    public partial class AppShell : Shell
    {
        public ICommand PreviousChargesCommand => new Command(async () => await NavigatedToPreviousCharges());
        public ICommand UpcomingBookingCommand => new Command(async () => await NavigatedToUpcomingBooking());
        public ICommand MakeBookingCommand => new Command(async () => await NavigatedToMakeBooking());
        public ICommand LogoutCommand => new Command(async () => await Logout());

        public ICommand UpdateProfileCommand => new Command(async () => await NavigatedToUpdateProfile());
        public AppShell()
        {
            RegisterPages();
            InitializeComponent();
            
            BindingContext = this;
        }

        protected override void OnTabIndexPropertyChanged(int oldValue, int newValue)
        {
            base.OnTabIndexPropertyChanged(oldValue, newValue);
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            try
            {
                if (args.Source == ShellNavigationSource.ShellSectionChanged && Shell.Current != null)
                {
                    var navigation = Shell.Current.Navigation;


                    // Check if we are navigating to the MakeBooking page
                    var currentLocation = Shell.Current.CurrentState.Location.OriginalString;
                    var targetLocation = args.Target.Location.OriginalString;

                    if (currentLocation.Contains("MakeBooking"))
                    {
                        while (navigation.NavigationStack.Count > 1)
                        {
                            navigation.RemovePage(Navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                        }
                        return;
                    }
                    if (currentLocation.Contains("Home"))
                    {
                        while (navigation.NavigationStack.Count > 1)
                        {
                            navigation.RemovePage(Navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                        }
                        return;
                    }
                    if (currentLocation.Contains("Booking"))
                    {
                        while (navigation.NavigationStack.Count > 1)
                        {
                            navigation.RemovePage(Navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                        }
                        return;
                    }
                    if (navigation.NavigationStack.Count > 1 && !(Shell.Current.CurrentState.Location.OriginalString.Contains("MakeBooking")))
                    {
                        bool IsConnectVehichle = false;
                        foreach(var page in navigation.NavigationStack)
                        {
                            if(page!=null && page.GetType().Name==nameof(ConnectVehiclePage))
                            {
                                IsConnectVehichle = true;
                                break;
                            }
                        }
                        
                        if (IsConnectVehichle)
                        while (navigation.NavigationStack.Count > 1)
                        {
                            navigation.RemovePage(Navigation.NavigationStack[navigation.NavigationStack.Count-1]);
                        }
                    }
                }
                    //Shell.Current.Navigation.PopToRootAsync();
            }
            catch(Exception ex)
            {

            }
            base.OnNavigating(args);

        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            var state = Shell.Current.CurrentState.Location.OriginalString;
            UpdateIcons(state);
        }
        void UpdateIcons(string state)
        {
            /* if(state.StartsWith("//Home"))
             {
                 HomeShell.Icon = "home_filled.png";
                 MakeBookingShell.Icon = "flash_on.png";
             }
             else if (state.StartsWith("//MakeBooking"))
             {
                 HomeShell.Icon = "home.png";
                 MakeBookingShell.Icon = "flash_on_filled.png";
             }
             else if (state.StartsWith("//Booking"))
             {
                 HomeShell.Icon = "home.png";
                 MakeBookingShell.Icon = "flash_on.png";
             }*/
        }
        void RegisterPages()
        {
            //Main Routes
            Routing.RegisterRoute("//Booking", typeof(BookingsPage));
            Routing.RegisterRoute(nameof(UpdateProfilePage), typeof(UpdateProfilePage));
            Routing.RegisterRoute("//MakeBooking", typeof(MakeBookingPage));
            Routing.RegisterRoute($"//Home", typeof(HomePage));
        }
        async Task NavigatedToPreviousCharges()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//Booking");
            //MainFlyout.CurrentItem = MakeBookingShell;
            //await Shell.Current.GoToAsync("//MakeBooking");
        }
        async Task NavigatedToUpcomingBooking()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//Booking");
        }
        async Task NavigatedToMakeBooking()
        {
            Shell.Current.FlyoutIsPresented = false;
            //await Shell.Current.GoToAsync(nameof(MakeBooking));
            //MainFlyout.CurrentItem = MakeBookingShell;
            await Shell.Current.GoToAsync("//MakeBooking");
        }
        async Task NavigatedToUpdateProfile()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync(nameof(UpdateProfilePage));
        }
        async Task Logout()
        {
            Preferences.Set("Password", null);
            Preferences.Set("Email", null);
            Preferences.Set("AuthToken", null);
            Shell.Current.FlyoutIsPresented = false;
            //await Shell.Current.GoToAsync(nameof(MakeBooking));
            //MainFlyout.CurrentItem = MakeBookingShell;
            App.Current.MainPage = new LoginPage(); // Ensure you have a LoginPage in your Views
        }
    }
}
