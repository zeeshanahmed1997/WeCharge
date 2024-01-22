using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Newtonsoft.Json;

using Rg.Plugins.Popup.Services;

using WeCharge.Model.MakeBooking;
using WeCharge.Models.Charge;
using WeCharge.Models.ChargingStatus;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Charge;
using WeCharge.Views.Connect;
using WeCharge.Views.MakeBooking;
using WeCharge.Views.Popup;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class ChargingPageViewModel : BaseViewModel
    {
        public ICommand ShowMenuCommand { get; private set; }
        ChargingDetailsResponse chargingDetailsResponse;
        public bool isTimerRunning = false;
        ChargeEstimateRequest requestChargeEstimate;
        public ICommand StopButtonClicked { get; private set; }
        // Bindable properties for the hardcoded fields
        private string chargedSoFar;
        public string ChargedSoFar
        {
            get => chargedSoFar;
            set => SetProperty(ref chargedSoFar, value);
        }
        private bool stopChargingEnabled = false;
        public bool StopChargingEnabled
        {
            get => stopChargingEnabled;
            set => SetProperty(ref stopChargingEnabled, value);
        }
        private string chargedSoFarTime;
        public string ChargedSoFarTime
        {
            get => chargedSoFarTime;
            set => SetProperty(ref chargedSoFarTime, value);
        }

        private string chargedSoFarUnit;
        public string ChargedSoFarUnit
        {
            get => chargedSoFarUnit;
            set => SetProperty(ref chargedSoFarUnit, value);
        }

        private string chargedSoFarAmount;
        public string ChargedSoFarAmount
        {
            get => chargedSoFarAmount;
            set => SetProperty(ref chargedSoFarAmount, value);
        }


        private string chargedRemainingTime;
        public string ChargedRemainingTime
        {
            get => chargedRemainingTime;
            set => SetProperty(ref chargedRemainingTime, value);
        }

        private string chargedRemainingUnit;
        public string ChargedRemainingUnit
        {
            get => chargedRemainingUnit;
            set => SetProperty(ref chargedRemainingUnit, value);
        }

        private string chargedRemainingAmount;
        public string ChargedRemainingAmount
        {
            get => chargedRemainingAmount;
            set => SetProperty(ref chargedRemainingAmount, value);
        }

        private string vehicleCharge;
        public string VehicleCharge
        {
            get => vehicleCharge;
            set => SetProperty(ref vehicleCharge, value);
        }

        private string vehicleChargePercentage;
        public string VehicleChargePercentage
        {
            get => vehicleChargePercentage;
            set => SetProperty(ref vehicleChargePercentage, value);
        }

        private string chargeSpeed;
        public string ChargeSpeed
        {
            get => chargeSpeed;
            set => SetProperty(ref chargeSpeed, value);
        }

        private string chargingStatus;
        public string ChargingStatus
        {
            get => chargingStatus;
            set => SetProperty(ref chargingStatus, value);
        }
        private string chargeSpeedType;
        public string ChargeSpeedType
        {
            get => chargeSpeedType;
            set => SetProperty(ref chargeSpeedType, value);
        }

        private string chargeSpeedAmount;
        public string ChargeSpeedAmount
        {
            get => chargeSpeedAmount;
            set => SetProperty(ref chargeSpeedAmount, value);
        }

        private double chargingValue;
        public double ChargingValue
        {
            get => chargingValue;
            set => SetProperty(ref chargingValue, value);
        }

        private double progressValue;
        public double ProgressValue
        {
            get => progressValue;
            set => SetProperty(ref progressValue, value);
        }
        //starting region of default text showing
        private string arrivalText;
        public string ArrivalText
        {
            get => arrivalText;
            set => SetProperty(ref arrivalText, value);
        }

        private string _chargeRate;
        public string ChargeRate
        {
            get => _chargeRate;
            set => SetProperty(ref _chargeRate, value);
        }

        private string _chargeCostPerHour;
        public string ChargeCost
        {
            get => _chargeCostPerHour;
            set => SetProperty(ref _chargeCostPerHour, value);
        }



        //end region of setting default text

        // Constructor with sample values
        public ChargingPageViewModel()
        {
            ShowMenuCommand = new Command(ShowMenu);
            StopButtonClicked = new Command(async () => await StopCharging());
            SetDefaultValues();
            App.booking = App.book;
            Helpers.Utils.StoreObjectInPreferences("booking", App.booking);
        }
        public void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        public ChargingPageViewModel(ChargeEstimateRequest _requestChargeEstimate)
        {
            ShowMenuCommand = new Command(ShowMenu);
            requestChargeEstimate = _requestChargeEstimate;
            ArrivalText = $"You’ve arrived at your {requestChargeEstimate.SlotStartTime} slot charge at {requestChargeEstimate.LocaionName}";
            StopButtonClicked = new Command(async () => await StopCharging());


            //StartChargingProgressTimer();
            StopChargingEnabled = true;
            // SetDefaultValues();
        }

        public void StartChargingProgressTimer()
        {
            Task.Factory.StartNew(() =>
            {
                GetChargingProgress();
                if (requestChargeEstimate != null && !isTimerRunning)
                {
                    isTimerRunning = true;
                    Device.StartTimer(TimeSpan.FromSeconds(30), () =>
                    {
                        GetChargingProgress();
                        return isTimerRunning; // Return true to continue the timer, false to stop it.
                    });
                }
            });
        }

        public void GetChargingProgress()
        {
            if (requestChargeEstimate != null)
            {
                ChargeEstimateRequest chargeEstimateRequest = new ChargeEstimateRequest();
                chargeEstimateRequest.BookingID = requestChargeEstimate.BookingID;
                chargeEstimateRequest.ChargerID = requestChargeEstimate.ChargerID;
                Task.Factory.StartNew(async () =>
                {
                    if (chargeEstimateRequest != null)
                    {
                        chargingDetailsResponse = await App.weChargeService.chargingService.GetChargingProgressDetails(chargeEstimateRequest);

                        //got null reference exception ,because of nullresponse from API
                        
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                if (chargingDetailsResponse != null && chargingDetailsResponse?._Status == "Success")
                                {
                                    if (chargingDetailsResponse!=null && chargingDetailsResponse?.ChargingStatus.ToString() == "Charging")
                                    {
                                        ChargingStatus = chargingDetailsResponse.ChargingStatus.ToString();
                                        ChargedSoFar = chargingDetailsResponse.ChargePercentageDisplay;
                                        ChargedSoFarTime = chargingDetailsResponse.ChargeSoFarDurationDisplay;
                                        ChargedSoFarUnit = chargingDetailsResponse.ChargeSoFarKilowattsDisplay;
                                        ChargedSoFarAmount = chargingDetailsResponse.ChargeSoFarAmountDisplay;
                                        ChargedRemainingTime = chargingDetailsResponse.RemainingToLimitDurationDisplay;
                                        ChargedRemainingUnit = chargingDetailsResponse.RemainingToLimitKilowattsDisplay;
                                        ChargedRemainingAmount = chargingDetailsResponse.RemainingToLimitAmountDisplay;

                                        VehicleChargePercentage = chargingDetailsResponse.ChargePercentageDisplay;

                                        ChargeRate = $"{(int)(((double)chargingDetailsResponse.CurrentChargeRateKiloWattsHours / chargingDetailsResponse.MaximimChargeRateKiloWattsHours) * 100)}%";
                                        ChargeCost = $"{chargingDetailsResponse.MaximumChargeCostForDisplay}limit";
                                        ChargeSpeedType = chargingDetailsResponse.ChargerTypeName;
                                        ChargeSpeedAmount = chargingDetailsResponse.ChargeSpeedDiplay;
                                        ChargingValue = ((double)chargingDetailsResponse.CurrentChargeRateKiloWattsHours / chargingDetailsResponse.MaximimChargeRateKiloWattsHours);
                                    }
                                }
                                else
                                {
                                }
                            });
                        

                    }
                });
            }
        }
        private void SetDefaultValues()
        {
            ArrivalText = $"You’ve arrived at your {requestChargeEstimate.SlotStartTime} slot charge at {requestChargeEstimate.LocaionName}";
            ChargedSoFar = ChargedSoFar;
            ChargedSoFarTime = ChargedSoFarTime;
            ChargedSoFarUnit = ChargedSoFarUnit;
            ChargedSoFarAmount = ChargedSoFarAmount;
            ChargedRemainingTime = ChargedRemainingTime;
            ChargedRemainingUnit = ChargedRemainingUnit;
            ChargedRemainingAmount = ChargedRemainingAmount;

            VehicleChargePercentage = VehicleChargePercentage;

            ChargeSpeedType = ChargeSpeedType;
            ChargeSpeedAmount = ChargeSpeedAmount;
            ChargingValue = ChargingValue;


            //ProgressValue = 90;
        }
        public async Task<ChargingStoppedResponse> StopCharging()
        {
            if (requestChargeEstimate != null)
            {
                ChargeEstimateRequest chargeEstimateRequest = new ChargeEstimateRequest
                {
                    BookingID = requestChargeEstimate.BookingID,
                    ChargerID = requestChargeEstimate.ChargerID
                };

                IsBusy = true;
                ChargingStoppedResponse chargingStoppedResponse = null;
                StopChargingRequest stopChargingRequest = new StopChargingRequest();
                stopChargingRequest.BookingID = chargeEstimateRequest.BookingID;
                stopChargingRequest.ChargerID = chargeEstimateRequest.ChargerID;
                try
                {
                    isTimerRunning = false;
                    chargingStoppedResponse = await App.weChargeService.chargingService.StopCharging(stopChargingRequest);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (chargingStoppedResponse!=null && chargingStoppedResponse?._Status == "Success")
                        {
                            App.booking = null;
                            Helpers.Utils.StoreObjectInPreferences("booking", "");
                            Helpers.Utils.StoreObjectInPreferences("chargeEstimateRequest", "");
                            // Create an instance of ChargedPage
                            var chargedPage = new ChargedPage(chargeEstimateRequest);

                            // Clear the entire navigation stack
                            var navigationStack = Application.Current.MainPage.Navigation.NavigationStack.ToList();
                            foreach (var page in navigationStack)
                            {
                                if (page != null && page != chargedPage)
                                {
                                    Application.Current.MainPage.Navigation.RemovePage(page);
                                }
                            }

                            // Push the ChargedPage onto the navigation stack
                            Application.Current.MainPage.Navigation.PushAsync(chargedPage);


                            // Showing the popup after navigation.
                            //var popupPage = new StopChargingPopup(chargingStoppedResponse);
                            //PopupNavigation.Instance.PushAsync(popupPage);

                        }
                    });
                }
                catch
                {
                    // Handle any errors
                }
                finally
                {
                    IsBusy = false;
                }

                return chargingStoppedResponse;
            }

            return null;
        }

    }
}
