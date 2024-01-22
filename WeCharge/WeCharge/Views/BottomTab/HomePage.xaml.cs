using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Plugin.Geofence;

using Rg.Plugins.Popup.Services;

using WeCharge.CustomControls;
using WeCharge.Models.Booking;
using WeCharge.ViewModels;
using WeCharge.Views.MakeBooking;
using WeCharge.Views.Popup;

using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace WeCharge.Views.BottomTab
{
    public partial class HomePage : ContentPage
    {
        //private bool isLocationEnabled = false;
        bool locationEnabled = true;
        HomePageViewModel homePageViewModel;
        Xamarin.Essentials.Location location;
        int i = 10;
        int j = 20;
        private static bool isApiCallInProgress = false;
        public HomePage()
        {
            Shell.SetNavBarIsVisible(this, false);

            homePageViewModel = new HomePageViewModel();
            homePageViewModel.PinLocationsUpdated += () => {
                Device.BeginInvokeOnMainThread(() => {

                    homePageViewModel.IsMapBusy = true;
                    if (map != null)
                    {
                        map.Pins.Clear();

                        foreach (var pin in homePageViewModel.PinLocations)
                        {
                            pin.MarkerClicked += Pin_MarkerClicked1;
                            map.Pins.Add(pin);
                        }
                    }
                    homePageViewModel.IsMapBusy = false;
                    homePageViewModel.IsSearchBarEnabled = true;
                    homePageViewModel.Placeholder = "Search for a location";
                });
            };
            InitializeComponent();

            BindingContext = homePageViewModel;
            Task.Run(UpdateUserLocationAsync);

        }


            bool IsFirst = true;
        private async Task UpdateUserLocationAsync()
        {
            Task.Factory.StartNew(async() => { 
            try
            {

                location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));
                if (location != null)
                {
                    App.CurrentPosition = new Position(location.Latitude, location.Longitude);
                    locationEnabled = true; // Set the flag indicating that location is updated
                }
                if (IsFirst && locationEnabled && map != null)
                {

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        IsFirst = false;
                        try
                        {
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(App.CurrentPosition.Latitude, App.CurrentPosition.Longitude), Distance.FromKilometers(1)));
                        }
                        catch(Exception ex)
                        {

                        }
                    });
                }
            }
            catch (FeatureNotEnabledException)
            {
                // Handle the case where location services are not enabled
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
            });
        }
        protected override void OnAppearing()
        {
            homePageViewModel.Placeholder = "locations are loading....";
            homePageViewModel.IsSearchBarEnabled = false;
            base.OnAppearing();
            Task.Run(UpdateUserLocationAsync);
            locationEnabled = false;
            homePageViewModel.GetAllApis();
                
                
            
        }
        private void Pin_MarkerClicked1(object sender, PinClickedEventArgs e)
        {
            CustomPin customPin = (CustomPin)sender;
            int index = homePageViewModel.PinLocations.IndexOf(customPin);
            homePageViewModel.SelectedPin = customPin;
            foreach (var pin in homePageViewModel.PinLocations)
            {
                if (homePageViewModel.PinLocations.IndexOf(pin) == index)
                {
                    pin.Image = "pin.png";
                }
                else
                {
                    pin.Image = "pin.png";
                }
            }

            // Create the MakeBookingPage
            App.customPin = customPin;
            App.position = customPin.Position;
            Shell.Current.GoToAsync("//MakeBooking");
        }

        void FilterTapped(System.Object sender, System.EventArgs e)
        {
            var popupPage = new FilterModalPopup();
            PopupNavigation.Instance.PushAsync(popupPage);
        }
        void NavBarTapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            // Handle map click event here if needed
        }

        void SearchBarTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue != string.Empty && e.NewTextValue != null)
            {
                var filteredItems = homePageViewModel.PinLocations
                    .Where(pin =>
                        pin.Address.ToLower().Contains(e.NewTextValue.ToLower()) ||
                        (pin.Label != string.Empty && pin.Label.ToLower().Contains(e.NewTextValue.ToLower()))
                    );

                ObservableCollection<CustomPin> filteredPinCollection = new ObservableCollection<CustomPin>(filteredItems);
                SearchBarList.ItemsSource = filteredPinCollection;
                SearchBarList.IsVisible = filteredPinCollection.Any();

            }
            else
            {
                SearchBarList.IsVisible = false;
            }

        }

        void SearchBarUnFocus(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SearchBarList.IsVisible = false;
        }

        void MoveToLocationTapped(System.Object sender, System.EventArgs e)
        {
            // Ensure that the sender is a ViewCell
            if (sender is ViewCell viewCell)
            {
                // Ensure that the BindingContext is a CustomPin
                if (viewCell.BindingContext is CustomPin pin)
                {
                    try
                    {
                        double latitude = pin.Position.Latitude;
                        double longitude = pin.Position.Longitude;

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            locationSearchBar.Text = string.Empty;
                            SearchBarList.IsVisible = false;
                            if (map != null)
                            {
                                try
                                {
                                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromKilometers(1)));
                                }
                                catch(Exception ex) { }
                            }
                            else
                            {
                                // Handle the scenario when map is null
                                // Show an error message or log the error
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions during the map movement
                        // Log the error or show a user-friendly message
                    }
                }
                else
                {
                    // Handle the scenario when BindingContext is not a CustomPin
                    // Show an error message or log the error
                }
            }
            else
            {
                // Handle the scenario when sender is not a ViewCell
                // Show an error message or log the error
            }
        }

    }
}
