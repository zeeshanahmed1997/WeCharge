using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using WeCharge.Models.General;
using WeCharge.ViewModels;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{
    public partial class FilterModalPopup : PopupPage, INotifyPropertyChanged
    {
        #region bindalble property
        private int modelSelectIndex = -1;
        public int ModelSelectIndex
        {
            get { return modelSelectIndex; }
            set
            {
                if (modelSelectIndex != value)
                {
                    modelSelectIndex = value;
                    OnPropertyChanged();
                }
                ModelColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }

        private int brandSelectedIndex = -1;
        public int BrandSelectedIndex
        {
            get { return brandSelectedIndex; }
            set
            {
                if (brandSelectedIndex != value)
                {
                    brandSelectedIndex = value;
                    OnPropertyChanged();
                }
                BrandColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
           
            
        }

       
        private int chargerTypeSelectedIndex = -1;
        public int ChargerTypeSelectedIndex
        {
            get { return chargerTypeSelectedIndex; }
            set
            {
                if (chargerTypeSelectedIndex != value)
                {
                    chargerTypeSelectedIndex = value;
                    OnPropertyChanged();
                }
                ChargerTypeColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }

        private Color brandColor = Color.LightGray;
        public Color BrandColor
        {
            get { return brandColor; }
            set
            {
                if (brandColor != value)
                {
                    brandColor = value;
                    OnPropertyChanged();
                }
            }
        }
        private Color modelColor = Color.LightGray;
        public Color ModelColor
        {
            get { return modelColor; }
            set
            {
                if (modelColor != value)
                {
                    modelColor = value;
                    OnPropertyChanged();
                }
            }
        }
       
        private Color chargerTypeColor = Color.LightGray;
        public Color ChargerTypeColor
        {
            get { return chargerTypeColor; }
            set
            {
                if (chargerTypeColor != value)
                {
                    chargerTypeColor = value;
                    OnPropertyChanged();
                }
            }
        }

       
        //bindable property for vehical brand
        private ObservableCollection<string> _vehicleBrand;
        public ObservableCollection<string> VehicleBrandSource
        {
            get { return _vehicleBrand; }
            set
            {
                if (_vehicleBrand != value)
                {
                    _vehicleBrand = value;
                    OnPropertyChanged();
                }
            }
        }

        //bindable property for vehical model
        private ObservableCollection<string> _vehicleModel;
        public ObservableCollection<string> VehicleModelSource
        {
            get { return _vehicleModel; }
            set
            {
                if (_vehicleModel != value)
                {
                    _vehicleModel = value;
                    OnPropertyChanged();
                }
            }
        }

        //bindable property for charger type
        private ObservableCollection<string> _chargerType;
        public ObservableCollection<string> ChargerTypeSource
        {
            get { return _chargerType; }
            set
            {
                if (_chargerType != value)
                {
                    _chargerType = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        string pageName;
        
        public FilterModalPopup()
        {
            InitializeComponent();
            Task.Factory.StartNew(async () =>
            {
                ReferenceDataResponse AuthReferenceData = await App.weChargeService.authentication.AuthenticationReferenceData();
                var brand = AuthReferenceData.VehicleBrands.Select(brandname => brandname.Name).ToList();
                var model = AuthReferenceData.VehicleModels.Select(modelname => modelname.Name).ToList();
                var chargeType = AuthReferenceData.ChargerTypes.Select(chargertype => chargertype.Name).ToList();
                if (AuthReferenceData != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        VehicleBrandSource = new ObservableCollection<string>(brand);
                        VehicleModelSource = new ObservableCollection<string>(model);
                        ChargerTypeSource = new ObservableCollection<string>(chargeType);

                    });
                }

            });
            BindingContext = this;
        }
        public FilterModalPopup(String _pageName)
        {
            pageName = _pageName;
            InitializeComponent();
            Task.Factory.StartNew(async () =>
            {
                ReferenceDataResponse AuthReferenceData = await App.weChargeService.authentication.AuthenticationReferenceData();
                var brand = AuthReferenceData.VehicleBrands.Select(brandname => brandname.Name).ToList();
                var model = AuthReferenceData.VehicleModels.Select(modelname => modelname.Name).ToList();
                var chargeType = AuthReferenceData.ChargerTypes.Select(chargertype => chargertype.Name).ToList();
                if (AuthReferenceData != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        VehicleBrandSource = new ObservableCollection<string>(brand);
                        VehicleModelSource = new ObservableCollection<string>(model);
                        ChargerTypeSource = new ObservableCollection<string>(chargeType);

                    });
                }

            });
            BindingContext = this;

        }

        private void ExitIconTapped(object sender, EventArgs e)
        {
            // Close the popup when the button is clicked
            // Close the popup when the button is clicked
            PopupNavigation.Instance.PopAsync();
        }
    public string SelectedFilter { get; private set; }

    private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // if radio button is checked
        {
            SelectedFilter = (string)((RadioButton)sender).Content;
        }
    }
    //private void ApplyButtonClicked(object sender, EventArgs e)
    //{
    //    // Close the popup when the button is clicked
    //    _ = PopupNavigation.Instance.PopAsync();

    //    var fullPageName = this.pageName;

    //    // Assuming all your pages are in the same assembly as this method
    //    var assembly = GetType().GetTypeInfo().Assembly;

    //    // Try to get the type by name
    //    var pageType = assembly.GetType(fullPageName);

    //    if (pageType == null)
    //    {
    //        // Handle the case when the page type was not found
    //        throw new InvalidOperationException($"Type {fullPageName} not found.");
    //    }

    //    // Look for a constructor that accepts a single string parameter
    //    var constructor = pageType.GetConstructor(new[] { typeof(string) });
    //    if (constructor == null)
    //    {
    //        throw new InvalidOperationException($"Constructor with a single string parameter not found for type {fullPageName}.");
    //    }

    //    // Create an instance of the page using the found constructor and pass the SelectedFilter value
    //    var pageInstance = constructor.Invoke(new object[] { SelectedFilter });

    //    // Push the page to navigation
    //    Navigation.PushAsync((Page)pageInstance);
    //}
    public Action<string> ApplyDone;
    public class DataSentEventArgs : EventArgs
    {
        public string Data { get; set; }
    }

    private void ApplyButtonClicked(object sender, EventArgs e)
    {
        DataSentEventArgs args = new DataSentEventArgs();
        args.Data = SelectedFilter;
        ApplyDone?.Invoke(SelectedFilter);
        // Close the popup 
        PopupNavigation.Instance.PopAsync();
    }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            bool isDarkMode = Application.Current.RequestedTheme == OSAppTheme.Dark;
            if (isDarkMode)
            {
                DistanceFromLocation.TextColor = Color.Black;
                LocationName.TextColor = Color.Black;
            }
            else
            {
                DistanceFromLocation.TextColor = Color.Black;
                LocationName.TextColor = Color.Black;
            }
        }

        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }


        #region notify property change
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}