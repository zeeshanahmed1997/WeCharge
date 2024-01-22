using Xamarin.Forms;
using System.ComponentModel;
using WeCharge.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeCharge.Views.Accounts;
using WeCharge.Views.MakeBooking;
using System;

namespace WeCharge.ViewModels
{
    public class PreviousBookingPageViewModel : INotifyPropertyChanged
    {
        Models.Booking.Booking booking;
        public event PropertyChangedEventHandler PropertyChanged;

        // ...

        public ICommand GetDirectionsCommand { get; private set; }
        public ICommand BookAgainCommand { get; private set; }
        // Properties for Charging Fee, Service Charges, Subtotal, Tax, and Grand Total
        private decimal _chargingFee;
        public decimal ChargingFee
        {
            get { return _chargingFee; }
            set
            {
                if (_chargingFee != value)
                {
                    _chargingFee = value;
                    OnPropertyChanged(nameof(ChargingFee));
                }
            }
        }

        private string _serviceCharges;
        public string ServiceCharges
        {
            get { return _serviceCharges; }
            set
            {
                if (_serviceCharges != value)
                {
                    _serviceCharges = value;
                    OnPropertyChanged(nameof(ServiceCharges));
                }
            }
        }

        private string _subtotal;
        public string Subtotal
        {
            get { return _subtotal; }
            set
            {
                if (_subtotal != value)
                {
                    _subtotal = value;
                    OnPropertyChanged(nameof(Subtotal));
                }
            }
        }

        private string _tax;
        public string Tax
        {
            get { return _tax; }
            set
            {
                if (_tax != value)
                {
                    _tax = value;
                    OnPropertyChanged(nameof(Tax));
                }
            }
        }

        private string _grandTotal;
        public string GrandTotal
        {
            get { return _grandTotal; }
            set
            {
                if (_grandTotal != value)
                {
                    _grandTotal = value;
                    OnPropertyChanged(nameof(GrandTotal));
                }
            }
        }
        // Properties for the StackLayout Labels
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

        // Properties for Units Consumed, Date, and Duration
        private string _unitsConsumed;
        public string UnitsConsumed
        {
            get { return _unitsConsumed; }
            set
            {
                if (_unitsConsumed != value)
                {
                    _unitsConsumed = value;
                    OnPropertyChanged(nameof(UnitsConsumed));
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

        private string _duration;
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));
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

        private string _startTime;// = "02:12 pm";
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        private string _endTime;// = "02:12 pm";
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        // Helper method to raise PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public PreviousBookingPageViewModel()
        {
            GetDirectionsCommand = new Command(GetDirections);
            BookAgainCommand = new Command(BookAgain);
            SetDefaultValues();

        }
        public PreviousBookingPageViewModel(Models.Booking.Booking _booking)
        {
            booking = _booking;
            GetDirectionsCommand = new Command(GetDirections);
            BookAgainCommand = new Command(BookAgain);
            SetDefaultValues();
        }

        [Obsolete]
        public void GetDirections()
        {
            string location = "0.34,0.78";

            // Create a URI with the Google Maps query
            Uri googleMapsUri = new Uri($"https://maps.google.com/maps?q={location}");

            // Open Google Maps using the device's default browser
            Device.OpenUri(googleMapsUri);
        }
        public async void BookAgain()
        {
            await Shell.Current.GoToAsync("//MakeBooking");
            //await Application.Current.MainPage.Navigation.PushAsync(new MakeBookingPage());


        }
        private void SetDefaultValues()
        {
            Device.BeginInvokeOnMainThread(() => {
                BookingID = "BookingID:  " + booking.ReferenceCode;
                LocationName = booking.Location.Name;
                LocationAddress = booking.Location.address.DisplayLine1;
                LocationCity = booking.Location.address.AddressCity;
                BookingDate = booking.DateTimeLocalISO.DayOfWeek.ToString() + ", " + booking.DateTimeLocalISO.Day.ToString() + " " + booking.DateTimeLocalISO.Date.ToString("MMMM");
                BookingLocation = booking.Location.address.DisplayLine1;//  "Westfield Junction, NSW 1133";
                BookingTime = booking.SlotTimeFormattedDisplay;
                UnitsConsumed = booking.ChargeKiloWattsConsumedDisplay;
                Duration = booking.DurationDisplay;
                ChargingFee = booking.EstimatedPaymentAmountExTax;
                ServiceCharges = booking.ChargeServiceChargesDisplay;
                Subtotal = booking.ChargeSubTotalDisplay;
                Tax = booking.ChargeTaxDisplay;
                GrandTotal = booking.ChargeTotalAmountIncTaxDisplay;
                StartTime = booking.SlotStartTimeFormattedDisplay;
                EndTime = booking.SlotEndTimeFormattedDisplay;
            });
           
        }
    }
}
