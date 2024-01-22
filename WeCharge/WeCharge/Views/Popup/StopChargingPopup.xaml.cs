using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Models.Charge;
using WeCharge.ViewModels;
using WeCharge.Views.Charge;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class StopChargingPopup : PopupPage
	{
        public event Action OnStopChargingRequested;

        public ChargingStoppedResponse ChargingResponse { get; private set; }

        public StopChargingPopup(ChargingStoppedResponse response)
        {
            InitializeComponent();
            ChargingResponse = response;
        }
        void ContinueCharging_Clicked(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
        void StopCharging_Clicked(System.Object sender, System.EventArgs e)
        {
            OnStopChargingRequested?.Invoke();  // Raise the event
            PopupNavigation.Instance.PopAsync();  // Close the popup
            Application.Current.MainPage.Navigation.PushAsync(new ChargedPage());

        }
    }
}

