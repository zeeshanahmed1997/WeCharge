using System;
using System.Collections.Generic;
using WeCharge.Models.RequestModels;
using WeCharge.ViewModels;
using WeCharge.Views.Booking;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.Views.Charge
{	
	public partial class ChargedPage : ContentPage
	{
        ChargeEstimateRequest chargeEstimateRequest;
        public ChargedPage ()
		{
			InitializeComponent ();
            GoToHome.IsEnabled = false;
            MakeNewBooking.IsEnabled = false;
            ChargedPageViewModel chargedPageViewModel = new ChargedPageViewModel();

            // Set the BindingContext of the page to the ViewModel
            BindingContext = chargedPageViewModel;
            GoToHome.IsEnabled = true;
            MakeNewBooking.IsEnabled = true;
        }
        public ChargedPage(ChargeEstimateRequest _chargeRequestEstimate)
        {
            chargeEstimateRequest = _chargeRequestEstimate;
            InitializeComponent();
            ChargedPageViewModel chargedPageViewModel = new ChargedPageViewModel(chargeEstimateRequest);

            // Set the BindingContext of the page to the ViewModel
            BindingContext = chargedPageViewModel;
        }
        void GoToHome_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new MakeBookingPage());
            Shell.Current.GoToAsync("//Home");
        }
        void MakeNewBookingTapped(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new CheckAvailabilityPage());
            Shell.Current.GoToAsync("//MakeBooking");
            //Navigation.PushAsync(new CheckAvailabilityPage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability");
        }
    }
}

