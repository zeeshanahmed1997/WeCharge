using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCharge.Models.Accounts;
using WeCharge.Models.Charge;
using WeCharge.Models.General;
using WeCharge.Models.VehicleDetails;
using WeCharge.Views.Accounts;
using WeCharge.Views.Popup;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class UpdateProfileViewModel : BaseViewModel
    {
       // private const string EmailPattern = @"^[\w.-]+@([\w-]+\.)+[\w-]{2,4}$";

        public ICommand SubmitUpdateCommand { get; private set; }
      

        #region Bindable PRoperties


        private int modelSelectIndex = -1;
        public int ModelSelectIndex
        {
            get => modelSelectIndex;
            set
            {
                SetProperty(ref modelSelectIndex, value);
                ModelColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }

        private int brandSelectedIndex = -1;
        public int BrandSelectedIndex
        {
            get => brandSelectedIndex;
            set
            {
                SetProperty(ref brandSelectedIndex, value);
                BrandColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }

        private int licensePlateSelectedIndex = -1;
        public int LicensePlateSelectedIndex
        {
            get => licensePlateSelectedIndex;
            set
            {
                SetProperty(ref licensePlateSelectedIndex, value);
                LicensePlateColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }
        private int chargerTypeSelectedIndex = -1;
        public int ChargerTypeSelectedIndex
        {
            get => chargerTypeSelectedIndex;
            set
            {
                SetProperty(ref chargerTypeSelectedIndex, value);
                ChargerTypeColor = value == -1 ? Color.LightGray : Color.LightGray;
            }
        }

        private Color brandColor = Color.LightGray;
        public Color BrandColor
        {
            get => brandColor;
            set => SetProperty(ref brandColor, value);
        }
        private Color modelColor = Color.LightGray;
        public Color ModelColor
        {
            get => modelColor;
            set => SetProperty(ref modelColor, value);
        }
        private Color licensePlateColor = Color.LightGray;
        public Color LicensePlateColor
        {
            get => licensePlateColor;
            set => SetProperty(ref licensePlateColor, value);
        }
        private Color chargerTypeColor = Color.LightGray;
        public Color ChargerTypeColor
        {
            get => chargerTypeColor;
            set => SetProperty(ref chargerTypeColor, value);
        }
        private Color firstNameBorderColor = Color.LightGray;
        public Color FirstNameBorderColor
        {
            get => firstNameBorderColor;
            set => SetProperty(ref firstNameBorderColor, value);
        }
        private Color lastNameBorderColor = Color.LightGray;
        public Color LastNameBorderColor
        {
            get => lastNameBorderColor;
            set => SetProperty(ref lastNameBorderColor, value);
        }

        private Color _emailBorderColor = Color.LightGray;
        public Color EmailBorderColor
        {
            get => _emailBorderColor;
            set => SetProperty(ref _emailBorderColor, value);
        }

        private Color _passwordBorderColor = Color.LightGray;
        public Color PasswordBorderColor
        {
            get => _passwordBorderColor;
            set => SetProperty(ref _passwordBorderColor, value);
        }

        private Color _confirmPasswordBorderColor = Color.LightGray;
        public Color ConfirmPasswordBorderColor
        {
            get => _confirmPasswordBorderColor;
            set => SetProperty(ref _confirmPasswordBorderColor, value);
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }
        private bool _isEmailValid = true;
        public bool IsEmailValid
        {
            get => _isEmailValid;
            set => SetProperty(ref _isEmailValid, value);
        }

        private bool _isPasswordValid = true;
        public bool IsPasswordValid
        {
            get => _isPasswordValid;
            set => SetProperty(ref _isPasswordValid, value);
        }

        public ICommand SubmitRegisterCommand { get; private set; }
        //bindable property for firstname
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                FirstNameBorderColor = string.IsNullOrEmpty(value) ? Color.LightGray : Color.LightGray;
            }
        }


        //bindable property for lastname
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                LastNameBorderColor = string.IsNullOrEmpty(value) ? Color.LightGray : Color.LightGray;
            }
        }


        //bindable property for email
        private string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                EmailBorderColor = string.IsNullOrEmpty(value) ? Color.LightGray : Color.LightGray;
            }
        }


        //bindable property for password
        private string password;
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                PasswordBorderColor = string.IsNullOrEmpty(value) ? Color.LightGray : Color.LightGray;
            }
        }


        //bindable property for confirmPassword
        private string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                SetProperty(ref confirmPassword, value);
                ConfirmPasswordBorderColor = string.IsNullOrEmpty(value) ? Color.LightGray : Color.LightGray;
            }
        }
       
       
        //bindable property for licence plate
        private ObservableCollection<string>  licencePlate;
        public ObservableCollection<string> LicencePlate
        {
            get => licencePlate;
            set => SetProperty(ref licencePlate, value);
        }

        
        //bindable property for vehical brand
        private ObservableCollection<string> _vehicleBrand;
        public ObservableCollection<string> VehicleBrandSource
        {
            get => _vehicleBrand;
            set => SetProperty(ref _vehicleBrand, value);
        }

        //bindable property for vehical model
        private ObservableCollection<string> _vehicleModel;
        public ObservableCollection<string> VehicleModelSource
        {
            get => _vehicleModel;
            set => SetProperty(ref _vehicleModel, value);
        }

        //bindable property for charger type
        private ObservableCollection<string> _chargerType;
        public ObservableCollection<string> ChargerTypeSource
        {
            get => _chargerType;
            set => SetProperty(ref _chargerType, value);
        }
        #endregion

        public UpdateProfileViewModel()
        {
            SubmitUpdateCommand = new Command(UpdateProfile);
            Task.Factory.StartNew(async () =>
            {
                
                ReferenceDataResponse AuthReferenceData = await App.weChargeService.authentication.AuthenticationReferenceData();
                var brand = AuthReferenceData.VehicleBrands.Select(brandname => brandname.Name).ToList();
                var model= AuthReferenceData.VehicleModels.Select(modelname => modelname.Name).ToList();
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
            

        }
        
        //public bool IsValidEmail()
        //{
        //    if (string.IsNullOrEmpty(Email))
        //        return false;

        //    var regex = new Regex(EmailPattern);
        //    return regex.IsMatch(Email);
        //}
        public async void UpdateProfile()
        {
            //IsEmailValid();
           // var regex = new Regex(EmailPattern);
           // bool emailMatched = regex.IsMatch(Email);
            bool emailEmpty = string.IsNullOrWhiteSpace(Email);
            bool passwordEmpty = string.IsNullOrWhiteSpace(Password);
            bool confirmPasswordEmpty = string.IsNullOrWhiteSpace(ConfirmPassword);
            bool firstNameEmpty = string.IsNullOrWhiteSpace(FirstName);
            bool lastNameEmpty = string.IsNullOrWhiteSpace(LastName);
            //bool brandEmpty = string.IsNullOrWhiteSpace(Brand);
            //bool modelEmpty = string.IsNullOrWhiteSpace(Model);
            //bool licensePlateEmpty = string.IsNullOrWhiteSpace(LicencePlate);
            //bool chargerTypeEmpty = string.IsNullOrWhiteSpace(ChargerType);
            if (emailEmpty && passwordEmpty && confirmPasswordEmpty && firstNameEmpty && lastNameEmpty && brandSelectedIndex == -1 && modelSelectIndex == -1 && licensePlateSelectedIndex == -1 && chargerTypeSelectedIndex == -1)
            {
                EmailBorderColor = Color.Red;
                PasswordBorderColor = Color.Red;
                ConfirmPasswordBorderColor = Color.Red;
                FirstNameBorderColor = Color.Red;
                LastNameBorderColor = Color.Red;
                BrandColor = Color.Red;
                LicensePlateColor = Color.Red;
                ChargerTypeColor = Color.Red;
                ModelColor = Color.Red;
                ErrorMessage = "All fields are empty. Please fill in the required fields.";
                return;
            }

            else if (emailEmpty)
            {
                EmailBorderColor = Color.Red;
                ErrorMessage = "Please Enter the Email";
                return;
            }

            else if (passwordEmpty)
            {
                PasswordBorderColor = Color.Red;
                ErrorMessage = "Please Enter the Password";
                return;
            }

            else if (confirmPasswordEmpty)
            {
                ConfirmPasswordBorderColor = Color.Red;
                ErrorMessage = "Please Enter the Confirm Password";
                return;
            }

            else if (firstNameEmpty)
            {
                FirstNameBorderColor = Color.Red;
                ErrorMessage = "Please Enter the FirstName";
                return;
            }

            else if (lastNameEmpty)
            {
                LastNameBorderColor = Color.Red;
                ErrorMessage = "Please Enter the LastName";
                return;
            }

            else if (brandSelectedIndex == -1)
            {
                BrandColor = Color.Red;
                ErrorMessage = "Please Enter the LastName";
                return;
            }

            else if (modelSelectIndex == -1)
            {
                ModelColor = Color.Red;
                ErrorMessage = "Please Enter the LastName";
                return;
            }

            else if (licensePlateSelectedIndex == -1)
            {
                LicensePlateColor = Color.Red;
                ErrorMessage = "Please Enter the LastName";
                return;
            }

            else if (chargerTypeSelectedIndex == -1)
            {
                ChargerTypeColor = Color.Red;
                ErrorMessage = "Please Enter the LastName";
                return;
            }
            IsBusy = true;
            await Task.Factory.StartNew(() =>
            {
                //await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
                Device.BeginInvokeOnMainThread(() =>
                {
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ProfileUpdatedPopup());
                    IsBusy = false;
                });
            });
        }
    }
}
