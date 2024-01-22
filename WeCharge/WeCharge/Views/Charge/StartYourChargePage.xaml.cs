using System;
using System.Collections.Generic;
using WeCharge.Models.RequestModels;
using WeCharge.ViewModels;
using WeCharge.Views.Booking;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.Views.Charge
{	
	public partial class StartYourChargePage : ContentPage
	{
        ChargeEstimateRequest chargeEstimateRequest;
        StartYourChargePageViewModel startYourChargePageViewModel;
		public StartYourChargePage ()
		{
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent ();
			startYourChargePageViewModel = new StartYourChargePageViewModel();
			BindingContext = startYourChargePageViewModel;
        }
        public StartYourChargePage(ChargeEstimateRequest _chargeEstimateRequest)
        {
            chargeEstimateRequest = _chargeEstimateRequest;
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            startYourChargePageViewModel = new StartYourChargePageViewModel(chargeEstimateRequest);
            BindingContext = startYourChargePageViewModel;
        }
        void PresetChargeCostButtonClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChargeEstimatePage("StartYourChargePage", this.chargeEstimateRequest));
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle/StartYourCharge/ChargeEstimate");
        }
        void ChargeEstimateButtonClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChargeEstimatePage("", this.chargeEstimateRequest));
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle/StartYourCharge/ChargeEstimate");
        }
    }
}

