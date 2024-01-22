using System;
using WeCharge.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Linq;
using WeCharge.CustomControls;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.Popup;
using Xamarin.Essentials;
using System.Diagnostics;
using Xamarin.Forms.Internals;
using System.Collections.ObjectModel;
using WeCharge.Models.Booking;

namespace WeCharge.Views.MakeBooking
{
    public partial class MakeBookingPage : ContentPage
    {
        private MakeBookingPageViewModel viewModel;
        Xamarin.Essentials.Location location;
        bool IsDataLoaded = false;
        CustomPin customPin;
        public MakeBookingPage()
        {
            Shell.SetNavBarIsVisible(this, false);

            viewModel = new MakeBookingPageViewModel();
            InitializeComponent();
            BindingContext = viewModel;
            MyCarousel.PositionChanged += Carousel_PositionChanged;
            listView.Refreshing += OnRefreshing;
        }
        private void SetListViewAsDefault()
        {
            SearchBarList.IsVisible = false;
            ListView.IsVisible = true;
            MainGrid.RaiseChild(ListView);
            map.IsVisible = false;
            MyCarousel.IsVisible = false;
            ListViewButton.BackgroundColor = Color.Black;
            ListViewButton.TextColor = Color.White;

            MapViewButton.BackgroundColor = Color.FromHex("#D9D9D9");
            MapViewButton.TextColor = Color.FromHex("#616161");
            TopButtonsGrid.RaiseChild(ListViewButton); // This makes sure the ListViewButton appears on top
        }
        bool IsFirst = true;
        private void SetMapViewAsDefault()
        {
            ListView.IsVisible = false;
            MainGrid.RaiseChild(MapView);
            MainGrid.RaiseChild(TopButtonsGrid);
            map.IsVisible = true;
            //MyCarousel.IsVisible = true;
            if (App.customPin == null)
            {
                if (IsFirst)
                {
                    // Check if App.customPin is null


                    // Fetch the current user location and navigate the map to that position
                    NavigateToUserLocation();
                    IsFirst = false;
                }
                MyCarousel.IsVisible = false;
            }
            else
                MyCarousel.IsVisible = true;
            
            
            MapViewButton.BackgroundColor = Color.Black;
            MapViewButton.TextColor = Color.White;
            ListViewButton.BackgroundColor = Color.FromHex("#D9D9D9");
            ListViewButton.TextColor = Color.FromHex("#616161");
            TopButtonsGrid.RaiseChild(MapViewButton);
        }

        // New method to navigate to user's current location
        private async void NavigateToUserLocation()
        {
            try
            {

                //var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));
                if (App.CurrentPosition != null)
                {
                    double userLatitude = App.CurrentPosition.Latitude;
                    double userLongitude = App.CurrentPosition.Longitude;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(userLatitude, userLongitude), Distance.FromKilometers(1)));
                    });
                }
            }
            catch (FeatureNotEnabledException)
            {

            }
            catch (Exception)
            {
            }
        }


        private async void OnRefreshing(object sender, EventArgs e)
        {
            await LoadDataAndInitializeUI();

            Device.BeginInvokeOnMainThread(() =>
            {
                ((Xamarin.Forms.ListView)sender).IsRefreshing = false;
                if (string.IsNullOrWhiteSpace(locationSearchBar.Text))
                {
                    // Reset the ListView's item source to the full list when refreshing
                    listView.ItemsSource = viewModel.BookingItems;
                }
            });
        }

        void MapViewButton_Clicked(System.Object sender, System.EventArgs e)
        {
            SetMapViewAsDefault();
        }

        void ListViewButton_Clicked(System.Object sender, System.EventArgs e)
        {
            SetListViewAsDefault();
        }
        void CheckAvailabilityClicked(object sender, EventArgs e)
        {
            var button = sender as View;
            if (button != null)
            {
                var item = button.BindingContext; // This is the data of the specific ListView item.

                Model.MakeBooking.MakeBooking bookingItem = item as Model.MakeBooking.MakeBooking;
                if (bookingItem != null)
                {
                    Navigation.PushAsync(new CheckAvailabilityPage(bookingItem));
                }
            }
        }
        private void CarouselCheckAvailabilityClicked(object sender, EventArgs e)
        {
            // Cast the sender as a Button since that's the actual control that triggered the event.
            var button = sender as View;
            if (button != null)
            {
                var item = button.BindingContext; // This is the data of the specific ListView item.
                int index = viewModel.CarouselItems.IndexOf(item);

                // Cast the item to the appropriate model type if needed.
                Model.MakeBooking.MakeBooking bookingItem = new Model.MakeBooking.MakeBooking();

                bookingItem = viewModel.BookingItems.ElementAtOrDefault(index);

                if (bookingItem != null)
                {
                    Navigation.PushAsync(new CheckAvailabilityPage(bookingItem));
                }
            }
        }


        public void OnSelectedItem(object sender, SelectedItemChangedEventArgs args)
        {
            Model.MakeBooking.MakeBooking myBook = (Model.MakeBooking.MakeBooking)args.SelectedItem;
            App.MakeBookingLocation = myBook;
        }

        private async Task TryUpdateUserLocationOnMap()
        {
            try
            {
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));
                    if (location != null)
                    {
                        double userLatitude = location.Latitude;
                        double userLongitude = location.Longitude;

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(userLatitude, userLongitude), Distance.FromKilometers(1)));
                        });
                    }
                }

            }
            catch (FeatureNotEnabledException)
            {

                // Location services are not enabled; you could retry after some time
            }
            catch (Exception ex)
            {
                // Handle other exceptions
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (App.customPin != null)
            {
                if (IsDataLoaded == false)
                {
                    Task.Factory.StartNew(async() => { 
                    await LoadDataAndInitializeUI();
                        Device.BeginInvokeOnMainThread(() =>
                        {
                        IsDataLoaded = true;
                    MyCarousel.IsVisible = true;
                    SetMapViewAsDefault();
                    MainGrid.RaiseChild(MapView);
                    MainGrid.RaiseChild(TopButtonsGrid);
                            Task.Factory.StartNew(async() => { 
                    await Task.Delay(100);
                    var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
                    if (index >= 0 && index < viewModel.CarouselItems.Count)
                    {

                                Device.BeginInvokeOnMainThread(() => { 
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                                new Position(App.customPin.Position.Latitude, App.customPin.Position.Longitude),
                                Distance.FromKilometers(1)));
                            MyCarousel.ScrollTo(index,animate:false);
                                });

                            }
                        });
                        });
                    });
                }
                else
                {
                    MyCarousel.IsVisible = true;
                    SetMapViewAsDefault();
                    MainGrid.RaiseChild(MapView);
                    MainGrid.RaiseChild(TopButtonsGrid);
                    await Task.Delay(1000);
                    var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
                    if (index >= 0 && index < viewModel.CarouselItems.Count)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            try
                            {
                                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                                    new Position(App.customPin.Position.Latitude, App.customPin.Position.Longitude),
                                    Distance.FromKilometers(1)));
                                MyCarousel.ScrollTo(index,animate:false);
                            }
                            catch(Exception ex)
                            {

                            }
                        });
                    }
                }

            }
            else
            {
                if (IsDataLoaded == false)
                {
                    MyCarousel.IsVisible = false;
                    SetListViewAsDefault();
                    MainGrid.RaiseChild(ListView);
                    MainGrid.RaiseChild(TopButtonsGrid);
                    await LoadDataAndInitializeUI();
                    IsDataLoaded = true;
                }
            }
        }


        void NavBarTapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        void FilterTapped(System.Object sender, System.EventArgs e)
        {
            var filterPopup = new FilterModalPopup();

            // Hook up the event
            filterPopup.ApplyDone += (selectedFilter) =>
            {
                viewModel.SelectedFilter = selectedFilter;
            };
            // Open the popup
            PopupNavigation.Instance.PushAsync(filterPopup);
        }
        private bool pinClicked = false;

        private void CustomMapClicked(object sender, MapClickedEventArgs e)
        {
            Position currentPosition = e.Position;

            pinClicked = viewModel.CarouselItems.Any(pinPosition =>
                pinPosition.Position.Latitude == currentPosition.Latitude &&
                pinPosition.Position.Longitude == currentPosition.Longitude);
            if (pinClicked == true)
                MyCarousel.IsVisible = true;
            else if (pinClicked == false)
                MyCarousel.IsVisible = false;
        }

        private void Pin_MarkerClicked1(object sender, PinClickedEventArgs e)
        {
            MyCarousel.IsVisible = true;
            CustomPin customPin = (CustomPin)sender;
            int index = viewModel.PinLocations.IndexOf(customPin);
            viewModel.SelectedPin = customPin;
            foreach (var pin in viewModel.PinLocations)
            {
                if (viewModel.PinLocations.IndexOf(pin) == index)
                {
                    pin.Image = "pin_selected.png";
                }
                else
                {
                    pin.Image = "pin.png";
                }
            }
            if (index >= 0 && index < viewModel.CarouselItems.Count)
            {
                MyCarousel.ScrollTo(index, animate: false);
            }
        }
        private async Task LoadDataAndInitializeUI()
        {
            viewModel.IsBusy = true;
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                locationSearchBar.Placeholder = "locations are loading....";
                await viewModel.GetChargingLocationsAsync();
                locationSearchBar.Placeholder = "search for location";
                // Check if PinLocations have been loaded
                if (viewModel.PinLocations.Count > 0)
                {
                    map.Pins.Clear();
                    foreach (var pin in viewModel.PinLocations)
                    {
                        pin.MarkerClicked += Pin_MarkerClicked1;
                        map.Pins.Add(pin);
                    }
                    //if (App.customPin != null)
                    //{
                    //    MyCarousel.IsVisible = true;
                    //    SetMapViewAsDefault();
                    //    MainGrid.RaiseChild(MapView);
                    //    MainGrid.RaiseChild(TopButtonsGrid);

                    //    SetMapViewAsDefault();
                    //    var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
                    //    if (index >= 0 && index < viewModel.CarouselItems.Count)
                    //    {
                    //        MyCarousel.ScrollTo(index);
                    //    }
                    //}
                }
                viewModel.IsBusy = false;
            }
            else
            {
                // bool isconnected = NetworkHelper.IsConnected;

                if (PopupNavigation.Instance.PopupStack.Count == 0)
                {
                    Device.BeginInvokeOnMainThread(async() => { 
                    NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();
                    networkErrorPopup.ClosePopupAction = async () =>
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        await LoadDataAndInitializeUI();
                    };
                    await PopupNavigation.Instance.PushAsync(networkErrorPopup);
                    });
                }
            }
        }


        private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            try
            {
                int currentIndex = e.CurrentPosition;
                Debug.WriteLine($"Carousel_PositionChanged - Current Index: {currentIndex}");

                if (pinClicked)
                {
                    // Do not re-initialize the MyCarousel
                    MyCarousel.IsVisible = true;
                }
                if (currentIndex >= 0)
                {
                    var correspondingPin = viewModel.PinLocations[currentIndex];
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                                new Position(correspondingPin.Position.Latitude, correspondingPin.Position.Longitude),
                                Distance.FromKilometers(1)));
                        }
                        catch(Exception ex)
                        {

                        }
                    });
                }
                App.customPin = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in Carousel_PositionChanged: {ex.Message}");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        void ListCellTapped(System.Object sender, System.EventArgs e)
        {
        }
        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
        void SearchBarTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                // Reset to full list when search text is cleared
                listView.ItemsSource = viewModel.BookingItems;
                searchBarGrid.IsVisible = false;
                MainGrid.RaiseChild(ListView);
                MainGrid.RaiseChild(TopButtonsGrid);
                return;
            }

            // Continue with existing search logic if there is search text
            if (!ListView.IsVisible)
            {
                var filteredItems = viewModel.PinLocations
                    .Where(pin => pin.Address.ToLower().Contains(e.NewTextValue.ToLower()) ||
                                  (pin.Label != string.Empty && pin.Label.ToLower().Contains(e.NewTextValue.ToLower())));

                ObservableCollection<CustomPin> filteredPinCollection = new ObservableCollection<CustomPin>(filteredItems);
                SearchBarList.ItemsSource = filteredPinCollection;
                SearchBarList.IsVisible = filteredPinCollection.Any();
                searchBarGrid.IsVisible = filteredPinCollection.Any();
                if (searchBarGrid.IsVisible)
                {
                    MainGrid.RaiseChild(searchBarGrid);
                }
            }
            else
            {
                var filteredItems = viewModel.BookingItems
                    .Where(pin => pin.Address.ToLower().Contains(e.NewTextValue.ToLower()) ||
                                  (pin.Location != string.Empty && pin.Location.ToLower().Contains(e.NewTextValue.ToLower())));

                ObservableCollection<Model.MakeBooking.MakeBooking> filteredCollection = new ObservableCollection<Model.MakeBooking.MakeBooking>(filteredItems);
                if (filteredCollection.Any())
                {
                    listView.ItemsSource = filteredCollection;
                }
            }
        }

        void SearchBarUnFocus(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            locationSearchBar.Text = string.Empty;
            searchBarGrid.IsVisible = false;
        }
        void MoveToLocationTapped(System.Object sender, System.EventArgs e)
        {
            MyCarousel.IsVisible = true;
            ViewCell viewCell = (ViewCell)sender;

            CustomPin pin = (CustomPin)viewCell.BindingContext;
            double latitude = pin.Position.Latitude;
            double longitude = pin.Position.Longitude;
            locationSearchBar.Text = string.Empty;
            searchBarGrid.IsVisible = false;
            var index = viewModel.PinLocations.FindIndex(Pin => pin.Position.Latitude == Pin.Position.Latitude && pin.Position.Longitude == Pin.Position.Longitude);
            if (index >= 0 && index < viewModel.CarouselItems.Count)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
    new Position(pin.Position.Latitude, pin.Position.Longitude),
    Distance.FromKilometers(1)));
                    await Task.Delay(800); // Add a delay of 1000 milliseconds
                    MyCarousel.ScrollTo(index, animate: false);
                });
            }
        }
    }
}