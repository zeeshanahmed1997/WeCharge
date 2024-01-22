using System;
using System.Collections.Generic;
using System.Linq;
using WeCharge.Models.Booking;
using Xamarin.Forms;

namespace WeCharge.Views.MakeBooking
{
    public partial class ConfirmBookingPage : ContentPage
    {
        ConfirmBookingPageViewModel confirmBookingPageViewModel;
        public ConfirmBookingPage(BookSpace bookSpace)
        {
            InitializeComponent();
            confirmBookingPageViewModel = new ConfirmBookingPageViewModel(bookSpace);
            BindingContext = confirmBookingPageViewModel;
        }
    }
}

