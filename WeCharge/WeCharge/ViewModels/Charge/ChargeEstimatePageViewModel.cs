using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeCharge.Models.Charge;
using WeCharge.Models.RequestModels;
using Xamarin.Forms;
using WeCharge.Models.Booking;
using WeCharge;
using System.Windows.Input;
using WeCharge.Views.Charge;
using System;
using System.Linq;

public class ChargeEstimatePageViewModel : INotifyPropertyChanged
{
    StartChargingResponse startChargeResponse;
    ChargeEstimateResponse estimateResponse;
    public ICommand ButtonClickedCommand { get; }
    public ICommand StartChargingButtonClicked { get; private set; }
    ChargeEstimateRequest chargeEstimateRequest;
    StartChargingRequest startChargingRequest;
    public ChargeEstimatePageViewModel()
    {
        StartChargingButtonClicked = new Command(StartCharging);
        ButtonClickedCommand = new Command<string>(OnButtonClicked);
        //SetDefaultValues();
    }
    public ChargeEstimatePageViewModel(ChargeEstimateRequest _chargeEstimateRequest)
    {
        StartChargingButtonClicked = new Command(StartCharging);
        ButtonClickedCommand = new Command<string>(OnButtonClicked);
        chargeEstimateRequest = _chargeEstimateRequest;
        RequestChargeEstimate();
    }
    private void OnButtonClicked(string buttonText)
    {
        if (ButtonBackgroundColor20 == Color.LightGray && buttonText == "$20")
        {
            // If the current color is gray and the clicked button is already gray, set it to white
            SetButtonBackgroundColor(buttonText, Color.White);

        }
        else if (ButtonBackgroundColor30 == Color.LightGray && buttonText == "$30")
        {
            SetButtonBackgroundColor(buttonText, Color.White);
        }
        else if (ButtonBackgroundColor40 == Color.LightGray && buttonText == "$40")
        {
            SetButtonBackgroundColor(buttonText, Color.White);
        }
        else
        {
            SetButtonBackgroundColor(buttonText, Color.LightGray);
            // Remove the dollar sign from the start if it exists
            if (buttonText.StartsWith("$"))
            {
                buttonText = buttonText.Substring(1);
            }

            // Try to convert the string to an integer
            if (int.TryParse(buttonText, out int value))
            {
                SelectedCost = value;  // Assign the parsed value to SelectedCost
                Console.WriteLine(value); // If conversion is successful, print the integer value
            }
            else
            {
                Console.WriteLine("The button text without a dollar sign is not a valid integer.");
            }
        }





    }
    public void RequestChargeEstimate()
    {
        Task.Factory.StartNew(async () =>
        {
            estimateResponse = await App.weChargeService.chargingService.RequestChargeEstimate(this.chargeEstimateRequest);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (estimateResponse?._Status == "Success")
                {
                    EnergyRequired = estimateResponse.EnergyRequiredDisplay;
                    TotalCost = estimateResponse.TotalCostDisplay;
                    Time = estimateResponse.TimeDisplay;
                    OtherAmount = "";
                    ChargingSummary = $"You’ve arrived at your {this.chargeEstimateRequest.SlotStartTime} slot charge at {chargeEstimateRequest.LocaionName}";
                }
            });
        });
    }

    private void SetButtonBackgroundColor(string buttonName, Color color)
    {
        
            
       
        if (color == Color.White)
        {
            SelectedCost = 0;
            OtherAmountEnable = true;
        }
        else
        {
            OtherAmountEnable = false;
            OtherAmount = string.Empty;
        }
        ButtonBackgroundColor20 = Color.White;
        ButtonBackgroundColor30 = Color.White;
        ButtonBackgroundColor40 = Color.White;
        switch (buttonName)
        {
            case "$20":
                ButtonBackgroundColor20 = color;

                break;
            case "$30":
                ButtonBackgroundColor30 = color;
                break;
            case "$40":
                ButtonBackgroundColor40 = color;
                break;
            default:
                // Handle unrecognized button names if needed
                break;
        }

       // bool anyButtonGray =
       //ButtonBackgroundColor20 == Color.Gray ||
       //ButtonBackgroundColor30 == Color.Gray ||
       //ButtonBackgroundColor40 == Color.Gray;

       // OtherAmountEnable = !anyButtonGray;

    }


    private int _selectedCost=0;
    public int SelectedCost
    {
        get { return _selectedCost; }
        set
        {
            if (_selectedCost != value)
            {
                _selectedCost = value;
                OnPropertyChanged();
            }
        }
    }
    private Color _buttonBackgroungColor20 = Color.White;
    public Color ButtonBackgroundColor20
    {
        get { return _buttonBackgroungColor20; }
        set
        {
            if (_buttonBackgroungColor20 != value)
            {
                _buttonBackgroungColor20 = value;
                OnPropertyChanged();
            }
        }
    }
    private Color _buttonBackgroungColor30 = Color.White;
    public Color ButtonBackgroundColor30
    {
        get { return _buttonBackgroungColor30; }
        set
        {
            if (_buttonBackgroungColor30 != value)
            {
                _buttonBackgroungColor30 = value;
                OnPropertyChanged();
            }
        }
    }

    private Color _buttonBackgroungColor40 = Color.White;
    public Color ButtonBackgroundColor40
    {
        get { return _buttonBackgroungColor40; }
        set
        {
            if (_buttonBackgroungColor40 != value)
            {
                _buttonBackgroungColor40 = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _otherAmountEnable=true;
    public bool OtherAmountEnable
    {
        get { return _otherAmountEnable; }
        set
        {
            if (_otherAmountEnable != value)
            {
                _otherAmountEnable = value;
                OnPropertyChanged();
            }
        }
    }
    private string _energyRequired;
    public string EnergyRequired
    {
        get { return _energyRequired; }
        set
        {
            if (_energyRequired != value)
            {
                _energyRequired = value;
                OnPropertyChanged();
            }
        }
    }

    private string _totalCost;
    public string TotalCost
    {
        get { return _totalCost; }
        set
        {
            if (_totalCost != value)
            {
                _totalCost = value;
                OnPropertyChanged();
            }
        }
    }

    private string _time;
    public string Time
    {
        get { return _time; }
        set
        {
            if (_time != value)
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    }

    private string _otherAmount;
    public string OtherAmount
    {
        get { return _otherAmount; }
        set
        {
            if (_otherAmount != value)
            {
                _otherAmount = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }
    }

    public async void StartCharging()
    {
        startChargingRequest = new StartChargingRequest(); // Initialize the object here.

        if (SelectedCost == 0 && String.IsNullOrEmpty(OtherAmount))
        {
            startChargingRequest.BookingID = this.chargeEstimateRequest.BookingID;
            startChargingRequest.ChargerID = this.chargeEstimateRequest.ChargerID;
            startChargingRequest.MaximumChargeCost = -1;
            if (App.book != null)
            {
                App.booking = App.book;
                WeCharge.Helpers.Utils.StoreObjectInPreferences("booking", App.booking);
                WeCharge.Helpers.Utils.StoreObjectInPreferences("chargeEstimateRequest", chargeEstimateRequest);
            }
            startChargeResponse = await App.weChargeService.chargingService.StartCharging(startChargingRequest);
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

                    // Set IsBusy to false to indicate the operation is complete (if applicable)
                    // IsBusy = false;
                });

            }
        }
        else if (SelectedCost != 0 && String.IsNullOrEmpty(OtherAmount))
        {
            startChargingRequest.BookingID = this.chargeEstimateRequest.BookingID;
            startChargingRequest.ChargerID = this.chargeEstimateRequest.ChargerID;
            startChargingRequest.MaximumChargeCost = SelectedCost;
            if (App.book != null)
            {
                App.booking = App.book;
                WeCharge.Helpers.Utils.StoreObjectInPreferences("booking", App.booking);
                WeCharge.Helpers.Utils.StoreObjectInPreferences("chargeEstimateRequest", chargeEstimateRequest);
            }
            startChargeResponse = await App.weChargeService.chargingService.StartCharging(startChargingRequest);
            if (startChargeResponse != null && startChargeResponse?._Status == "Success")
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

                    // Set IsBusy to false to indicate the operation is complete (if applicable)
                    // IsBusy = false;
                });

            }
        }
        else if (OtherAmount != null || OtherAmount != "")
        {
            startChargingRequest.BookingID = this.chargeEstimateRequest.BookingID;
            startChargingRequest.ChargerID = this.chargeEstimateRequest.ChargerID;
            startChargingRequest.MaximumChargeCost = int.Parse(OtherAmount);
            if (App.book != null)
            {
                App.booking = App.book;
                WeCharge.Helpers.Utils.StoreObjectInPreferences("booking", App.booking);
                WeCharge.Helpers.Utils.StoreObjectInPreferences("chargeEstimateRequest", chargeEstimateRequest);
            }
            startChargeResponse = await App.weChargeService.chargingService.StartCharging(startChargingRequest);
            if (startChargeResponse != null && startChargeResponse._Status == "Success")
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

                    // Set IsBusy to false to indicate the operation is complete (if applicable)
                    // IsBusy = false;
                });

            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
