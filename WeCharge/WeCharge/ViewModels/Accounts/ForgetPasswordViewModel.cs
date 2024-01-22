using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Rg.Plugins.Popup.Services;

using WeCharge.Models.Accounts;
using WeCharge.Models.RequestModels;
using WeCharge.Views.Popup;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.ViewModels.Accounts
{
	public class ForgetPasswordViewModel : BaseViewModel
    {


        ForgetPasswordResponse forgetPasswordResponse;
        public ICommand ResetCommand { get; }
        public ICommand BackButtonCommand { get; private set; }

        public ForgetPasswordViewModel()
		{
            IsMainStackLayoutVisible = true;
            IsStackLayoutVisible = false;
            BackButtonCommand = new Command(GoBack);
            ResetCommand = new Command(ResetPasswordButton);

        }

        private bool isStackLayoutVisible;
        public bool IsStackLayoutVisible
        {
            get { return isStackLayoutVisible; }
            set
            {
                if (isStackLayoutVisible != value)
                {
                    isStackLayoutVisible = value;
                    OnPropertyChanged("IsStackLayoutVisible");
                }
            }
        }

        private bool isMainStackLayoutVisible;
        public bool IsMainStackLayoutVisible
        {
            get { return isMainStackLayoutVisible; }
            set
            {
                if (isMainStackLayoutVisible != value)
                {
                    isMainStackLayoutVisible = value;
                    OnPropertyChanged("IsMainStackLayoutVisible");
                }
            }
        }
        private string email;
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

        private string _errorLabel;
        public string ErrorLabel
        {
            get { return _errorLabel; }
            set
            {
                if (_errorLabel != value)
                {
                    _errorLabel = value;
                    OnPropertyChanged("ErrorLabel");
                }
            }
        }

        private Color _emailBorderColor = Color.LightGray;
        public Color EmailBorderColor
        {
            get => _emailBorderColor;
            set => SetProperty(ref _emailBorderColor, value);
        }

       //main work here on reset button
        private async void ResetPasswordButton()
        {
            
            //IsStackLayoutVisible = !IsStackLayoutVisible;
            if (string.IsNullOrEmpty(Email))
            {
                EmailBorderColor = Color.Red;
                ErrorLabel = "Email cannot be empty.";
                return;
            }
            else
            {
                bool isValid = System.Text.RegularExpressions.Regex.IsMatch(Email, App.emailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (isValid)
                {
                    ErrorLabel = string.Empty;
                    if (NetworkHelper.UpdateConnectivityStatus())
                    {
                        try
                        {
                            IsButtonEnable = false;
                            _ = Task.Factory.StartNew(async () =>
                            {
                                ForgetPasswordRequest forgetPasswordRequest = new ForgetPasswordRequest();
                                forgetPasswordRequest.Email = Email;
                                forgetPasswordResponse = await App.weChargeService.authentication.ForgetPassword(forgetPasswordRequest);
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    if (forgetPasswordResponse?._Status == "Success")
                                    {
                                        IsMainStackLayoutVisible = false;
                                        IsStackLayoutVisible = true;
                                    }
                                    else
                                    {
                                        ErrorLabel = "Email not sent";
                                    }
                                });

                            });
                            IsButtonEnable = true;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else
                    {
                        var netErrorPopup = new NetworkErrorPopup();

                        netErrorPopup.ClosePopupAction = async () =>
                        {
                            await PopupNavigation.Instance.PopAllAsync();
                           
                        };
                        await PopupNavigation.Instance.PushAsync(netErrorPopup);
                    }
                    
                   
                    
                    
                    
                }
                else
                {
                    ErrorLabel = "invalid email format";
                    EmailBorderColor = Color.Red;
                }
                
            }
            
        }

        public async void GoBack()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}


        
    }
}

