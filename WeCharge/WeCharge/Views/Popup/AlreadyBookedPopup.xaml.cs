using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class AlreadyBookedPopup : PopupPage
	{	
		public AlreadyBookedPopup ()
		{
			InitializeComponent ();
		}
        private async void ExitTapped(object sender, EventArgs e)
        {
            // Close the popup when the button is clicked
           
                // Close the topmost popup
                await PopupNavigation.Instance.PopAsync();
            
           // PopupNavigation.Instance.PopAsync();
            
        }
    }
}

