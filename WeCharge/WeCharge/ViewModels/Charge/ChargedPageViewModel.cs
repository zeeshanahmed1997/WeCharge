using Xamarin.Forms;
using System.ComponentModel;
using WeCharge.Model;
using System.Windows.Input;
using WeCharge.Models.RequestModels;
using System.Threading.Tasks;
using WeCharge.Models.Booking;
using WeCharge.Models.Charge;
using System;

namespace WeCharge.ViewModels
{
    public class ChargedPageViewModel : INotifyPropertyChanged
    {
        ChargingSummaryResponse chargingSummaryResponse;
        ChargeEstimateRequest chargeEstimateRequest;
        ChargeSummaryRequest chargeSummaryRequest;
        public ICommand ShowMenuCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties for the fields in the XAML
        public ChargedPageViewModel()
        {
            ShowMenuCommand = new Command(ShowMenu);
            SetDefaultValues();
        }
        public ChargedPageViewModel(ChargeEstimateRequest _chargeEstimateRequest)
        {
            chargeEstimateRequest = _chargeEstimateRequest;
            ShowMenuCommand = new Command(ShowMenu);
            chargeSummaryRequest = new ChargeSummaryRequest();
            SetDefaultValues();
        }
        public void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        private async void SetDefaultValues()
        {
            try
            {
                if (chargeSummaryRequest != null)
                {
                    chargeSummaryRequest.BookingID = chargeEstimateRequest?.BookingID;
                    chargeSummaryRequest.ChargerID = chargeEstimateRequest?.ChargerID;

                    // Assuming chargeEstimateRequest is properly initialized before this method is called
                    chargingSummaryResponse = await Task.Run(() => App.weChargeService.chargingService.GetChargingSummary(chargeSummaryRequest));

                    if (chargingSummaryResponse!=null &&  chargingSummaryResponse?._Status == "Success")
                    {
                        Device.BeginInvokeOnMainThread(() => {
                            StartTime = chargingSummaryResponse.ChargeStartTimeDisplay;
                            EndTime = chargingSummaryResponse.ChargeEndTimeDisplay;
                            ChargingSummary = "Charging Summary";
                            UnitsConsumedLabel = "Units consumed";
                            UnitsConsumedValue = $"{chargingSummaryResponse.UnitsConsumedKilowattsDisplay}";
                            DateLabel = "Date";
                            DateValue = chargingSummaryResponse.ChargeDateDisplay?.ToString() ?? string.Empty;
                            DurationLabel = "Duration";
                            DurationValue = chargingSummaryResponse.ChargeDurationDisplay?.ToString() ?? string.Empty;
                            ChargingFeeLabel = "Charging fee";
                            //ChargingFeeValue = chargingSummaryResponse.ChargeFeeSubTotalAmountDisplay;
                            ServiceChargesLabel = "Service charges";
                            ServiceChargesValue = chargingSummaryResponse.ChargeFeeServicesChargesAmountDisplay;
                            SubtotalLabel = "Subtotal";
                            SubtotalValue = chargingSummaryResponse.ChargeFeeSubTotalAmountDisplay;
                            TaxLabel = "Tax";
                            TaxValue = chargingSummaryResponse.ChargeFeeTaxAmountDisplay;
                            GrandTotalLabel = "Grand total";
                            GrandTotalValue = chargingSummaryResponse.ChargeFeeGrandTotalAmountDisplay;
                        });
                        
                    }
                }
                else
                {
                    Console.WriteLine("chargeSummaryRequest is null");
                }
                GoToHomeButtonText = "Go to Home";
                MakeNewBookingLabel = "Make New Booking";
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred in SetDefaultValues: {ex.Message}");
            }
        }

        private string _startTime;// = "02:12 pm";
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        private string _endTime;// = "02:12 pm";
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }
        private string _chargingSummary;
        public string ChargingSummary
        {
            get { return _chargingSummary; }
            set
            {
                if (_chargingSummary != value)
                {
                    _chargingSummary = value;
                    OnPropertyChanged(nameof(ChargingSummary));
                }
            }
        }

        private string _unitsConsumedLabel;
        public string UnitsConsumedLabel
        {
            get { return _unitsConsumedLabel; }
            set
            {
                if (_unitsConsumedLabel != value)
                {
                    _unitsConsumedLabel = value;
                    OnPropertyChanged(nameof(UnitsConsumedLabel));
                }
            }
        }

        private string _unitsConsumedValue;
        public string UnitsConsumedValue
        {
            get { return _unitsConsumedValue; }
            set
            {
                if (_unitsConsumedValue != value)
                {
                    _unitsConsumedValue = value;
                    OnPropertyChanged(nameof(UnitsConsumedValue));
                }
            }
        }

        private string _dateLabel;
        public string DateLabel
        {
            get { return _dateLabel; }
            set
            {
                if (_dateLabel != value)
                {
                    _dateLabel = value;
                    OnPropertyChanged(nameof(DateLabel));
                }
            }
        }

        private string _dateValue;
        public string DateValue
        {
            get { return _dateValue; }
            set
            {
                if (_dateValue != value)
                {
                    _dateValue = value;
                    OnPropertyChanged(nameof(DateValue));
                }
            }
        }

        private string _durationLabel;
        public string DurationLabel
        {
            get { return _durationLabel; }
            set
            {
                if (_durationLabel != value)
                {
                    _durationLabel = value;
                    OnPropertyChanged(nameof(DurationLabel));
                }
            }
        }

        private string _durationValue;
        public string DurationValue
        {
            get { return _durationValue; }
            set
            {
                if (_durationValue != value)
                {
                    _durationValue = value;
                    OnPropertyChanged(nameof(DurationValue));
                }
            }
        }

        private string _chargingFeeLabel;
        public string ChargingFeeLabel
        {
            get { return _chargingFeeLabel; }
            set
            {
                if (_chargingFeeLabel != value)
                {
                    _chargingFeeLabel = value;
                    OnPropertyChanged(nameof(ChargingFeeLabel));
                }
            }
        }

        private string _chargingFeeValue;
        public string ChargingFeeValue
        {
            get { return _chargingFeeValue; }
            set
            {
                if (_chargingFeeValue != value)
                {
                    _chargingFeeValue = value;
                    OnPropertyChanged(nameof(ChargingFeeValue));
                }
            }
        }

        private string _serviceChargesLabel;
        public string ServiceChargesLabel
        {
            get { return _serviceChargesLabel; }
            set
            {
                if (_serviceChargesLabel != value)
                {
                    _serviceChargesLabel = value;
                    OnPropertyChanged(nameof(ServiceChargesLabel));
                }
            }
        }

        private string _serviceChargesValue;
        public string ServiceChargesValue
        {
            get { return _serviceChargesValue; }
            set
            {
                if (_serviceChargesValue != value)
                {
                    _serviceChargesValue = value;
                    OnPropertyChanged(nameof(ServiceChargesValue));
                }
            }
        }

        private string _subtotalLabel;
        public string SubtotalLabel
        {
            get { return _subtotalLabel; }
            set
            {
                if (_subtotalLabel != value)
                {
                    _subtotalLabel = value;
                    OnPropertyChanged(nameof(SubtotalLabel));
                }
            }
        }

        private string _subtotalValue;
        public string SubtotalValue
        {
            get { return _subtotalValue; }
            set
            {
                if (_subtotalValue != value)
                {
                    _subtotalValue = value;
                    OnPropertyChanged(nameof(SubtotalValue));
                }
            }
        }

        private string _taxLabel;
        public string TaxLabel
        {
            get { return _taxLabel; }
            set
            {
                if (_taxLabel != value)
                {
                    _taxLabel = value;
                    OnPropertyChanged(nameof(TaxLabel));
                }
            }
        }

        private string _taxValue;
        public string TaxValue
        {
            get { return _taxValue; }
            set
            {
                if (_taxValue != value)
                {
                    _taxValue = value;
                    OnPropertyChanged(nameof(TaxValue));
                }
            }
        }

        private string _grandTotalLabel;
        public string GrandTotalLabel
        {
            get { return _grandTotalLabel; }
            set
            {
                if (_grandTotalLabel != value)
                {
                    _grandTotalLabel = value;
                    OnPropertyChanged(nameof(GrandTotalLabel));
                }
            }
        }

        private string _grandTotalValue;
        public string GrandTotalValue
        {
            get { return _grandTotalValue; }
            set
            {
                if (_grandTotalValue != value)
                {
                    _grandTotalValue = value;
                    OnPropertyChanged(nameof(GrandTotalValue));
                }
            }
        }

        private string _goToHomeButtonText;
        public string GoToHomeButtonText
        {
            get { return _goToHomeButtonText; }
            set
            {
                if (_goToHomeButtonText != value)
                {
                    _goToHomeButtonText = value;
                    OnPropertyChanged(nameof(GoToHomeButtonText));
                }
            }
        }

        private string _makeNewBookingLabel;
        public string MakeNewBookingLabel
        {
            get { return _makeNewBookingLabel; }
            set
            {
                if (_makeNewBookingLabel != value)
                {
                    _makeNewBookingLabel = value;
                    OnPropertyChanged(nameof(MakeNewBookingLabel));
                }
            }
        }

        // Helper method to raise the PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
