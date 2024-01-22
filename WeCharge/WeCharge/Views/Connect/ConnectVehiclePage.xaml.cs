using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WeCharge.Models.RequestModels;
using WeCharge.ViewModels;
using WeCharge.Views.Booking;
using WeCharge.Views.Charge;
using WeCharge.Views.MakeBooking;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Views.Connect
{
    public partial class ConnectVehiclePage : ContentPage
    {
        ChargeEstimateRequest chargeEstimateRequest;
        ConnectVehiclePageViewModel connectVehiclePageViewModel;
        public ConnectVehiclePage()
        {
            connectVehiclePageViewModel = new ConnectVehiclePageViewModel();
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            BindingContext = connectVehiclePageViewModel;
        }
        public ConnectVehiclePage(ChargeEstimateRequest _chargeEstimateRequest)
        {
            chargeEstimateRequest = _chargeEstimateRequest;
            connectVehiclePageViewModel = new ConnectVehiclePageViewModel(chargeEstimateRequest);
            Shell.SetTabBarIsVisible(this, false);
            InitializeComponent();
            BindingContext = connectVehiclePageViewModel;
        }
        void ConfirmButtonClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new StartYourChargePage());
            //Shell.Current.GoToAsync("//MakeBooking/CheckAvailability/ConfirmBooking/BookingConfirmed/ConnectVehicle/StartYourCharge");
        }
        async void NeedHelpClicked(System.Object sender, System.EventArgs e)
        {
            string phoneNumber = "1234567890"; // Replace with the desired phone number
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (PermissionException)
            {
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Error", "Phone dialing is not supported on this Phone.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Phone dialing is not opening due to " + ex.ToString(), "OK");
            }
        }
    }
}

