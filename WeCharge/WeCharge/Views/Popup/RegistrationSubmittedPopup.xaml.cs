using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.Accounts;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class RegistrationSubmittedPopup : PopupPage
	{	
		public RegistrationSubmittedPopup ()
		{
			InitializeComponent ();
		}
        void LoginButtonClicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            PopupNavigation.Instance.PopAsync();
            //var popupPage = new FilterModalPopup();
            //PopupNavigation.Instance.PushAsync(popupPage);
        }
    }
}

