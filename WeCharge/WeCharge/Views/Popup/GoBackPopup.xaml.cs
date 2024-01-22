using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Models.Booking;
using WeCharge.Models.RequestModels;
using WeCharge.Views.BottomTab;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class GoBackPopup : PopupPage,INotifyPropertyChanged
    {
        CancelBookingResponse cancelBookingResponse;
       
		public GoBackPopup ()
		{
			InitializeComponent ();
            ChargeDate = App.cancelBookingDate;
            ChargeDate = $"You previously booked this station on {ChargeDate}";
            BindingContext = this;
        }
        private string _chargeDate;

        public string ChargeDate
        {
            get { return _chargeDate; }
            set
            {
                if (_chargeDate != value)
                {
                    _chargeDate = value;
                    OnPropertyChanged(nameof(ChargeDate));
                }
            }
        }


        private void ExitIconTapped(object sender, EventArgs e)
        {
            // Close the popup when the button is clicked
            PopupNavigation.Instance.PopAsync();
        }
        private void ContinueClicked(object sender, EventArgs e)
        {
            // Close the popup when the button is clicked
            PopupNavigation.Instance.PopAsync();
        }
        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            ConfirmBookingRequest confirmBookingRequest = new ConfirmBookingRequest();
            confirmBookingRequest.BookingID = App.BookingId;
            cancelBookingResponse = await Task.Run(() => App.weChargeService.bookingsService.CancelBooking(confirmBookingRequest));
            if(cancelBookingResponse._Status == "Success")
            {
                await PopupNavigation.Instance.PopAsync();
                //await App.Current.MainPage.Navigation.PopAsync();
                Shell.Current.GoToAsync("//Home");
            }
        }
    }
}

