using System;
using System.Collections.Generic;
using WeCharge.CustomControls;
using WeCharge.Models.RequestModels;
using WeCharge.ViewModels;
using WeCharge.Views.Booking;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.Views.Charge
{	
	public partial class ChargeEstimatePage : ContentPage
	{
        ChargeEstimateRequest chargeEstimateRequest;
        private string _originPageName;
        public Color EntryBackgroundColor { get; set; } = Color.LightBlue; // Replace with your desired color
        public Color PlaceholderTextColor { get; set; } = Color.White; // Replace with your desired color

        ChargeEstimatePageViewModel chargedEstimatePageViewModel;
        public ChargeEstimatePage(string originPageName, ChargeEstimateRequest _chargeEstimateRequest)
        {
            _originPageName = originPageName;
            chargeEstimateRequest = _chargeEstimateRequest;
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            chargedEstimatePageViewModel = new ChargeEstimatePageViewModel(chargeEstimateRequest);
            BindingContext = chargedEstimatePageViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_originPageName == "StartYourChargePage")
            {
                SetChargeCost.IsVisible = true;
            }
            else {
                SetChargeCost.IsVisible = false;
            }

        }
        void StartChargingButtonClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChargingPage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle/StartYourCharge/ChargeEstimate/Charging");
        }

        void OtherAmount_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                // Check if the entered text is a valid integer
                if (!int.TryParse(e.NewTextValue, out _))
                {
                    // If not a valid integer, remove the last character
                    OtherAmount.Text = e.OldTextValue;
                }
            }
        }
    }
}

