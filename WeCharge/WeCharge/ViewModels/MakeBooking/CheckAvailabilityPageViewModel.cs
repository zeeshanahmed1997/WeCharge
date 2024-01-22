using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Rg.Plugins.Popup.Services;

using WeCharge.Models;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.Charge;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Accounts;
using WeCharge.Views.MakeBooking;
using WeCharge.Views.Popup;

using Xamarin.Essentials;
using Xamarin.Forms;

using static WeCharge.Models.Booking.Location;

namespace WeCharge.ViewModels
{
    public class CheckAvailabilityPageViewModel : BaseViewModel
    {
        AvailableChargeSlotsResponse availableSlots;
        Models.Booking.BookSpace bookSpace;
        BookingResponseForbookCharger bookingResponse;
        Model.MakeBooking.MakeBooking location;
        AvailableChargeSlotRequestModel availableChargeSlotRequestModel;
        public ICommand BookSpaceClicked { get; private set; }

        private bool _slotPickerEnable = false;
        public bool SlotPickerEnable
        {
            get => _slotPickerEnable;
            set => SetProperty(ref _slotPickerEnable, value);
        }
        private Color _labelIconColor = Color.Red;
        public Color LabelIconColor
        {
            get => _labelIconColor;
            set => SetProperty(ref _labelIconColor, value);
        }

        private string _titleText = "Not Available";
        public string TitleText
        {
            get => _titleText;
            set => SetProperty(ref _titleText, value);
        }
        private int durationSelectedIndex = -1;
        public int DurationSelectedIndex
        {
            get => durationSelectedIndex;
            set
            {
                SetProperty(ref durationSelectedIndex, value);
                // Change the border color based on the value
                DurationBorderColor = value == -1 ? Color.Default : Color.LightGray;
                if (value != -1) // Check if a valid selection was made
                {
                    SetSlotPickerEnableAsync();
                }
            }
        }



        private int availableSlotSelectedIndex = -1;
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

        private DateTime selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetProperty(ref selectedDate, value);
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
            set
            {
                SetProperty(ref selectedDuration, value);
            }
        }
        private ObservableCollection<string> availableSlotItems;
        public ObservableCollection<string> AvailableSlotItems
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



        private async void SetSlotPickerEnableAsync() => await Task.Run(async () =>
                                                                  {
                                                                      await GetAvailableSlots();
                                                                      // await Task.Delay(1000);
                                                                      // Set SlotPickerEnable to true after the delay
                                                                      Device.BeginInvokeOnMainThread(() => SlotPickerEnable = true);
                                                                  });

        private void SetDefaultValues()
        {
            if (location != null) // Check if location is not null
            {

                LocationName = location.Location;
                LocationAddress = location.Address;
                LocationCity = location.City;
                LocationInfo = location.Distance;
                Time = location.Time;
                string stats = location.status;
                if (location.location.LocationCurrentAvailabilityStatusText != null)
                {
                    //TitleText = availableSlots.LocationCurrentAvailabilityStatusText;
                    if (location.location.LocationCurrentAvailabilityStatusText == "Available now")
                    {
                        LabelIconColor = Color.Green;
                        TitleText = "Available Now";
                    }
                    else if (location.location.LocationCurrentAvailabilityStatusText == "Offline")
                    {
                        LabelIconColor = Color.Red;
                        TitleText = "Offline";
                    }
                    else if (location.location.LocationCurrentAvailabilityStatusText == "Not available")
                    {
                        LabelIconColor = Color.Orange;
                        TitleText = "Not Available";
                    }
                }
            }

            DurationItems = new ObservableCollection<string>();
            foreach (Duration duration in Enum.GetValues(typeof(Duration)))
            {
                int durationMinutes = (int)duration;
                string durationText;

                if (durationMinutes >= 60)
                {
                    int hours = durationMinutes / 60;
                    int minutes = durationMinutes % 60;

                    if (minutes > 0)
                    {
                        durationText = $"{hours} hour{(hours > 1 ? "s" : "")} {minutes} mins";
                    }
                    else
                    {
                        durationText = $"{hours} hour{(hours > 1 ? "s" : "")}";
                    }
                }
                else
                {
                    durationText = $"{durationMinutes} mins";
                }

                DurationItems.Add(durationText);
            }

            SelectedAvailableSlot = "";
        }
        public async Task GetAvailableSlots()
        {
            // conditon to check internet connection.
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                if (DurationSelectedIndex != -1)
                {
                    availableChargeSlotRequestModel = new AvailableChargeSlotRequestModel();

                    // Convert the DurationSelectedIndex to its corresponding Duration enum value.
                    Duration selectedDurationEnumValue = (Duration)Enum.GetValues(typeof(Duration)).GetValue(DurationSelectedIndex);
                    int selectedDurationInMinutes = (int)selectedDurationEnumValue;

                    // Use the extracted minutes in the request model.
                    availableChargeSlotRequestModel.LocationID = this.location.LocationID;
                    availableChargeSlotRequestModel.CheckDurationMinutes = selectedDurationInMinutes;
                    availableChargeSlotRequestModel.CheckDateLocalISO = selectedDate.ToString();

                    await Task.Run(async () =>
                    {

                        availableSlots = await App.weChargeService.bookingsService.CheckLocationAvailability(availableChargeSlotRequestModel);

                        var startTimes = availableSlots.AvailableChargeSlots.Select(slot => slot.StartTime).ToList();
                        if (availableSlots != null)
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                AvailableSlotItems = new ObservableCollection<string>(startTimes);
                            });
                        }
                    });
                }
            }
            else
            {
                if (PopupNavigation.Instance.PopupStack.Count == 0)
                {


                    NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();


                    networkErrorPopup.ClosePopupAction = async () =>
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                        GetAvailableSlots();
                    };

                    PopupNavigation.Instance.PushAsync(networkErrorPopup);
                }

            }

        }

        public CheckAvailabilityPageViewModel()
        {
            BookSpaceClicked = new Command(BookSpace);

            SetDefaultValues();
        }
        public CheckAvailabilityPageViewModel(Model.MakeBooking.MakeBooking _location)
        {
            location = _location;

            BookSpaceClicked = new Command(BookSpace);
            SetDefaultValues();
        }
        public async void BookSpace()
        {
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                //IsButtonEnable = false;
                if (durationSelectedIndex == -1 && availableSlotSelectedIndex == -1)
                {
                    DurationBorderColor = Color.Red;
                    AvailableSlotBorderColor = Color.Red;
                    return;
                }
                else if (durationSelectedIndex == -1)
                {
                    DurationBorderColor = Color.Red;
                    return;
                }
                else if (availableSlotSelectedIndex == -1)
                {
                    AvailableSlotBorderColor = Color.Red;
                    return;
                }

                // Retrieve selected duration value
                int selectedDurationMinutes = -1;

                var durationEnumValues = Enum.GetValues(typeof(Duration)).Cast<Duration>().ToArray();
                if (DurationSelectedIndex >= 0 && DurationSelectedIndex < durationEnumValues.Length)
                {
                    selectedDurationMinutes = (int)durationEnumValues[DurationSelectedIndex];
                }

                availableChargeSlotRequestModel.LocationID = this.location.LocationID;
                availableChargeSlotRequestModel.CheckDurationMinutes = selectedDurationMinutes;
                availableChargeSlotRequestModel.CheckDateLocalISO = SelectedDate.ToString();

                AvailableChargeSlotsResponse availableSlots = await App.weChargeService.bookingsService.CheckLocationAvailability(availableChargeSlotRequestModel);

                var startTimes = availableSlots?.AvailableChargeSlots.Select(slot => slot.StartTime).ToList();
                string selectedStartTime = null;
                if (startTimes.Count != 0)
                {
                    if (AvailableSlotSelectedIndex != -1 && AvailableSlotItems != null && AvailableSlotItems.Count > AvailableSlotSelectedIndex)
                    {
                        selectedStartTime = AvailableSlotItems[AvailableSlotSelectedIndex];
                    }
                    if (selectedDurationMinutes == -1 || string.IsNullOrEmpty(selectedStartTime))
                    {
                        return;
                    }
                }
                selectedStartTime = AvailableSlotItems[AvailableSlotSelectedIndex];
                Models.Booking.Booking booking = new Models.Booking.Booking();
                booking.Location.address.AddressCountryName = this.LocationName;
                booking.Location.address.AddressLine1 = this.locationAddress;
                booking.Location.address.AddressCity = this.LocationCity;
                booking.Location.DistanceFromUserDisplay = this.LocationInfo;
                booking.LocationID = this.location.LocationID.ToString();
                booking.ChargerID = availableSlots?.AvailableChargeSlots[AvailableSlotSelectedIndex].ChargerID;
                BookChargerRequestModel bookChargerRequestModel = new BookChargerRequestModel();
                bookChargerRequestModel.ChargerID = booking.ChargerID;
                bookChargerRequestModel.LocationID = booking.LocationID;
                bookChargerRequestModel.DateLocalISO = this.SelectedDate.Year.ToString() + "-" + this.SelectedDate.Month.ToString() + "-" + this.SelectedDate.Day.ToString();
                bookChargerRequestModel.DurationMinutes = selectedDurationMinutes;
                bookChargerRequestModel.StartTime = selectedStartTime;
                await Task.Run(async () =>
                {
                    IsBusy = true; // Show the activity indicator
                    bookingResponse = await App.weChargeService.bookingsService.BookCharger(bookChargerRequestModel);
                    if (bookingResponse?._Status == "Success")
                    {
                        string s = bookingResponse.Booking.ChargerID;
                        Console.WriteLine("Charger ID is:", s);
                        bookSpace = new BookSpace
                        {
                            BookingID = bookingResponse.Booking.ID,
                            Booking = bookingResponse.Booking,
                            RemainingTime = this.Time,
                            Date = this.SelectedDate,
                            selectedDurationMinutes = selectedDurationMinutes,
                            selectedStartTime = selectedStartTime,
                            ChargerID = bookingResponse.Booking.ChargerID
                        };
                    }
                });




                //await Task.Delay(1000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    // Create an instance of ConfirmBookingPage
                    var confirmBookingPage = new ConfirmBookingPage(bookSpace);

                    // Clear the entire navigation stack except ConfirmBookingPage
                    var navigationStack = Application.Current.MainPage.Navigation.NavigationStack.ToList();
                    foreach (var page in navigationStack)
                    {
                        if (page != null && page != confirmBookingPage)
                        {
                            Application.Current.MainPage.Navigation.RemovePage(page);
                        }
                    }

                    // Push the ConfirmBookingPage onto the navigation stack
                    Application.Current.MainPage.Navigation.PushAsync(confirmBookingPage);

                    IsBusy = false; // Hide the activity indicator
                                    //IsButtonEnable = true;
                });
            }
            else
            {
                NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();
                networkErrorPopup.ClosePopupAction = async () =>
                {
                    await PopupNavigation.Instance.PopAllAsync();

                };
                await PopupNavigation.Instance.PushAsync(networkErrorPopup);

            }
            //################

        }

        public enum Duration
        {
            Minutes15 = 15,
            Minutes30 = 30,
            Minutes45 = 45,
            Hour1 = 60,
            Hour1Minutes15 = 75,
            Hour1Minutes30 = 90,
            Hour1Minutes45 = 105,
            Hour2 = 120,
            Hour2Minutes15 = 135,
            Hour2Minutes30 = 150,
            Hour2Minutes45 = 165,
            Hour3 = 180,
            Hour3Minutes15 = 195,
            Hour3Minutes30 = 210,
            Hour3Minutes45 = 225,
            Hour4 = 240
        }

    }
}
