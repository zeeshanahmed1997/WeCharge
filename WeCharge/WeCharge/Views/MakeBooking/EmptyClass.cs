//using System;
//using System.Collections.Generic;
//using WeCharge.Theme;
//using WeCharge.ViewModels;
//using Xamarin.Forms;
//using WeCharge.Model.MakeBooking;
//using System.Threading.Tasks;
//using Xamarin.Forms.Maps;
//using System.Linq;
//using WeCharge.CustomControls;
//using Rg.Plugins.Popup.Services;
//using WeCharge.Views.Popup;
//using Xamarin.CommunityToolkit.Extensions;
//using Xamarin.CommunityToolkit.UI.Views.Options;
//using Xamarin.Essentials;
//using WeCharge.Views.Booking;
//using System.Reflection;
//using System.Diagnostics;
//using Xamarin.Forms.Internals;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
//using System.Collections.ObjectModel;
//using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

//namespace WeCharge.Views.MakeBooking
//{
//    public partial class MakeBookingPage : ContentPage
//    {
//        private MakeBookingPageViewModel viewModel;
//        bool IsDataLoaded = false;
//        CustomPin customPin;
//        public MakeBookingPage()
//        {
//            Shell.SetNavBarIsVisible(this, false);

//            viewModel = new MakeBookingPageViewModel();
//            InitializeComponent();

//            BindingContext = viewModel;
//            MyCarousel.PositionChanged += Carousel_PositionChanged;
//            listView.Refreshing += OnRefreshing;
//        }
//        private void SetListViewAsDefault()
//        {
//            ListView.IsVisible = true;
//            map.IsVisible = false;
//            MyCarousel.IsVisible = false;

//            ListViewButton.BackgroundColor = Color.Black;
//            ListViewButton.TextColor = Color.White;

//            MapViewButton.BackgroundColor = Color.FromHex("#D9D9D9");
//            MapViewButton.TextColor = Color.FromHex("#616161");
//            TopButtonsGrid.RaiseChild(ListViewButton); // This makes sure the ListViewButton appears on top
//        }
//        private void SetMapViewAsDefault()
//        {
//            ListView.IsVisible = false;
//            map.IsVisible = true;
//            MyCarousel.IsVisible = true;
//            MapViewButton.BackgroundColor = Color.Black;
//            MapViewButton.TextColor = Color.White;
//            ListViewButton.BackgroundColor = Color.FromHex("#D9D9D9");
//            ListViewButton.TextColor = Color.FromHex("#616161");
//            TopButtonsGrid.RaiseChild(MapViewButton);
//        }
//        private async void OnRefreshing(object sender, EventArgs e)
//        {
//            await LoadDataAndInitializeUI();
//            // Important: Signal that the refresh is done.
//            Device.BeginInvokeOnMainThread(() =>
//            {
//                ((Xamarin.Forms.ListView)sender).IsRefreshing = false;
//            });
//        }

//        void MapViewButton_Clicked(System.Object sender, System.EventArgs e)
//        {
//            SetMapViewAsDefault();
//        }

//        void ListViewButton_Clicked(System.Object sender, System.EventArgs e)
//        {
//            SetListViewAsDefault();
//        }

//        void CheckAvailabilityClicked(object sender, EventArgs e)
//        {
//            var button = sender as View;
//            if (button != null)
//            {
//                var item = button.BindingContext; // This is the data of the specific ListView item.

//                Model.MakeBooking.MakeBooking bookingItem = item as Model.MakeBooking.MakeBooking;
//                if (bookingItem != null)
//                {
//                    Navigation.PushAsync(new CheckAvailabilityPage(bookingItem));
//                }
//            }
//        }
//        private void CarouselCheckAvailabilityClicked(object sender, EventArgs e)
//        {
//            // Cast the sender as a Button since that's the actual control that triggered the event.
//            var button = sender as View;
//            if (button != null)
//            {
//                var item = button.BindingContext; // This is the data of the specific ListView item.
//                int index = viewModel.CarouselItems.IndexOf(item);

//                // Cast the item to the appropriate model type if needed.
//                Model.MakeBooking.MakeBooking bookingItem = new Model.MakeBooking.MakeBooking();
//                bookingItem = viewModel.BookingItems.ElementAtOrDefault(index);

//                if (bookingItem != null)
//                {
//                    Navigation.PushAsync(new CheckAvailabilityPage(bookingItem));
//                }
//            }
//        }


//        public void OnSelectedItem(object sender, SelectedItemChangedEventArgs args)
//        {
//            Model.MakeBooking.MakeBooking myBook = (Model.MakeBooking.MakeBooking)args.SelectedItem;
//            App.MakeBookingLocation = myBook;
//        }
//        protected override async void OnAppearing()
//        {
//            base.OnAppearing();
//            ShowTopButtonsGrid();
//            if (IsDataLoaded == false)
//            {
//                await LoadDataAndInitializeUI();
//                IsDataLoaded = true;
//                return;
//            }
//            var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));
//            if (App.customPin != null)
//            {
//                var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
//                if (index >= 0 && index < viewModel.CarouselItems.Count)
//                {
//                    Device.BeginInvokeOnMainThread(() =>
//                    {
//                        Task.Delay(2000);
//                        map.MoveToRegion(MapSpan.FromCenterAndRadius(
//                            new Position(App.customPin.Position.Latitude, App.customPin.Position.Longitude),
//                            Distance.FromKilometers(10)));
//                        MyCarousel.ScrollTo(index);
//                    });
//                }
//            }
//            else
//            {
//                if (location != null)
//                {
//                    double userLatitude = location.Latitude;
//                    double userLongitude = location.Longitude;

//                    Device.BeginInvokeOnMainThread(() =>
//                    {
//                        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(userLatitude, userLongitude), Distance.FromKilometers(1)));
//                    });
//                }
//            }
//        }


//        void NavBarTapped(System.Object sender, System.EventArgs e)
//        {
//            Shell.Current.FlyoutIsPresented = true;
//        }
//        void FilterTapped(System.Object sender, System.EventArgs e)
//        {
//            var filterPopup = new FilterModalPopup();

//            // Hook up the event
//            filterPopup.ApplyDone += (selectedFilter) =>
//            {
//                viewModel.SelectedFilter = selectedFilter;
//            };
//            // Open the popup
//            PopupNavigation.Instance.PushAsync(filterPopup);
//        }
//        private bool pinClicked = false;

//        private void CustomMapClicked(object sender, MapClickedEventArgs e)
//        {
//            Position currentPosition = e.Position;

//            pinClicked = viewModel.CarouselItems.Any(pinPosition =>
//                pinPosition.Position.Latitude == currentPosition.Latitude &&
//                pinPosition.Position.Longitude == currentPosition.Longitude);
//            if (pinClicked == true)
//                MyCarousel.IsVisible = true;
//            else if (pinClicked == false)
//                MyCarousel.IsVisible = false;
//        }

//        private void Pin_MarkerClicked1(object sender, PinClickedEventArgs e)
//        {
//            MyCarousel.IsVisible = true;
//            CustomPin customPin = (CustomPin)sender;
//            int index = viewModel.PinLocations.IndexOf(customPin);
//            viewModel.SelectedPin = customPin;
//            foreach (var pin in viewModel.PinLocations)
//            {
//                if (viewModel.PinLocations.IndexOf(pin) == index)
//                {
//                    pin.Image = "pin_selected.png";
//                }
//                else
//                {
//                    pin.Image = "pin.png";
//                }
//            }
//            if (index >= 0 && index < viewModel.CarouselItems.Count)
//            {
//                MyCarousel.ScrollTo(index);
//            }
//        }
//        private async Task LoadDataAndInitializeUI()
//        {
//            viewModel.IsBusy = true;
//            if (NetworkHelper.UpdateConnectivityStatus())
//            {
//                await viewModel.GetChargingLocationsAsync();

//                // Check if PinLocations have been loaded
//                if (viewModel.PinLocations.Count > 0)
//                {
//                    map.Pins.Clear();
//                    foreach (var pin in viewModel.PinLocations)
//                    {
//                        pin.MarkerClicked += Pin_MarkerClicked1;
//                        map.Pins.Add(pin);
//                    }
//                    if (App.customPin != null)
//                    {
//                        ListView.IsVisible = false;
//                        SetMapViewAsDefault();
//                        var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
//                        if (index >= 0 && index < viewModel.CarouselItems.Count)
//                        {
//                            await Task.Delay(2000);
//                            MyCarousel.ScrollTo(index);
//                        }
//                    }
//                    else
//                    {
//                        CustomPin customPin = viewModel.PinLocations[0];
//                        viewModel.SelectedPin = customPin;
//                        map.MoveToRegion(MapSpan.FromCenterAndRadius(
//                            new Position(customPin.Position.Latitude, customPin.Position.Longitude),
//                            Distance.FromKilometers(10)));
//                    }
//                }
//                viewModel.IsBusy = false;
//            }
//            else
//            {
//                // bool isconnected = NetworkHelper.IsConnected;

//                if (PopupNavigation.Instance.PopupStack.Count == 0)
//                {


//                    NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();


//                    networkErrorPopup.ClosePopupAction = async () =>
//                    {
//                        await PopupNavigation.Instance.PopAllAsync();
//                        await LoadDataAndInitializeUI();
//                    };
//                    await PopupNavigation.Instance.PushAsync(networkErrorPopup);
//                }
//            }
//        }


//        private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
//        {
//            try
//            {
//                int currentIndex = e.CurrentPosition;
//                Debug.WriteLine($"Carousel_PositionChanged - Current Index: {currentIndex}");

//                if (pinClicked)
//                {
//                    // Do not re-initialize the MyCarousel
//                    MyCarousel.IsVisible = true;
//                }
//                else
//                {
//                    if (App.customPin != null)
//                    {
//                        var index = viewModel.PinLocations.FindIndex(pin => App.customPin.Position.Latitude == pin.Position.Latitude && App.customPin.Position.Longitude == pin.Position.Longitude);
//                        if (index >= 0 && index < viewModel.CarouselItems.Count)
//                        {
//                            Device.BeginInvokeOnMainThread(async () =>
//                            {
//                                await Task.Delay(2000); // Add a delay of 2000 milliseconds
//                                MyCarousel.ScrollTo(index);
//                            });
//                        }

//                        App.customPin = null; // so that carousel do not remain at position of customPin every time we load page

//                    }
//                    else
//                    {
//                        if (currentIndex >= 0)
//                        {
//                            var correspondingPin = viewModel.PinLocations[currentIndex];
//                            Device.BeginInvokeOnMainThread(() =>
//                            {
//                                map.MoveToRegion(MapSpan.FromCenterAndRadius(
//                                    new Position(correspondingPin.Position.Latitude, correspondingPin.Position.Longitude),
//                                    Distance.FromKilometers(10)));
//                            });
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine($"Exception in Carousel_PositionChanged: {ex.Message}");
//            }
//        }

//        protected override void OnDisappearing()
//        {
//            base.OnDisappearing();
//        }
//        void ListCellTapped(System.Object sender, System.EventArgs e)
//        {

//            //ViewCellList.View.BackgroundColor=Color.Transparent;
//        }
//        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
//        {
//        }

//        void SearchBarTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
//        {
//            if (e.NewTextValue != null)
//            {
//                var filteredItems = viewModel.PinLocations
//                    .Where(pin =>
//                        pin.Address.ToLower().Contains(e.NewTextValue.ToLower()) ||
//                        (pin.Label != string.Empty && pin.Label.ToLower().Contains(e.NewTextValue.ToLower()))
//                    );

//                ObservableCollection<CustomPin> filteredPinCollection = new ObservableCollection<CustomPin>(filteredItems);
//                SearchBarList.ItemsSource = filteredPinCollection;

//                SearchBarList.IsVisible = filteredPinCollection.Any();
//                ShowSearchListView();
//            }
//            else
//            {
//                ShowTopButtonsGrid();
//                SearchBarList.IsVisible = false;
//            }

//        }

//        void SearchBarUnFocus(System.Object sender, Xamarin.Forms.FocusEventArgs e)
//        {
//            ShowTopButtonsGrid();
//            SearchBarList.IsVisible = false;
//        }
//        private void ShowSearchListView()
//        {
//            // Show the search list view and hide the top buttons grid
//            SearchBarList.IsVisible = true;
//            TopButtonsGrid.IsVisible = false;

//            // Bring the search list view to the front
//            MainGrid.RaiseChild(SearchBarList);
//        }

//        private void ShowTopButtonsGrid()
//        {
//            // Show the top buttons grid and hide the search list view
//            SearchBarList.IsVisible = false;
//            TopButtonsGrid.IsVisible = true;

//            // Bring the top buttons grid to the front
//            MainGrid.RaiseChild(TopButtonsGrid);
//        }
//        void MoveToLocationTapped(System.Object sender, System.EventArgs e)
//        {
//            ViewCell viewCell = (ViewCell)sender;

//            CustomPin pin = (CustomPin)viewCell.BindingContext;
//            double latitude = pin.Position.Latitude;
//            double longitude = pin.Position.Longitude;
//            locationSearchBar.Text = string.Empty;
//            ShowTopButtonsGrid();
//            SearchBarList.IsVisible = false;
//            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromKilometers(1)));
//            var index = viewModel.PinLocations.FindIndex(Pin => pin.Position.Latitude == Pin.Position.Latitude && pin.Position.Longitude == Pin.Position.Longitude);
//            if (index >= 0 && index < viewModel.CarouselItems.Count)
//            {
//                Device.BeginInvokeOnMainThread(async () =>
//                {
//                    await Task.Delay(2000); // Add a delay of 2000 milliseconds
//                    MyCarousel.ScrollTo(index);
//                });
//            }
//        }

//    }
//}