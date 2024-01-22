using System;
using System.Collections.Generic;

using WeCharge.ViewModels;
using WeCharge.ViewModels.Accounts;

using Xamarin.Forms;

namespace WeCharge.Views.Accounts
{	
	public partial class ForgetPasswordPage : ContentPage
	{
        ForgetPasswordViewModel ForgetPasswordVM;
		public ForgetPasswordPage ()
		{
			 InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            ForgetPasswordVM = new ForgetPasswordViewModel();
			BindingContext = ForgetPasswordVM;

        }
	}
}

