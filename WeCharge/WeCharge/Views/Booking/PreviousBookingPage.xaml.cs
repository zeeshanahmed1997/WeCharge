using System;
using System.Collections.Generic;
using WeCharge.ViewModels;
using Xamarin.Forms;

namespace WeCharge.Views.Booking
{
    public partial class PreviousBookingPage : ContentPage
    {
        Models.Booking.Booking booking;
        PreviousBookingPageViewModel previousBookingPageViewModel;
        public PreviousBookingPage()
        {
            Shell.SetTabBarIsVisible(this, false);
            previousBookingPageViewModel = new PreviousBookingPageViewModel();
            InitializeComponent();
            BindingContext = previousBookingPageViewModel;

        }
        public PreviousBookingPage(Models.Booking.Booking _booking)
        {
            booking = _booking;
            Shell.SetTabBarIsVisible(this, false);
            previousBookingPageViewModel = new PreviousBookingPageViewModel(booking);
            InitializeComponent();
            BindingContext = previousBookingPageViewModel;

        }
    }
}

