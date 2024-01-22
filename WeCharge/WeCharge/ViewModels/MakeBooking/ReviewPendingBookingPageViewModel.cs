using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;


using Rg.Plugins.Popup.Services;

using WeCharge.Models.Booking;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Accounts;
using WeCharge.Views.BottomTab;
using WeCharge.Views.MakeBooking;
using WeCharge.Views.Popup;

using Xamarin.Essentials;
using Xamarin.Forms;

using static WeCharge.ViewModels.CheckAvailabilityPageViewModel;

using Color = Xamarin.Forms.Color;

namespace WeCharge.ViewModels
{
    public class ReviewPendingBookingPageViewModel : BaseViewModel
    {
        ConfirmBookingResponse confirmBookingResponse;
        BookingResponseForbookCharger bookingResponse;
        Models.Booking.Booking booking;

        public ICommand BookSpaceClicked { get; private set; }
        public ICommand CancelBookingCommand { get; private set; }

        AvailableChargeSlotRequestModel availableChargeSlotRequestModel;
        Model.MakeBooking.MakeBooking location;


        private int durationSelectedIndex = 0;
        public int DurationSelectedIndex
        {
            get => durationSelectedIndex;
            set
            {
                SetProperty(ref durationSelectedIndex, value);
                // Change the border color based on the value
                DurationBorderColor = value == -1 ? Color.Default : Color.LightGray;
            }
        }

        private int availableSlotSelectedIndex = 0;
        public int AvailableSlotSelectedIndex
        {
            get => availableSlotSelectedIndex;
            set
            {
                SetProperty(ref availableSlotSelectedIndex, value);
                // Change the border color based on the value
                AvailableSlotBorderColor = value == -1 ? Color.Default : Color.LightGray;
            }
        }
        private Color durationBorderColor = Color.Default;
        public Color DurationBorderColor
        {
            get => durationBorderColor;
            set => SetProperty(ref durationBorderColor, value);
        }
        private Color availableSlotBorderColor = Color.Default;
        public Color AvailableSlotBorderColor
        {
            get => availableSlotBorderColor;
            set => SetProperty(ref availableSlotBorderColor, value);
        }
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

        private string locationIcon;
        public string LocationIcon
        {
            get => locationIcon;
            set => SetProperty(ref locationIcon, value);
        }

        private string locationInfo;
        public string LocationInfo
        {
            get => locationInfo;
            set => SetProperty(ref locationInfo, value);
        }

        private string locationInfoIcon;
        public string LocationInfoIcon
        {
            get => locationInfoIcon;
            set => SetProperty(ref locationInfoIcon, value);
        }

        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetProperty(ref selectedDate, value);
        }

        private string timeIcon;
        public string TimeIcon
        {
            get => timeIcon;
            set => SetProperty(ref timeIcon, value);
        }

        private string date;
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private ObservableCollection<string> durationItems;
        public ObservableCollection<string> DurationItems
        {
            get => durationItems;
            set => SetProperty(ref durationItems, value);
        }

        private string selectedDuration;
        public string SelectedDuration
        {
            get => selectedDuration;
            set => SetProperty(ref selectedDuration, value);
        }
        private string availableSlotItems;
        public string AvailableSlotItems
        {
            get => availableSlotItems;
            set => SetProperty(ref availableSlotItems, value);
        }
        private string selectedAvailableSlot;
        public string SelectedAvailableSlot
        {
            get => selectedAvailableSlot;
            set => SetProperty(ref selectedAvailableSlot, value);
        }

        private string selectedSlot;
        public string SelectedSlot
        {
            get { return selectedSlot; }
            set
            {
                if (selectedSlot != value)
                {
                    selectedSlot = value;
                    OnPropertyChanged(nameof(SelectedSlot));
                }
            }
        }
        public double ConvertMinutesToHours(int minutes)
        {
            return (double)minutes / 60.0;
        }

        private void SetDefaultValues()
        {
            LocationName = booking.Location.Name;
            LocationAddress = booking.Location.address.DisplayLine1;
            LocationCity = booking.Location.address.AddressCity;
            LocationInfo = booking.Location.DistanceFromUserDisplay;
            Time = booking.Location.TimeFromUserDisplay;
            Date = booking.DateTimeLocalISO.DayOfWeek.ToString() + ", " + booking.DateTimeLocalISO.Day.ToString() + " " + booking.DateTimeLocalISO.Date.ToString("MMMM");
            

            SelectedDate = booking.DateTimeLocalISO;
            int durationInMinutes = booking.DurationMinutes;

            string durationString = "";
            if (durationInMinutes >= 60)
            {
                int hours = durationInMinutes / 60;
                durationString = $"{hours} hour";


                int minutes = durationInMinutes % 60;
                if (minutes > 0)
                {
                    durationString += $" {minutes} minute";
                }
            }
            else
            {
                durationString = $"{durationInMinutes} minute";
            }

            SelectedDuration = durationString;
            DurationItems = new ObservableCollection<string>
            {
                durationString,
            };
            for (int i = 15; i <= 240; i += 15)
            {
                string interval = i >= 60 ? $"{i / 60} hour {(i % 60 == 0 ? "" : i % 60 + " minute")}" : $"{i} minute";
                if (!durationString.Contains(interval))
                {
                    DurationItems.Add(interval);
                }
            }
            string startTime = booking.SlotTimeFormattedDisplay.Split(' ')[0];
            SelectedAvailableSlot = startTime;
            AvailableSlotItems = startTime.ToString();

            DurationSelectedIndex = 0; // Set the selected index to 0
            AvailableSlotSelectedIndex = 0;
        }

        public ReviewPendingBookingPageViewModel(Models.Booking.Booking _booking)
        {
            confirmBookingResponse = new ConfirmBookingResponse();
            booking = _booking;
            BookSpaceClicked = new Command(BookSpace);
            CancelBookingCommand = new Command(CancelBooking);

            SetDefaultValues();
        }
        public void CancelBooking()
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(booking.DateTimeLocalISO.Month);
            App.cancelBookingDate = booking.DateTimeLocalISO.Day + "-" + monthName + "-" + booking.DateTimeLocalISO.Year.ToString();
            App.BookingId = booking.ID.ToString();
            var GoBack = new GoBackPopup();
            PopupNavigation.Instance.PushAsync(GoBack);
        }
        public async void BookSpace()
        {

            BookSpace bookSpace;
            int selectedDurationMinutes = -1;
            var durationEnumValues = Enum.GetValues(typeof(Duration)).Cast<Duration>().ToArray();
            if (DurationSelectedIndex >= 0 && DurationSelectedIndex < durationEnumValues.Length)
            {
                selectedDurationMinutes = (int)durationEnumValues[DurationSelectedIndex];
            }


            IsBusy = true; // Show the activity indicator

            try
            {
                // Forming the request model
                BookChargerRequestModel bookChargerRequestModel = new BookChargerRequestModel
                {
                    ChargerID = booking.ChargerID,
                    LocationID = booking.LocationID,
                    DateLocalISO = $"{SelectedDate.Year}-{SelectedDate.Month}-{SelectedDate.Day}",
                    DurationMinutes = selectedDurationMinutes
                };

                string selectedStartTime = AvailableSlotItems.ToString();//[AvailableSlotSelectedIndex];

                ConfirmBookingRequest confirmBookingRequest = new ConfirmBookingRequest
                {
                    BookingID = booking.ID
                };

                // Making the booking confirmation request
                confirmBookingResponse = await App.weChargeService.bookingsService.ConfirmBooking(confirmBookingRequest);
                if (confirmBookingResponse?.Status == "Success")
                {
                    bookSpace = new BookSpace
                    {
                        BookingID = booking.ID, // Make sure bookingResponse is defined
                        Booking = booking,
                        RemainingTime = Time, // Ensure Time is defined and valid
                        Date = SelectedDate,
                        selectedDurationMinutes = selectedDurationMinutes,
                        selectedStartTime = selectedStartTime
                    };
                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Task.Delay(1000);
                        await Application.Current.MainPage.Navigation.PushAsync(new BookingConfirmedPage(bookSpace));
                        IsBusy = false; // Hide the activity indicator
                    });
                }
                else if (confirmBookingResponse.Status == "FailedPendingBookingExpired")
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        IsBusy = false;
                        await PopupNavigation.Instance.PushAsync(new BookingExpiredPopup());
                        //bookingResponse = await App.weChargeService.bookingsService.BookCharger(bookChargerRequestModel);
                        //booking.ID = bookingResponse.BookingID;
                    });
                }
                // Consider handling other potential statuses
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    // Handle exceptions and update the UI on the main thread
                    // For example, display an error message to the user
                    IsBusy = false; // Ensure the activity indicator is hidden
                });
                Debug.WriteLine($"Error in BookSpace: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}
