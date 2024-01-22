using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeCharge.Model;
using WeCharge.Views.Accounts;
using WeCharge.Views.Booking;
using WeCharge.Views.MakeBooking;
using WeCharge.Views.Connect;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using WeCharge.Model.MakeBooking;
using WeCharge.ApiService.EndPoints;
using WeCharge.CustomControls;
using WeCharge.Models.Authentication;
using WeCharge.Models.APIResponse;
using WeCharge.Models.Booking;
using System.Threading.Tasks;
using WeCharge.Helpers;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.RequestModels;
using System.Linq;
using Xamarin.Essentials;
using WeCharge.Views.Popup;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using WeCharge.Views.Charge;
using Newtonsoft.Json;

namespace WeCharge.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {

        public Action PinLocationsUpdated;
        public DateHelper DateHelper { get; set; }
        Models.Booking.Booking booking;
        ChargingLocationRequestModel chargingLocationRequest;
        WeCharge.Models.Booking.Location chargingLocations = new WeCharge.Models.Booking.Location();
        ChargingLocationsResponse chargingLocationsResponse;
        BookingResponse lastChargeBookingResponse;
        BookingResponse UpcomingChargeBookingResponse;
        PreviousBookingRequestModel previousBookingRequestModel;
        AvailableChargeSlotRequestModel availableChargeSlotRequestModel;
        BookingResponse bookingResponse;

        public ICommand GoToChargingCommand { get; private set; }
        public ICommand ReviewPendingBookingCommand { get; private set; }
        public ICommand SubmitStartChargeCommand { get; private set; }
        public ICommand ViewBookingCommand { get; private set; }
        public ICommand BookAgainCommand { get; private set; }
        public ICommand GetDirectionsCommand { get; private set; }

        private ObservableCollection<CustomPin> _pinLocations = new ObservableCollection<CustomPin>(); // Change to CustomPin
        public ObservableCollection<CustomPin> PinLocations
        {
            get => _pinLocations;
            set
            {
                _pinLocations = value;
                OnPropertyChanged();
            }
        }
        // Bindable properties for Upcoming Charge section
        //here we set default string as space for Skeleton effect while loading data
        private string _date = "     ";
        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        private string _chargingdate = "     ";
        public string ChargingDate
        {
            get => _chargingdate;
            set => SetProperty(ref _chargingdate, value);
        }
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string _upcomingdate = "      ";
        public string UpcomingDate
        {
            get => _upcomingdate;
            set => SetProperty(ref _upcomingdate, value);
        }
        private string placeholder;
        public string Placeholder
        {
            get => placeholder;
            set => SetProperty(ref placeholder, value);
        }
        private bool isPendingBookingBusy;
        public bool IsPendingBookingBusy
        {
            get => isPendingBookingBusy;
            set => SetProperty(ref isPendingBookingBusy, value);
        }
        private bool isChargingBusy;
        public bool IsChargingBusy
        {
            get => isChargingBusy;
            set => SetProperty(ref isChargingBusy, value);
        }

        private bool isUpcomingBookingsBusy;
        public bool IsUpcomingBookingsBusy
        {
            get => isUpcomingBookingsBusy;
            set => SetProperty(ref isUpcomingBookingsBusy, value);
        }

        private bool isMapBusy;
        public bool IsMapBusy
        {
            get => isMapBusy;
            set => SetProperty(ref isMapBusy, value);
        }
        private bool isSearchBarEnabled;
        public bool IsSearchBarEnabled
        {
            get => isSearchBarEnabled;
            set => SetProperty(ref isSearchBarEnabled, value);
        }
        private bool isLastChargeBusy;
        public bool IsLastChargeBusy
        {
            get => isLastChargeBusy;
            set => SetProperty(ref isLastChargeBusy, value);
        }
        private bool pendingBookingVisible;
        public bool PendingBookingVisible
        {
            get => pendingBookingVisible;
            set => SetProperty(ref pendingBookingVisible, value);
        }
        private bool chargingVisible;
        public bool ChargingVisible
        {
            get => chargingVisible;
            set => SetProperty(ref chargingVisible, value);
        }

        private bool noPreviousBookings;
        public bool NoPreviousBookings
        {
            get => noPreviousBookings;
            set => SetProperty(ref noPreviousBookings, value);
        }
        private bool hasUpcomingBookings;
        public bool HasUpcomingBookings
        {
            get => hasUpcomingBookings;
            set => SetProperty(ref hasUpcomingBookings, value);
        }
        private CustomPin _selectedPin; // Change to CustomPin
        public CustomPin SelectedPin
        {
            get => _selectedPin;
            set
            {
                _selectedPin = value;
                OnPropertyChanged();
            }
        }
        private string _address = "       ";
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        private string _chargingaddress = "       ";
        public string ChargingAddress
        {
            get => _chargingaddress;
            set => SetProperty(ref _chargingaddress, value);
        }
        private string _upcomingaddress = "          ";
        public string UpcomingAddress
        {
            get => _upcomingaddress;
            set => SetProperty(ref _upcomingaddress, value);
        }
        private string _time = "      ";
        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }
        private string _chargingtime = "      ";
        public string ChargingTime
        {
            get => _chargingtime;
            set => SetProperty(ref _chargingtime, value);
        }
        private string _upcomingtime = "            ";
        public string UpcomingTime
        {
            get => _upcomingtime;
            set => SetProperty(ref _upcomingtime, value);
        }
        // Bindable properties for Last Charge section
        private string _lastChargeDate = "       ";
        public string LastChargeDate
        {
            get => _lastChargeDate;
            set => SetProperty(ref _lastChargeDate, value);
        }

        private string _lastChargeAddress = "             ";
        public string LastChargeAddress
        {
            get => _lastChargeAddress;
            set => SetProperty(ref _lastChargeAddress, value);
        }

        private string _lastChargeTime = "       ";
        public string LastChargeTime
        {
            get => _lastChargeTime;
            set => SetProperty(ref _lastChargeTime, value);
        }

        // Sample values for Upcoming Charge and Last Charge sections
        public HomePageViewModel()
        {
            if (Preferences.ContainsKey("userName"))
            {
                string name = Preferences.Get("userName", null);
                UserName = name;
            }
            GoToChargingCommand = new Command(GoToChargingPage);
            ReviewPendingBookingCommand = new Command(ReviewPendingBooking);
            SubmitStartChargeCommand = new Command(StartCharge);
            ViewBookingCommand = new Command(ViewBooking);
            BookAgainCommand = new Command(BookAgain);
            GetDirectionsCommand = new Command(GetDirections);
        }
        public async void GoToChargingPage()
        {
            App.chargeEstimateRequest = Helpers.Utils.GetObjectFromPreferences<ChargeEstimateRequest>("chargeEstimateRequest");
            if (App.chargeEstimateRequest != null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // Create an instance of ChargingPage
                    var chargingPage = new ChargingPage(App.chargeEstimateRequest);

                    // Get the current navigation stack
                    var navigationStack = Application.Current.MainPage.Navigation.NavigationStack.ToList();

                    // Iterate through the stack and remove all pages except for the new ChargingPage
                    foreach (var page in navigationStack)
                    {
                        if (page != null && page != chargingPage)
                        {
                            Application.Current.MainPage.Navigation.RemovePage(page);
                        }
                    }

                    // Push the ChargingPage onto the now-cleared navigation stack
                    await Application.Current.MainPage.Navigation.PushAsync(chargingPage);

                    // Set IsBusy to false to indicate the operation is complete (if applicable)
                    // IsBusy = false;
                });
            }
        }
        public async void StartCharge()
        {
            ChargeEstimateRequest chargeEstimateRequest = new ChargeEstimateRequest();
            chargeEstimateRequest.BookingID = UpcomingChargeBookingResponse.Bookings[0].ID;
            chargeEstimateRequest.ChargerID = UpcomingChargeBookingResponse.Bookings[0].ChargerID;
            chargeEstimateRequest.SlotStartTime = UpcomingChargeBookingResponse.Bookings[0].SlotStartTimeFormattedDisplay;
            chargeEstimateRequest.LocaionName = UpcomingChargeBookingResponse.Bookings[0].Location.Name;
            chargeEstimateRequest.BayNumber = UpcomingChargeBookingResponse.Bookings[0].Charger.BayNumber;
            chargeEstimateRequest.CostRateDisplay = UpcomingChargeBookingResponse.Bookings[0].Charger.CostRateDisplay;
            await App.Current.MainPage.Navigation.PushAsync(new ConnectVehiclePage(chargeEstimateRequest));
            //await Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle");
        }
        public async void ReviewPendingBooking()
        {

            int count = 0;
            count = bookingResponse.Bookings.Count();

            await App.Current.MainPage.Navigation.PushAsync(new ReviewPendingBookingPage(bookingResponse.Bookings[count - 1]));
        }
        public async void ViewBooking()
        {
            Models.Booking.Booking booking = new Models.Booking.Booking();

            booking = lastChargeBookingResponse.Bookings[lastChargeBookingResponse.Bookings.Count - 1];
            await App.Current.MainPage.Navigation.PushAsync(new PreviousBookingPage(booking));
            // await Shell.Current.GoToAsync("//Booking/ViewBooking");
        }
        public async void BookAgain()
        {
            //await App.Current.MainPage.Navigation.PushAsync(new MakeBookingPage());
            await Shell.Current.GoToAsync("//MakeBooking");
        }
        public void GetDirections()
        {
            if (double.TryParse(UpcomingChargeBookingResponse.Bookings[0].Location.address.Latitude, out double latitude) &&
                double.TryParse(UpcomingChargeBookingResponse.Bookings[0].Location.address.Longitude, out double longitude))
            {
                string location = $"{latitude},{longitude}";
                // Create a URI with the Google Maps query
                Uri googleMapsUri = new Uri($"https://maps.google.com/maps?q={location}");
                // Open Google Maps using the device's default browser
                Device.OpenUri(googleMapsUri);

                //Launcher.TryOpenAsync(googleMapsUri);
            }
        }

        public void GetAllApis()
        {
            NoPreviousBookings = true;
            IsLastChargeBusy = true;
            HasUpcomingBookings = true;
            IsUpcomingBookingsBusy = true;
            PendingBookingVisible = true;
            IsPendingBookingBusy = true;
            //ChargingVisible = true;
            //IsChargingBusy = true;
            GetChargingDetailsAsync();
            Task.Factory.StartNew(() =>
            {
                GetChargingLocationsAsync();
                LoadPendingAsync();
                LoadUpcomingBookings();
                LoadLastCharge();

            });
        }

        public async Task GetChargingDetailsAsync()
        {
            App.booking = Helpers.Utils.GetObjectFromPreferences<Models.Booking.Booking>("booking");

            //await Task.Delay(2000);

            //Device.BeginInvokeOnMainThread(() =>
            //{
                if (App.booking != null && !string.IsNullOrEmpty(App.booking.ID))
                {
                    ChargingDate = App.booking.DateTimeLocalFormattedDisplay;
                    ChargingAddress = App.booking.Location.address.DisplayLine1;
                    ChargingTime = App.booking.SlotTimeFormattedDisplay;
                    ChargingVisible = true; // Show UI only if there is data
                }
                else
                {
                    ChargingVisible = false; // Hide UI if there is no data
                }

                IsChargingBusy = false;
           // });
        }

        public async Task GetChargingLocationsAsync()
        {
            chargingLocationRequest = new ChargingLocationRequestModel();
            await chargingLocationRequest.GetUserLocation();
            var chargingLocationsResponse = await App.weChargeService.bookingsService.FindChargingLocations(chargingLocationRequest);

            App.chargingLocationsResponses = chargingLocationsResponse;
            if (chargingLocationsResponse != null)
            {
                PinLocations = new ObservableCollection<CustomPin>();
                foreach (WeCharge.Models.Booking.Location location in chargingLocationsResponse.Locations)
                {
                    // Parse Latitude and Longitude from string to double
                    if (double.TryParse(location.address.Latitude, out double latitude) &&
                        double.TryParse(location.address.Longitude, out double longitude))
                    {
                        CustomPin customPin = new CustomPin
                        {
                            Position = new Position(latitude, longitude),
                            Label = location.Name,
                            Address = location.address.DisplayLine1,
                            //Image = "icon.png"
                        };
                        PinLocations.Add(customPin);
                    }
                }
                PinLocationsUpdated?.Invoke();

            }
            else
                GetChargingLocationsAsync();


        }
        public async Task LoadLastCharge()
        {

            lastChargeBookingResponse = await App.weChargeService.bookingsService.GetPreviousBookings(previousBookingRequestModel);

            // Sort bookings by Date and Time in descending order
            var sortedBookings = lastChargeBookingResponse?.Bookings.OrderByDescending(b => b.DateTimeLocalISO).ToList();
            // Task.Delay(1000);
            if (sortedBookings != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                    {
                        if (sortedBookings.Count == 0)
                        {
                            NoPreviousBookings = false;
                        }
                        else
                        {
                            LastChargeDate = sortedBookings[0].DateTimeLocalFormattedDisplay;
                            LastChargeAddress = sortedBookings[0].Location.address.DisplayLine1;
                            LastChargeTime = sortedBookings[0].ChargeKiloWattsConsumedDisplay.ToString();
                            NoPreviousBookings = true;
                        }

                        IsLastChargeBusy = false;
                    });
            }
            else
            {
                LoadLastCharge();
            }
        }
        public async Task LoadUpcomingBookings()
        {
            App.booking = Helpers.Utils.GetObjectFromPreferences<Models.Booking.Booking>("booking");
            UpcomingChargeBookingResponse = await App.weChargeService.bookingsService.GetUpcomingBookings();

            if (App.booking != null)
            {
                var filteredBookings = UpcomingChargeBookingResponse?.Bookings
                    .Where(b => b.ID != App.booking.ID)
                    .OrderBy(b => b.DateTimeLocalISO)
                    .ToList();

                // Task.Delay(1000);
                if (filteredBookings != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (filteredBookings.Count == 0)
                        {
                            HasUpcomingBookings = false;
                        }
                        else
                        {
                            UpcomingDate = filteredBookings[0].DateTimeLocalFormattedDisplay;
                            UpcomingAddress = filteredBookings[0].Location.address.DisplayLine1;
                            UpcomingTime = filteredBookings[0].SlotTimeFormattedDisplay;
                            HasUpcomingBookings = true;
                            App.book = filteredBookings[0];
                        }
                        IsUpcomingBookingsBusy = false;
                    });
                }
                else
                {
                    LoadUpcomingBookings();
                }
            }
            else
            {
                var sortedBookings = UpcomingChargeBookingResponse?.Bookings.OrderBy(b => b.DateTimeLocalISO).ToList();
                if (sortedBookings != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (sortedBookings.Count == 0)
                        {
                            HasUpcomingBookings = false;
                        }
                        else
                        {
                            UpcomingDate = sortedBookings[0].DateTimeLocalFormattedDisplay;
                            UpcomingAddress = sortedBookings[0].Location.address.DisplayLine1;
                            UpcomingTime = sortedBookings[0].SlotTimeFormattedDisplay;
                            HasUpcomingBookings = true;
                            App.book = sortedBookings[0];
                        }
                        IsUpcomingBookingsBusy = false;
                    });
                }
                else
                {
                    LoadUpcomingBookings();
                }
            }
        }


        public async Task LoadPendingAsync()
        {
            int count = 0;

            if (NetworkHelper.UpdateConnectivityStatus())
            {
                bookingResponse = await App.weChargeService.bookingsService.GetPendingBookings();
                if (bookingResponse != null)
                {
                    count = bookingResponse.Bookings.Count();
                    //Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() =>
                        {
                            if (bookingResponse.Bookings.Count == 0)
                            {
                                PendingBookingVisible = false;
                            }
                            else
                            {
                                //DateText = bookSpace.Date.DayOfWeek.ToString() + ", " + bookSpace.Date.Day.ToString() + " " + bookSpace.Date.ToString("MMMM");

                                Date = bookingResponse.Bookings[count - 1].DateTimeLocalFormattedDisplay;
                                Address = bookingResponse.Bookings[count - 1].Location.Name + bookingResponse.Bookings[count - 1].Location.address.AddressLine1;
                                Time = bookingResponse.Bookings[count - 1].SlotTimeFormattedDisplay.ToString();
                                PendingBookingVisible = true;
                            }
                            IsPendingBookingBusy = false;
                        });
                }
                else
                    LoadPendingAsync();
            }
            else
            {
                if (PopupNavigation.Instance.PopupStack.Count == 0)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();
                        networkErrorPopup.ClosePopupAction = async () =>
                        {
                            await PopupNavigation.Instance.PopAllAsync();
                            LoadPendingAsync();
                        };
                        await PopupNavigation.Instance.PushAsync(networkErrorPopup);
                    });
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
