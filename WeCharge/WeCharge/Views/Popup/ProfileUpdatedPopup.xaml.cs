using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;
namespace WeCharge.Views.Popup
{	
	public partial class ProfileUpdatedPopup : PopupPage
	{	
		public ProfileUpdatedPopup ()
		{
			InitializeComponent ();
		}
        void UpdateButtonClicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new MakeBookingPage());
            PopupNavigation.Instance.PopAsync();
            //var popupPage = new FilterModalPopup();
            //PopupNavigation.Instance.PushAsync(popupPage);
        }
    }
}

