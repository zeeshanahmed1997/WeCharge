using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using WeCharge.CustomControls;
using WeCharge.Models;
using WeCharge.Models.Booking;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Accounts;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class BookingConfirmedPageViewModel : INotifyPropertyChanged
    {
        BookSpace bookSpace;
        public ICommand GetDirectionsCommand { get; private set; }
        public ICommand ShowMenuCommand { get; private set; }
        public ICommand AddToCalendarCommand { get; private set; }
        public ICommand StartChargingCommand { get; private set; }

        public BookingConfirmedPageViewModel()
        {
            GetDirectionsCommand = new Command(GetDirections);
            ShowMenuCommand = new Command(ShowMenu);
            AddToCalendarCommand = new Command(AddToCalendar);
            StartChargingCommand = new Command(StartCharging);
            SetDefaultValues();
           
        }
        public BookingConfirmedPageViewModel(BookSpace _bookSpace)
        {
            bookSpace = _bookSpace;
            App.book = _bookSpace.Booking;
            GetDirectionsCommand = new Command(GetDirections);
            ShowMenuCommand = new Command(ShowMenu);
            AddToCalendarCommand = new Command(AddToCalendar);
            StartChargingCommand = new Command(StartCharging);
            SetDefaultValues();

        }

        public void GetDirections()
        {
            if (double.TryParse(bookSpace.Booking.Location.address.Latitude, out double latitude) &&
                 double.TryParse(bookSpace.Booking.Location.address.Longitude, out double longitude))
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
            DateTime startDate = bookSpace.Booking.DateTimeLocalISO;
            string durationString = bookSpace.Booking.DurationDisplay;
            string[] words = durationString.Split(' ');
            string duration = words[0];
            if (words[1] == "mins")
            {
                DateTime endDate = bookSpace.Booking.DateTimeLocalISO.AddMinutes(int.Parse(duration));
                ICalendarService calendarService = DependencyService.Get<ICalendarService>();
                calendarService.AddEvent($"WeCharge booking: {bookSpace.Booking.Location.Name} ", null, startDate, endDate, bookSpace.Booking.Location.address.DisplayLine1);
                IsCalenderEventStore = true;
                await Task.Delay(5000);
                Device.BeginInvokeOnMainThread(() => { IsCalenderEventStore = false; });
            }
            else
            {
                DateTime endDate = bookSpace.Booking.DateTimeLocalISO.AddHours(int.Parse(duration));
                ICalendarService calendarService = DependencyService.Get<ICalendarService>();
                calendarService.AddEvent($"WeCharge booking: {bookSpace.Booking.Location.Name} ", null, startDate, endDate, bookSpace.Booking.Location.address.DisplayLine1);
                IsCalenderEventStore = true;
                await Task.Delay(5000);
                Device.BeginInvokeOnMainThread(() => { IsCalenderEventStore = false; });
            }
        }

        public void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        private void SetDefaultValues()
        {
            // Sample values assigned to the properties
            //BookingId = bookSpace.BookingID;
            LocationName = bookSpace.Booking.Location.Name;
            LocationAddress = bookSpace.Booking.Location.address.DisplayLine1;
            LocationCity = bookSpace.Booking.Location.address.AddressCity;
            Date = bookSpace.Date.DayOfWeek.ToString() + ", " + bookSpace.Date.Day.ToString() + " "+ bookSpace.Date.ToString("MMMM");
            LocationInfo = bookSpace.Booking.Location.address.DisplayLine1;
            Time = bookSpace.selectedStartTime.ToString();
        }
        // Bindable properties
        private string locationName;
        public string LocationName
        {
            get => locationName;
            set => SetProperty(ref locationName, value);
        }

        private string locationAddress;
        public string LocationAddress
        {
            get => locationAddress;
            set => SetProperty(ref locationAddress, value);
        }

        private string locationCity;
        public string LocationCity
        {
            get => locationCity;
            set => SetProperty(ref locationCity, value);
        }

        private string date;
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private bool isCalenderEventStore = false;
        public bool IsCalenderEventStore
        {
            get => isCalenderEventStore;
            set => SetProperty(ref isCalenderEventStore, value);
        }
        private string locationInfo;
        public string LocationInfo
        {
            get => locationInfo;
            set => SetProperty(ref locationInfo, value);
        }


        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }




        private string makeNewBookingText;
        public string MakeNewBookingText
        {
            get => makeNewBookingText;
            set => SetProperty(ref makeNewBookingText, value);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;
            OnPropertyChanged(propertyName);
        }
        public void StartCharging()
        {
            ChargeEstimateRequest chargeEstimateRequest=new ChargeEstimateRequest();
            chargeEstimateRequest.BookingID = bookSpace.BookingID;
            chargeEstimateRequest.ChargerID = bookSpace.Booking.ChargerID;
            chargeEstimateRequest.SlotStartTime = bookSpace.Booking.SlotStartTimeFormattedDisplay;
            chargeEstimateRequest.CostRateDisplay = bookSpace.Booking.Charger.CostRateDisplay;
            chargeEstimateRequest.LocaionName = bookSpace.Booking.Location.Name;
            chargeEstimateRequest.BayNumber = bookSpace.Booking.Charger.BayNumber;
            Application.Current.MainPage.Navigation.PushAsync(new ConnectVehiclePage(chargeEstimateRequest));
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
