using System;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using WeCharge.Model;
using WeCharge.ViewModels.Booking;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.Popup;
using WeCharge.Views.MakeBooking;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using System.Threading.Tasks;
using WeCharge.ViewModels;
using System.Linq;
using WeCharge.Models;

namespace WeCharge.Views.Booking
{
    public partial class BookingsPage : ContentPage
    {
        const int ItemHeight = 100;
        public BookingsPageViewModel ViewModel { get; set; }

        public BookingsPage()
        {
            InitializeComponent();
            ViewModel = new BookingsPageViewModel();
            BindingContext = ViewModel;

            // barchart code region commented

            //BarChart.Chart = new BarChart() { Entries = ViewModel.Entries };
            //int barWidth = 150;
            //BarChart.WidthRequest = barWidth;


           // UpcomingBookingsListView.ItemsSource = ViewModel.UpcomingBookings;
           // PreviousBookingsListView.ItemsSource = ViewModel.PreviousBookingDetails;
        }

        void UpcomingBookingsClicked(object sender, EventArgs e)
        {
            UpcomingBookings.BackgroundColor = Color.Black;
            UpcomingBookings.TextColor = Color.White;
            PreviousBookings.BackgroundColor = Color.FromHex("#D9D9D9");
            PreviousBookings.TextColor = Color.FromHex("#616161");
            TopButtonsGrid.RaiseChild((Button)sender);
            PreviousBookingsView.IsVisible = false;
            UpcomingBookingsView.IsVisible = true;
        }

        void PreviousBookingsClicked(object sender, EventArgs e)
        {
            PreviousBookings.BackgroundColor = Color.Black;
            PreviousBookings.TextColor = Color.White;
            UpcomingBookings.BackgroundColor = Color.FromHex("#D9D9D9");
            UpcomingBookings.TextColor = Color.FromHex("#616161");
            TopButtonsGrid.RaiseChild((Button)sender);
            UpcomingBookingsView.IsVisible = false;
            PreviousBookingsView.IsVisible = true;
            ViewModel.LoadPreviousBookingsAsync();
            int itemsCount = ViewModel.PreviousBookingDetails.Count;
            int totalHeight = itemsCount * ItemHeight;
            PreviousBookingsListView.HeightRequest = totalHeight;
        }

        public void OnSelectedItem(object sender, SelectedItemChangedEventArgs args)
        {
            Model.MakeBooking.MakeBooking myBook = (Model.MakeBooking.MakeBooking)args.SelectedItem;
            App.MakeBookingLocation = myBook;
        }

        void CancelBookingClicked(object sender, EventArgs e)
        {
            var button = sender as View;
            if (button != null)
            {
                Bookings item =(Bookings) button.BindingContext;
                string bookingID = item.BookingID;
                var popupPage = new CancelBookingPopup(bookingID);
                popupPage.BookingCancelled += (s, args) =>
                {
                    // Remove the item from your ItemsSource
                    ViewModel.UpcomingBookings.Remove(item);
                    ViewModel.HasUpcomingBooking = ViewModel.UpcomingBookings.Count > 0 ? true : false;
                };

                PopupNavigation.Instance.PushAsync(popupPage);
            }
        }

        void UpcomingBookingsDatePickerTapped(System.Object sender, System.EventArgs e)
        {
           // UpcomingBookingsDatePicker.Focus();
        }
        void PreviousBookingsDatePickerTapped(System.Object sender, System.EventArgs e)
        {
            //PreviousBookingsDatePicker.Focus();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadUpcomingBookingsAsync();

            //ViewModel.LoadPreviousBookingsAsync();

        }
        void ListCellTapped(System.Object sender, System.EventArgs e)
        {
        }
        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
    }
}
