using System;
using System.Collections.Generic;
using WeCharge.ViewModels;
using Xamarin.Forms;

namespace WeCharge.Views.Accounts
{
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel registerViewModel;
        public RegisterPage()
        {
            InitializeComponent();
            registerViewModel = new RegisterViewModel();
            // Binding with RergisterViewModel
            BindingContext = registerViewModel;
        }
    }
}
