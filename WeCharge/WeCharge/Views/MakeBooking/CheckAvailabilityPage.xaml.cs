using System;
using System.Collections.Generic;
using WeCharge.Models.Booking;
using WeCharge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace WeCharge.Views.MakeBooking
{	
	public partial class CheckAvailabilityPage : ContentPage
	{
		CheckAvailabilityPageViewModel checkAvailabilityPageViewModel;
        Model.MakeBooking.MakeBooking location;
        public CheckAvailabilityPage ()
		{
            //MyCustomPicker.IsVisible = false;
            InitializeComponent ();
            DatePicker.MinimumDate = DateTime.Today;
            checkAvailabilityPageViewModel = new CheckAvailabilityPageViewModel();
			BindingContext = checkAvailabilityPageViewModel;
        }
        public CheckAvailabilityPage(Model.MakeBooking.MakeBooking _location)
        {
            //MyCustomPicker.IsVisible = false;
            location = _location;
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.Today;
            checkAvailabilityPageViewModel = new CheckAvailabilityPageViewModel(this.location);
            BindingContext = checkAvailabilityPageViewModel;
        }
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {

			DurationPicker.Focus();
            AvailableSlotPicker.Focus();
        }
        void ResetButtonClicked(System.Object sender, System.EventArgs e)
        {
            DatePicker.Date = DateTime.Today; // This sets it to the current date.
            DurationPicker.SelectedItem = null;
            AvailableSlotPicker.SelectedItem = null;
            
        }
        void DatePickerTapped(System.Object sender, System.EventArgs e)
        {
            DatePicker.Focus();
        }

        void DurationPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
           // AvailableSlotPicker.IsEnabled = true;
        }
    }
}

