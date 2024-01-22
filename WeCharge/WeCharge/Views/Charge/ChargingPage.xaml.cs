using System;
using System.Collections.Generic;
using System.Windows.Input;
using WeCharge.CustomControls;
using WeCharge.Models.RequestModels;
using WeCharge.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Views.Charge
{	
	public partial class ChargingPage : ContentPage
	{
        ChargeEstimateRequest chargeRequestEstimate;
        ChargingPageViewModel chargingPageViewModel;
        public ChargingPage()
        {
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            chargingPageViewModel = new ChargingPageViewModel(chargeRequestEstimate);
            BindingContext = chargingPageViewModel;
        }
        public ChargingPage(ChargeEstimateRequest _chargeEstimateRequest)
        {
            chargeRequestEstimate = _chargeEstimateRequest;
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            chargingPageViewModel = new ChargingPageViewModel(chargeRequestEstimate);
            BindingContext = chargingPageViewModel;
        }

        protected override void OnAppearing()
        {
            chargingPageViewModel.StartChargingProgressTimer();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            chargingPageViewModel.isTimerRunning = false;
            base.OnDisappearing();
        }

        //public ChargingPage(ChargeEstimateRequest _chargeEstimateRequest)
        //{
        //    chargeEstimateRequest = _chargeEstimateRequest;
        //    Shell.SetTabBarIsVisible(this, false);
        //    InitializeComponent();
        //    chargingPageViewModel = new ChargingPageViewModel();
        //    BindingContext = chargingPageViewModel;
        //}
        async void NeedHelpClicked(System.Object sender, System.EventArgs e)
        {
            string phoneNumber = "1234567890"; // Replace with the desired phone number
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch(PermissionException)
            {
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Error", "Phone dialing is not supported on this platform.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Phone dialing is not opening due to "+ex.ToString(), "OK");
            }

        }
    }
}

