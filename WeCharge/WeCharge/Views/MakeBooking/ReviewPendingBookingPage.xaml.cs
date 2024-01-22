using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using WeCharge.ViewModels;
using WeCharge.Views.Popup;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace WeCharge.Views.MakeBooking
{
    public partial class ReviewPendingBookingPage : ContentPage
    {
        Models.Booking.Booking booking;
        ReviewPendingBookingPageViewModel reviewPendingBookingPageViewModel;
        public ReviewPendingBookingPage(string date,string address,string time)
        {
            //MyCustomPicker.IsVisible = false;
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.Today;
            reviewPendingBookingPageViewModel = new ReviewPendingBookingPageViewModel(booking);
            BindingContext = reviewPendingBookingPageViewModel;
            MessagingCenter.Subscribe<ReviewPendingBookingPageViewModel>(this, "ShowCustomPopupRequested", async (sender) =>
            {
                // Navigate to your custom popup page
                await PopupNavigation.PushAsync(new AlreadyBookedPopup());
            });
        }
        public ReviewPendingBookingPage(Models.Booking.Booking _booking)
        {
            booking = _booking;
            //MyCustomPicker.IsVisible = false;
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.Today;
            reviewPendingBookingPageViewModel = new ReviewPendingBookingPageViewModel(booking);

            BindingContext = reviewPendingBookingPageViewModel;
            MessagingCenter.Subscribe<ReviewPendingBookingPageViewModel>(this, "ShowCustomPopupRequested", async (sender) =>
            {
                await PopupNavigation.PushAsync(new AlreadyBookedPopup());
            });
        }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            DurationPicker.Focus();
            AvailableSlotPicker.Focus();
        }
        void CancelButtonClicked(System.Object sender, System.EventArgs e)
        {
            var GoBack = new GoBackPopup();
            PopupNavigation.Instance.PushAsync(GoBack);


        }
        void DatePickerTapped(System.Object sender, System.EventArgs e)
        {
            DatePicker.Focus();
        }
    }
}

