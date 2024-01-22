using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.BottomTab;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{
    public partial class BookingExpiredPopup : PopupPage
    {
        public BookingExpiredPopup()
        {
            InitializeComponent();
        }
        private void ExitTapped(object sender, EventArgs e)
        {
            // Close the popup when the button is clicked
            PopupNavigation.Instance.PopAsync();
            Shell.Current.GoToAsync("//Home");
        }

        void ContinueButtonClicked(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}

