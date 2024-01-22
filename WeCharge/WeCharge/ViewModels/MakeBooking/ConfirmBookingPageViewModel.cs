using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using WeCharge.Services;
using WeCharge.ViewModels;
using WeCharge.Views.Popup;
using Xamarin.Forms;
using WeCharge.Models.Booking;
using static WeCharge.ViewModels.CheckAvailabilityPageViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using WeCharge.Models.RequestModels;
using System.Globalization;
using WeCharge.Models;

namespace WeCharge.Views.MakeBooking
{
    public class ConfirmBookingPageViewModel : BaseViewModel
    {
        BookingResponse bookingResponse;
        ConfirmBookingResponse confirmBookingResponse;
        string BookingId;
        private TimerManager _timerManager;
        public BookSpace bookSpace;
        public ICommand ConfirmButtonClicked { get; private set; }
        public ICommand BackButtonClicked { get; private set; }
        public ICommand ShellBackButtonCommand { get; private set; }

        private TimeSpan _remainingTime;
        public TimeSpan RemainingTime
        {
            get { return _remainingTime; }
            set
            {
                if (_remainingTime != value)
                {
                    _remainingTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isTimerRunning;
        public bool IsTimerRunning
        {
            get { return _isTimerRunning; }
            set
            {
                if (_isTimerRunning != value)
                {
                    _isTimerRunning = value;
                    OnPropertyChanged();
                }
            }
        }
        public ConfirmBookingPageViewModel()
        {
            ConfirmButtonClicked = new Command(async () => await ConfirmBookingAsync());
            BackButtonClicked = new Command(GoBack);
            ShellBackButtonCommand = new Command(ShellBackButtonPressed);

            // Set the timer manager with a target time of 15 minutes
            _timerManager = new TimerManager(TimeSpan.FromMinutes(15));
            _timerManager.TimerTick += (sender, remainingTime) => RemainingTime = remainingTime;
            _timerManager.Start();

            SetDefaultValues();
        }
        public ConfirmBookingPageViewModel(BookSpace bookSpace)
        {
            this.bookSpace = bookSpace;
            ConfirmButtonClicked = new Command(async () => await ConfirmBookingAsync());
            BackButtonClicked = new Command(GoBack);
            ShellBackButtonCommand = new Command(ShellBackButtonPressed);

            // Set the timer manager with a target time of 15 minutes
            _timerManager = new TimerManager(TimeSpan.FromMinutes(15));
            _timerManager.TimerTick += (sender, remainingTime) => RemainingTime = remainingTime;
            _timerManager.Start();


            SetDefaultValues();
        }
        private void SetDefaultValues()
        {
            //  StartTimer();
            
            BookingId = bookSpace.Booking.ID;
            LocationName = bookSpace.Booking.Location.Name;
            LocationAddress = bookSpace.Booking.Location.address.DisplayLine1;
            LocationCity = bookSpace.Booking.Location.Name;
            DateText = bookSpace.Date.DayOfWeek.ToString() + ", " + bookSpace.Date.Day.ToString() + " " + bookSpace.Date.ToString("MMMM");
            LocationInfo = bookSpace.Booking.Location.address.DisplayLine1;
            Time = bookSpace.selectedStartTime.ToString();
            
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

        private string dateText;
        public string DateText
        {
            get => dateText;
            set => SetProperty(ref dateText, value);
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
        public async Task ConfirmBookingAsync()
        {
            try
            {
                IsBusy = true; // Show the activity indicator

                var connectivityStatus = NetworkHelper.UpdateConnectivityStatus();
                Console.WriteLine("Connectivity status: " + connectivityStatus);

                if (connectivityStatus)
                {
                    ConfirmBookingRequest confirmBookingRequest = new ConfirmBookingRequest();
                    confirmBookingRequest.BookingID = BookingId;
                    confirmBookingResponse = await App.weChargeService.bookingsService.ConfirmBooking(confirmBookingRequest);
                    Console.WriteLine("Confirm booking status: " + confirmBookingResponse._Status);

                    if (confirmBookingResponse?._Status == "Success")
                    {
                        await Task.Delay(1000); // You may want to review the necessity of this delay.

                        bookingResponse = await App.weChargeService.bookingsService.GetPendingBookings();

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            // Create an instance of BookingConfirmedPage
                            var bookingConfirmedPage = new BookingConfirmedPage(bookSpace);

                            // Clear the entire navigation stack except BookingConfirmedPage
                            var navigationStack = Application.Current.MainPage.Navigation.NavigationStack.ToList();
                            foreach (var page in navigationStack)
                            {
                                if (page != null && page != bookingConfirmedPage)
                                {
                                    Application.Current.MainPage.Navigation.RemovePage(page);
                                }
                            }

                            // Push the BookingConfirmedPage onto the navigation stack
                            await Application.Current.MainPage.Navigation.PushAsync(bookingConfirmedPage);

                            IsBusy = false; // Hide the activity indicator
                        });

                    }
                    else
                    {
                        IsBusy = false; // Hide the activity indicator if booking failed
                    }
                }
                else
                {
                    var netErrorPopup = new NetworkErrorPopup();
                    netErrorPopup.ClosePopupAction = async () =>
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                    };

                    await PopupNavigation.Instance.PushAsync(netErrorPopup);
                    IsBusy = false; // Hide the activity indicator
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the async operation
                // For example, log the exception or show a message to the user.
                Console.WriteLine(ex);
                IsBusy = false;
            }
        }


        public async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MakeBookingPage());
        }
        public async void ShellBackButtonPressed()
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(bookSpace.Date.Month);
            App.cancelBookingDate = bookSpace.Date.Day + "-" + monthName + "-" + bookSpace.Date.Year.ToString();
            App.BookingId = bookSpace.BookingID;
            var GoBack = new GoBackPopup();
            await PopupNavigation.Instance.PushAsync(GoBack);

        }
        public void StartTimer()
        {
            //Starting timer using Timer Service intialized in App.xaml
            App.TimerManagerInstance.TimerTick += TimerTickHandler;
        }

        public void StopTimer()
        {
            // Stop the timer when needed
            App.TimerManagerInstance.TimerTick -= TimerTickHandler;
        }

        private void TimerTickHandler(object sender, TimeSpan remainingTime)
        {
            RemainingTime = remainingTime;
        }
    }
}
