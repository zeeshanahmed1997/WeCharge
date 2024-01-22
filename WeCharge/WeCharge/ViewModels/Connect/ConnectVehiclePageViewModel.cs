using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class ConnectVehiclePageViewModel : INotifyPropertyChanged
    {
        ChargeEstimateRequest chargeEstimateRequest;
        public ICommand ShowMenuCommand { get; private set; }
        public ICommand ConfirmButtonClicked { get; private set; }
        public ConnectVehiclePageViewModel()
        {
            ConfirmButtonClicked = new Command(NavigateToStartCharge);
            ShowMenuCommand = new Command(ShowMenu);
            SetDefaultValues();
        }
        public ConnectVehiclePageViewModel(ChargeEstimateRequest _chargeEstimateRequest)
        {

            chargeEstimateRequest = _chargeEstimateRequest;

            ConfirmButtonClicked = new Command(NavigateToStartCharge);
            ShowMenuCommand = new Command(ShowMenu);
            SetDefaultValues();
        }
        public void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        private void SetDefaultValues()
        {
            // Sample values assigned to the properties
            ArrivalText = $"You’ve arrived at your {chargeEstimateRequest.SlotStartTime} slot charge at {chargeEstimateRequest.LocaionName}";
            RateText = chargeEstimateRequest.CostRateDisplay;
        }
        private string arrivalText;
        public string ArrivalText
        {
            get => arrivalText;
            set => SetProperty(ref arrivalText, value);
        }

        private string rateText;
        public string RateText
        {
            get => rateText;
            set => SetProperty(ref rateText, value);
        }

        private string connectVehicleInfoText;
        public string ConnectVehicleInfoText
        {
            get => connectVehicleInfoText;
            set => SetProperty(ref connectVehicleInfoText, value);
        }

        private string connectionIssueText;
        public string ConnectionIssueText
        {
            get => connectionIssueText;
            set => SetProperty(ref connectionIssueText, value);
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
        public void NavigateToStartCharge()
        {
            Application.Current.MainPage.Navigation.PushAsync(new StartYourChargePage(chargeEstimateRequest));
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

}
