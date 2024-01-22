using System;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Theme;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class InternetConnectionPopup : PopupPage
	{	
		public InternetConnectionPopup ()
		{
			InitializeComponent ();
            UpdateInternetStatus();
            // Event subscription
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            UpdateInternetStatus();
        }
        private void UpdateInternetStatus()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                internetStatusLabel.Text = "You are back online";
                internetStatusLabel.TextColor = Color.White;
                InternetStatusFrame.BackgroundColor = Color.Green;
                Icon.Text = FontIcons.CloudCheck;
                Icon.TextColor = Color.White;
            }
            else
            {
                internetStatusLabel.Text = "Oops! We have lost connection";
                internetStatusLabel.TextColor = Color.White;
                InternetStatusFrame.BackgroundColor = Color.Red;
                Icon.Text = FontIcons.CloudSlash;
                Icon.TextColor = Color.White;
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Unsubscribe from event when the page is not visible
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
    }
}

