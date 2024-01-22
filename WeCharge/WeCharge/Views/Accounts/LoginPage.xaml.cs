using System;
using System.Collections.Generic;
using recappt.APIServices.Authentication;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.APIServices.Authentication;
using WeCharge.ViewModels;
using WeCharge.Views.Popup;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Views.Accounts
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;

        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            // Create an instance of the AuthenticationService.

            IAuthenticationService authService = new AuthenticationService();

            loginViewModel = new LoginViewModel(); // Pass the authService to the LoginViewModel constructor.

            // Binding with LoginViewModel
            BindingContext = loginViewModel;
            string email = Preferences.Get("Email", null);
            string password = Preferences.Get("Password", null);
            if (email != null && password != null)
            {
                Email.IsEnabled = false;
                Password.IsEnabled = false;
                ForgetPassword.IsEnabled = false;
            }
        }
    }
}
