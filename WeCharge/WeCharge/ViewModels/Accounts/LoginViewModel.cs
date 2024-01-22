using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using recappt.APIServices.Authentication;
using Rg.Plugins.Popup.Services;

using WeCharge.APIServices.Authentication;
using WeCharge.Models.Authentication;
using WeCharge.Views.Accounts;
using WeCharge.Views.Popup;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IAuthenticationService authenticationService;
        #region Properties
        private string buttonText;
        private string email= "";
        private string password = "";
        private string errorMessage = null;
        private bool isLoading;
        private bool isPasswordHidden = true;
        private string passwordIcon = "\uf070";
        private bool isPasswordField;

        private bool isForgetPasswordEnabled = true;
        public bool IsForgetPasswordEnabled
        {
            get => isForgetPasswordEnabled;
            set
            {
                isForgetPasswordEnabled = value;
                OnPropertyChanged();
            }
        }
        private bool switchToggled;
        public bool SwitchToggled
        {
            get => switchToggled;
            set
            {
                switchToggled = value;
                OnPropertyChanged();
            }
        }
        public bool IsPasswordField
        {
            get => isPasswordField;
            set
            {
                isPasswordField = value;
                OnPropertyChanged();
            }
        }

        public string PasswordIcon
        {
            get => passwordIcon;
            set
            {
                if (passwordIcon != value)
                {
                    passwordIcon = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPasswordHidden
        {
            get => isPasswordHidden;
            set
            {
                if (isPasswordHidden != value)
                {
                    isPasswordHidden = value;
                    PasswordIcon = IsPasswordHidden ? "\uf070" : "\uf06e"; // Unicode codes for eye and eye-slash icons
                    OnPropertyChanged();
                }
            }
        }


        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                // Check if value is not null or empty
                if (!string.IsNullOrEmpty(value))
                {
                    EmailBorderColor = Color.LightGray; // Set border color to light gray
                }
                else
                {
                    EmailBorderColor = Color.LightGray; // Reset to default color
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                // Check if value is not null or empty
                if (!string.IsNullOrEmpty(value))
                {
                    PasswordBorderColor = Color.LightGray; // Set border color to light gray
                }
                else
                {
                    PasswordBorderColor = Color.LightGray; // Reset to default color
                }
            }
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
        #endregion
        #region Commands
        public ICommand SubmitLoginCommand { get; private set; }
        public ICommand ForgetPasswordCommand { get; private set; }
        public ICommand SubmitSignupCommand { get; private set; }
        public ICommand TogglePasswordVisibilityCommand { get; private set; }
        #endregion
        public LoginViewModel()
        {
            SubmitLoginCommand = new Command(LoginAsync);
            SubmitSignupCommand = new Command(Signup);
            ForgetPasswordCommand = new Command(ForgetPassword);
            TogglePasswordVisibilityCommand = new Command(TogglePasswordVisibility);
            AutoLoginIfCredentialsSaved();
        }

        private async void AutoLoginIfCredentialsSaved()
        {
            var savedEmail = Preferences.Get("Email", string.Empty);
            var savedPassword = Preferences.Get("Password", string.Empty);

            if (!string.IsNullOrWhiteSpace(savedEmail) && !string.IsNullOrWhiteSpace(savedPassword))
            {
                Email = savedEmail;
                Password = savedPassword;
                LoginAsync();
            }
        }
        #region Command Functions
        public async void LoginAsync()
        {    
            ErrorMessage = null;
            bool emailEmpty = string.IsNullOrWhiteSpace(Email);
            bool passwordEmpty = string.IsNullOrWhiteSpace(Password);
            
            if (emailEmpty && passwordEmpty)
            {
                EmailBorderColor = Color.Red;
                PasswordBorderColor = Color.Red;
                ErrorMessage = "All fields are empty. Please fill in the required fields.";
                return;
            }
            if (emailEmpty)
            {
                EmailBorderColor = Color.Red;
                ErrorMessage = "Please enter email";
                return;
            }
            if (passwordEmpty)
            {
                PasswordBorderColor = Color.Red;
                ErrorMessage = "Please enter password";
                return;
            }
            //bool isValid = System.Text.RegularExpressions.Regex.IsMatch(Email, App.emailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //if (!isValid)
            //{
            //    EmailBorderColor = Color.Red;
            //    ErrorMessage = "Invalid email format";
            //    return;
            //}
            IsLoading = true; // Show the activity indicator
            await Task.Factory.StartNew(async () =>
        {
            AuthenticationField authenticationField = new AuthenticationField
            {
                Email = Email,
                Password = Password
            };
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                IsButtonEnable = false;
                AuthenticateUserResponse response = await App.weChargeService.authentication.Login(authenticationField);
                await Task.Delay(2000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (response != null && response.IsAuthenticated)
                    {
                            Preferences.Set("Email", Email);
                            Preferences.Set("Password", Password);
                            Preferences.Set("AuthToken", response.NextAuthToken);
                            App.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        Preferences.Set("Email", null);
                        Preferences.Set("Password", null);
                        ErrorMessage = "Invalid Email or Password"; // Set an error message for invalid login
                    }
                    IsLoading = false; // Hide the activity indicator
                    IsButtonEnable = true;
                });
            }
            else
            {
                IsLoading = false;
                var netErrorPopup = new NetworkErrorPopup();
                netErrorPopup.ClosePopupAction = async () =>
                {
                    await PopupNavigation.Instance.PopAllAsync();

                };
                await PopupNavigation.Instance.PushAsync(netErrorPopup);
            }
        });
        }
        public void TogglePasswordVisibility()
        {
            IsPasswordHidden = !IsPasswordHidden;
            OnPropertyChanged(nameof(IsPasswordHidden)); // Notify UI of the change
        }
        public async void Signup()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            //ButtonText = "Clicked!";
        }
        public async void ForgetPassword()
        {
            IsForgetPasswordEnabled = false;
            //Browser.OpenAsync("https://www.google.com");
            await App.Current.MainPage.Navigation.PushAsync(new ForgetPasswordPage());
            IsForgetPasswordEnabled = true;
        }
        #endregion
    }
}
