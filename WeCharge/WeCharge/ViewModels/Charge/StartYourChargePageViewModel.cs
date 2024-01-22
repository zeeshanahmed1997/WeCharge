using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using WeCharge.Models.Charge;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class StartYourChargePageViewModel : INotifyPropertyChanged
    {
        StartChargingResponse startChargeResponse;
        StartChargingRequest startChargingRequest;
        ChargeEstimateRequest chargeEstimateRequest;
        public ICommand StartChargeCommand { get; private set; }
        // Bindable properties for the StartYourChargePage
        private string chargingArrivalText;
        public string ChargingArrivalText
        {
            get => chargingArrivalText;
            set => SetProperty(ref chargingArrivalText, value);
        }

        private string rateText;
        public string RateText
        {
            get => rateText;
            set => SetProperty(ref rateText, value);
        }

        private string startChargeInfoText;
        public string StartChargeInfoText
        {
            get => startChargeInfoText;
            set => SetProperty(ref startChargeInfoText, value);
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;
            OnPropertyChanged(propertyName);
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public StartYourChargePageViewModel()
        {
            StartChargeCommand = new Command(StartCharge);
            SetDefaultValues();
        }
        public StartYourChargePageViewModel(ChargeEstimateRequest _chargeEstimateRequest)
        {
            chargeEstimateRequest = _chargeEstimateRequest;
            StartChargeCommand = new Command(StartCharge);
            SetDefaultValues();
        }
        public async void StartCharge()
        {
            startChargingRequest = new StartChargingRequest();
            startChargingRequest.BookingID = chargeEstimateRequest.BookingID;
            startChargingRequest.ChargerID = chargeEstimateRequest.ChargerID;
            startChargingRequest.MaximumChargeCost = -1;


            //App.Current.MainPage.Navigation.PushAsync(new Views.Charge.ChargingPage(chargeEstimateRequest));

            startChargeResponse = await App.weChargeService.chargingService.StartCharging(startChargingRequest);
            App.chargeEstimateRequest = chargeEstimateRequest;
            Helpers.Utils.StoreObjectInPreferences("chargeEstimateRequest", App.chargeEstimateRequest);
            if(App.book!=null)
            {
                App.booking = App.book;
                Helpers.Utils.StoreObjectInPreferences("booking", App.booking);
            }
            if (startChargeResponse!=null && startChargeResponse?._Status == "Success")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // Create an instance of ChargingPage
                    var chargingPage = new ChargingPage(chargeEstimateRequest);

                    // Get the current navigation stack
                    var navigationStack = Application.Current.MainPage.Navigation.NavigationStack.ToList();

                    // Iterate through the stack and remove all pages except for the new ChargingPage
                    foreach (var page in navigationStack)
                    {
                        if (page != null && page != chargingPage)
                        {
                            Application.Current.MainPage.Navigation.RemovePage(page);
                        }
                    }

                    // Push the ChargingPage onto the now-cleared navigation stack
                    await Application.Current.MainPage.Navigation.PushAsync(chargingPage);
                });

            }

        }
        private void SetDefaultValues()
        {
            ChargingArrivalText = $"You’ve arrived at your {chargeEstimateRequest.SlotStartTime} slot charge at {chargeEstimateRequest.LocaionName}";
            RateText = chargeEstimateRequest.CostRateDisplay;
            StartChargeInfoText = $"Please park in Bay {chargeEstimateRequest.BayNumber} to start charge";
        }
    }
}
