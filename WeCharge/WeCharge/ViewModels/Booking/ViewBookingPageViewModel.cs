using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCharge.CustomControls;
using WeCharge.Models;
using WeCharge.Models.Booking;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Accounts;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.ViewModels.Booking
{
    public class ViewBookingPageViewModel:BaseViewModel
    {
        Models.Booking.Booking booking;
        public ICommand GetDirectionsCommand { get; private set; }
        public ICommand EditBookingCommand { get; private set; }
        public ICommand AddToCalendarCommand { get; private set; }
        public ICommand StartChargeCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties for the fields in the XAML
        private string _bookingID;
        public string BookingID
        {
            get { return _bookingID; }
            set
            {
                if (_bookingID != value)
                {
                    _bookingID = value;
                    OnPropertyChanged(nameof(BookingID));
                }
            }
        }

        private string _locationName;
        public string LocationName
        {
            get { return _locationName; }
            set
            {
                if (_locationName != value)
                {
                    _locationName = value;
                    OnPropertyChanged(nameof(LocationName));
                }
            }
        }

        private string _locationAddress;
        public string LocationAddress
        {
            get { return _locationAddress; }
            set
            {
                if (_locationAddress != value)
                {
                    _locationAddress = value;
                    OnPropertyChanged(nameof(LocationAddress));
                }
            }
        }

        private string _locationCity;
        public string LocationCity
        {
            get { return _locationCity; }
            set
            {
                if (_locationCity != value)
                {
                    _locationCity = value;
                    OnPropertyChanged(nameof(LocationCity));
                }
            }
        }

        private string _bookingDate;
        public string BookingDate
        {
            get { return _bookingDate; }
            set
            {
                if (_bookingDate != value)
                {
                    _bookingDate = value;
                    OnPropertyChanged(nameof(BookingDate));
                }
            }
        }

        private string _bookingLocation;
        public string BookingLocation
        {
            get { return _bookingLocation; }
            set
            {
                if (_bookingLocation != value)
                {
                    _bookingLocation = value;
                    OnPropertyChanged(nameof(BookingLocation));
                }
            }
        }

        private string _bookingTime;
        public string BookingTime
        {
            get { return _bookingTime; }
            set
            {
                if (_bookingTime != value)
                {
                    _bookingTime = value;
                    OnPropertyChanged(nameof(BookingTime));
                }
            }
        }


        private bool isCalenderEventStore = false;
        public bool IsCalenderEventStore
        {
            get => isCalenderEventStore;
            set => SetProperty(ref isCalenderEventStore, value);
        }
        // ... Add more properties for other fields in the XAML ...

        // Helper method to raise PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SetDefaultValues()
        {
            BookingID = "BookingID:  " + booking.ReferenceCode;
            LocationName = booking.Location.Name;
            LocationAddress = booking.Location.address.DisplayLine1;
            LocationCity = booking.Location.address.AddressCity;
            BookingDate = booking.DateTimeLocalISO.DayOfWeek.ToString() + ", " + booking.DateTimeLocalISO.Day.ToString() + " " + booking.DateTimeLocalISO.Date.ToString("MMMM");
            BookingLocation = booking.Location.address.DisplayLine1;
            BookingTime = booking.SlotTimeFormattedDisplay;
        }
        public void StartCharge()
        {
            ChargeEstimateRequest chargeEstimateRequest = new ChargeEstimateRequest();
            chargeEstimateRequest.BookingID = booking.ID;
            chargeEstimateRequest.ChargerID = booking.ChargerID;
            chargeEstimateRequest.BayNumber = booking.Charger.BayNumber;
            chargeEstimateRequest.CostRateDisplay = booking.Charger.CostRateDisplay;
            chargeEstimateRequest.LocaionName = booking.Location.Name;
            chargeEstimateRequest.SlotStartTime = booking.SlotStartTimeFormattedDisplay;
            Application.Current.MainPage.Navigation.PushAsync(new ConnectVehiclePage(chargeEstimateRequest));
            // Application.Current.MainPage.Navigation.PushAsync(new ConnectVehiclePage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle");
        }
        public void GetDirections()
        {
            if (double.TryParse(booking.Location.address.Latitude, out double latitude) &&
                double.TryParse(booking.Location.address.Longitude, out double longitude))
            {
                string location = $"{latitude},{longitude}";
                // Create a URI with the Google Maps query
                Uri googleMapsUri = new Uri($"https://maps.google.com/maps?q={location}");
                // Open Google Maps using the device's default browser
                Device.OpenUri(googleMapsUri);
            }
        }
        public async void AddToCalendar()
        {
            IsCalenderEventStore = false;
            DateTime startDate = booking.DateTimeLocalISO;
            string durationString = booking.DurationDisplay;
            string[] words = durationString.Split(' ');
            string duration = words[0];
            if (words[1] == "mins")
            {
                DateTime endDate = booking.DateTimeLocalISO.AddMinutes(int.Parse(duration));
                ICalendarService calendarService = DependencyService.Get<ICalendarService>();
                IsCalenderEventStore=calendarService.AddEvent($"WeCharge booking: {booking.Location.Name} ", null, startDate, endDate, booking.Location.address.DisplayLine1);
                if (IsCalenderEventStore)
                {
                    await Task.Delay(5000);
                    Device.BeginInvokeOnMainThread(() => { IsCalenderEventStore = false; });
                }
               
            }
            else
            {
                DateTime endDate = booking.DateTimeLocalISO.AddHours(int.Parse(duration));
                ICalendarService calendarService = DependencyService.Get<ICalendarService>();
                IsCalenderEventStore=calendarService.AddEvent($"WeCharge booking: {booking.Location.Name} ", null, startDate, endDate, booking.Location.address.DisplayLine1);
                if (IsCalenderEventStore)
                {
                    await Task.Delay(5000);
                    Device.BeginInvokeOnMainThread(() => { IsCalenderEventStore = false; });
                }
               
            }

        }
        public async void EditBooking()
        {
           // await Application.Current.MainPage.Navigation.PushAsync(new MakeBookingPage());
        }
        public ViewBookingPageViewModel()
        {
            EditBookingCommand = new Command(EditBooking);
            GetDirectionsCommand = new Command(GetDirections);
            StartChargeCommand = new Command(StartCharge);
            AddToCalendarCommand = new Command(AddToCalendar);
            SetDefaultValues();
        }

        public ViewBookingPageViewModel(Models.Booking.Booking _booking)
        {
            booking = _booking;
            EditBookingCommand = new Command(EditBooking);
            GetDirectionsCommand = new Command(GetDirections);
            StartChargeCommand = new Command(StartCharge);
            AddToCalendarCommand = new Command(AddToCalendar);
            SetDefaultValues();
        }
    }
}

