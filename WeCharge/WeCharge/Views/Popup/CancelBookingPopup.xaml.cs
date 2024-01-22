using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using WeCharge.Models.Booking;


using WeCharge.Models.RequestModels;
using WeCharge.Views.Booking;
using Xamarin.Forms;

namespace WeCharge.Views.Popup
{	
	public partial class CancelBookingPopup : PopupPage
	{
        string pageName;
        string BookingID;
        CancelBookingResponse cancelBookingResponse;
        public event EventHandler BookingCancelled;
        public CancelBookingPopup (string bookingID)
		{
			InitializeComponent ();
            BookingID = bookingID;
		}
        public CancelBookingPopup(string bookingID, string name)
        {
            pageName = name;
            InitializeComponent();
            BookingID = bookingID;
        }
        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            ConfirmBookingRequest confirmBookingRequest = new ConfirmBookingRequest();
            confirmBookingRequest.BookingID = BookingID;
            cancelBookingResponse = await Task.Run(() => App.weChargeService.bookingsService.CancelBooking(confirmBookingRequest));
            if (cancelBookingResponse._Status == "Success")
            {
                
                BookingCancelled?.Invoke(this, EventArgs.Empty);
                PopupNavigation.Instance.PopAsync();

            }
        }

        void KeepBookingClick(System.Object sender, System.EventArgs e)
        {
            // Close the popup when the button is clicked
            PopupNavigation.Instance.PopAsync();
        }
    }
}

