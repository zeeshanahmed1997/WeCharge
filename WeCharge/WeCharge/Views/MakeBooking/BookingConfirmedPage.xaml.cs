using System;
using System.Collections.Generic;
using WeCharge.Models.Booking;
using WeCharge.ViewModels;
using WeCharge.Views.Booking;
using WeCharge.Views.BottomTab;
using WeCharge.Views.Connect;
using Xamarin.Forms;

namespace WeCharge.Views.MakeBooking
{
    public partial class BookingConfirmedPage : ContentPage
    {
        BookingConfirmedPageViewModel bookingConfirmedPageViewModel;
        public BookingConfirmedPage()
        {
            InitializeComponent();
            bookingConfirmedPageViewModel = new BookingConfirmedPageViewModel();
            BindingContext = bookingConfirmedPageViewModel;
        }
        public BookingConfirmedPage(BookSpace bookSpace)
        {
            InitializeComponent();
            bookingConfirmedPageViewModel = new BookingConfirmedPageViewModel(bookSpace);
            BindingContext = bookingConfirmedPageViewModel;
        }
        void GoToHome_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new MakeBookingPage());
            Shell.Current.GoToAsync("//Home");
            //Shell.Current.Navigation.PopToRootAsync(animated: false);
        }

        void MakeNewBookingTapped(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//MakeBooking");
            Navigation.PushAsync(new CheckAvailabilityPage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability");
        }

        void StartChargingClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ConnectVehiclePage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle");
        }
    }
}

