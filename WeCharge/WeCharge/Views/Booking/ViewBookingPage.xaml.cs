using System;
using System.Collections.Generic;
using WeCharge.ViewModels.Booking;
using Xamarin.Forms;

namespace WeCharge.Views.Booking
{	
	public partial class ViewBookingPage : ContentPage
	{
        Models.Booking.Booking booking;
        ViewBookingPageViewModel viewBookingPageViewModel;
		public ViewBookingPage ()
		{

            Shell.SetTabBarIsVisible(this, false);
            //var itm = Shell.Current.CurrentItem;
            //itm.CurrentItem = (itm as FlyoutItem).Items[1];
            InitializeComponent();
            viewBookingPageViewModel = new ViewBookingPageViewModel();

            // Set the ViewModel as the BindingContext
            BindingContext = viewBookingPageViewModel;
        }
        public ViewBookingPage(Models.Booking.Booking _booking)
        {
            booking = _booking;
            Shell.SetTabBarIsVisible(this, false);
            //var itm = Shell.Current.CurrentItem;
            //itm.CurrentItem = (itm as FlyoutItem).Items[1];
            InitializeComponent();
            viewBookingPageViewModel = new ViewBookingPageViewModel(booking);

            // Set the ViewModel as the BindingContext
            BindingContext = viewBookingPageViewModel;
        }
    }
}

