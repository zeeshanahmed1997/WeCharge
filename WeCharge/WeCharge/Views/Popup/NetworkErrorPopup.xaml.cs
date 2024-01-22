using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using WeCharge.Views.MakeBooking;

using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class NetworkErrorPopup : PopupPage
	{

        public Action ClosePopupAction { get; set; }

        public NetworkErrorPopup()
        {
            InitializeComponent();
        }

        void TryAgain_Clicked(System.Object sender, System.EventArgs e)
        {
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                // Call the ClosePopupAction to close the popup
                ClosePopupAction?.Invoke();

                // Optionally, you can navigate to the MakeBookingPage here
                // Navigation.PushAsync(new MakeBookingPage());
            }
        }
    }
}

