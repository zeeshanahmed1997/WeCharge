using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microcharts;
using Rg.Plugins.Popup.Services;

using SkiaSharp;
using WeCharge.Models;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Views.Accounts;
using WeCharge.Views.Booking;
using WeCharge.Views.Popup;

using Xamarin.Forms;

namespace WeCharge.ViewModels.Booking
{
    public class BookingsPageViewModel : BaseViewModel // You may need to create a BaseViewModel that implements INotifyPropertyChanged
    {

        BookingResponse previousBookingResponse;
        BookingResponse upcomingBookingResponse;
        public ICommand ShowManuCommand { get; private set; }
        public ICommand ViewBookingClicked { get; private set; }
        public ICommand ViewPreviousBookingCommand { get; private set; }


        private bool isPreviousBookingLoad;
        public bool IsPreviousBookingLoad
        {
            get => isPreviousBookingLoad;
            set => SetProperty(ref isPreviousBookingLoad, value);

        }



        private bool isPreviousBookingEnabled;
        public bool IsPreviousBookingsEnabled
        {
            get => isPreviousBookingEnabled;
            set => SetProperty(ref isPreviousBookingEnabled, value);

        }
        private ObservableCollection<ChartEntry> entries;
        public ObservableCollection<ChartEntry> Entries
        {
            get { return entries; }
            set
            {
                if (entries != value)
                {
                    entries = value;
                    OnPropertyChanged(nameof(Entries));
                }
            }
        }

        private ObservableCollection<Models.Booking.Booking> viewBooking = new ObservableCollection<Models.Booking.Booking>();
        public ObservableCollection<Models.Booking.Booking> ViewBooking
        {
            get { return viewBooking; }
            set
            {
                if (viewBooking != value)
                {
                    viewBooking = value;
                    OnPropertyChanged(nameof(ViewBooking));
                }
            }
        }
        private ObservableCollection<Bookings> upcomingBooking = new ObservableCollection<Bookings>();
        public ObservableCollection<Bookings> UpcomingBookings
        {
            get { return upcomingBooking; }
            set
            {
                if (upcomingBooking != value)
                {
                    upcomingBooking = value;
                    OnPropertyChanged(nameof(UpcomingBookings));
                }
            }
        }
        private ObservableCollection<PreviousBookings> previousBookingDetails = new ObservableCollection<PreviousBookings>(GetPreviousDefaultEmptyList());
        public ObservableCollection<PreviousBookings> PreviousBookingDetails
        {
            get { return previousBookingDetails; }
            set
            {
                if (previousBookingDetails != value)
                {
                    previousBookingDetails = value;
                    OnPropertyChanged(nameof(PreviousBookingDetails));
                }
            }
        }
        private ObservableCollection<Models.Booking.Booking> previousBookingDetail = new ObservableCollection<Models.Booking.Booking>();
        public ObservableCollection<Models.Booking.Booking> PreviousBookingDetail
        {
            get { return previousBookingDetail; }
            set
            {
                if (previousBookingDetail != value)
                {
                    previousBookingDetail = value;
                    OnPropertyChanged(nameof(PreviousBookingDetail));
                }
            }
        }

        static ObservableCollection<Bookings> GetDefaultEmptyList()
        {
            var list = new ObservableCollection<Bookings>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Bookings() { Address = "            ", LevelInfo = "         ", Date = "       ", Time = "       ", IsBusy = true });
            }
            return list;
        }

        static ObservableCollection<PreviousBookings> GetPreviousDefaultEmptyList()
        {
            var list = new ObservableCollection<PreviousBookings>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new PreviousBookings() { Station = "             ", Energy = "         ", Date = "       ", Cost = "       ", IsBusy = true });
            }
            return list;
        }
        private bool hasUpcomingBooking = true;
        public bool HasUpcomingBooking
        {
            get { return hasUpcomingBooking; }
            set
            {
                if (hasUpcomingBooking != value)
                {
                    hasUpcomingBooking = value;
                    OnPropertyChanged(nameof(HasUpcomingBooking));
                }
            }
        }
        private bool hasPreviousBooking = true;
        public bool HasPreviousBooking
        {
            get { return hasPreviousBooking; }
            set
            {
                if (hasPreviousBooking != value)
                {
                    hasPreviousBooking = value;
                    OnPropertyChanged(nameof(HasPreviousBooking));
                }
            }
        }
        public void LoadUpcomingBookingsAsync()
        {
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                try
                {
                    Task.Factory.StartNew(async () =>
                    {
                        UpcomingBookings.Clear();
                        UpcomingBookings = GetDefaultEmptyList();
                        IsBusy = true;

                        upcomingBookingResponse = await App.weChargeService.bookingsService.GetUpcomingBookings();
                        var bookingItems = new ObservableCollection<Bookings>();
                        if (upcomingBookingResponse != null)
                        {
                            await Task.Delay(1000);

                            Device.BeginInvokeOnMainThread(() =>
                            {                                                                   
                                    //    ViewBooking.Clear();
                                    foreach (var booking in upcomingBookingResponse.Bookings)
                                    {
                                        ViewBooking.Add(booking);
                                        bookingItems.Add(new Bookings
                                        {
                                            BookingID = booking.ID,
                                            Address = booking.Location.address.DisplayLine1,
                                            Date = booking.DateTimeLocalFormattedDisplay,
                                            LevelInfo = booking.Location.ChargeDetailsDisplay,
                                            Time = booking.SlotTimeFormattedDisplay,

                                        });
                                    }
                                    if (App.booking != null)
                                    {
                                        var itemsToKeep = bookingItems.Where(b => b.BookingID != App.booking.ID).ToList();
                                        bookingItems.Clear();
                                    Device.BeginInvokeOnMainThread(() => { HasUpcomingBooking = itemsToKeep.Count > 0 ? true : false; });
                                     
                                        foreach (var item in itemsToKeep)
                                        {
                                            bookingItems.Add(item);
                                        }
                                    }
                                   else
                                   {
                                    Device.BeginInvokeOnMainThread(() => { HasUpcomingBooking = upcomingBookingResponse.Bookings.Count > 0 ? true : false; });
                                    
                                   } 
                                UpcomingBookings.Clear();
                                UpcomingBookings = new ObservableCollection<Bookings>(bookingItems);
                                IsBusy = false;
                            });
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                HasUpcomingBooking = false;
                            });
                        }
                        // Sort bookings by Date and Time in ascending order
                        //  var sortedBookings = bookingResponse.Bookings.OrderBy(b => b.DateUTCOffset).ThenBy(b => b.DateTimeLocalISO).ToList();

                    });
                }
                catch (Exception ex)
                {
                    // Log or display the exception message to see if there's an error
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {

                if (PopupNavigation.Instance.PopupStack.Count == 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                        NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();


                        networkErrorPopup.ClosePopupAction = async () =>
                        {
                            await PopupNavigation.Instance.PopAllAsync();
                            LoadUpcomingBookingsAsync();
                        };

                        PopupNavigation.Instance.PushAsync(networkErrorPopup);
                    });
                }
            }

        }

        public void LoadPreviousBookingsAsync()
        {

            IsPreviousBookingsEnabled = false;
            IsPreviousBookingLoad = true;
            if (NetworkHelper.UpdateConnectivityStatus())
            {
                PreviousBookingDetails.Clear();
                PreviousBookingDetails = GetPreviousDefaultEmptyList();
                PreviousBookingRequestModel previousBookingRequestModel = new PreviousBookingRequestModel();
                previousBookingRequestModel.FromDateLocalISO = null;
                previousBookingRequestModel.ToDateLocalISO = null;

                Task.Factory.StartNew(async () =>
                {
                    previousBookingResponse = await App.weChargeService.bookingsService.GetPreviousBookings(previousBookingRequestModel);

                    var previousItems = new ObservableCollection<PreviousBookings>();
                    if (previousBookingResponse != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if (previousBookingResponse?.Bookings?.Count != 0)
                            {
                                HasPreviousBooking = true;
                                foreach (var booking in previousBookingResponse.Bookings)
                                {

                                    PreviousBookingDetail.Add(booking);
                                    previousItems.Add(new PreviousBookings
                                    {
                                        Station = booking.Location.Name,
                                        Date = booking.DateTimeLocalFormattedDisplay,
                                        Energy = booking.ChargeKiloWattsConsumedDisplay.ToString(),
                                        Cost = booking.ChargeTotalAmountIncTaxDisplay.ToString(),
                                    });
                                }
                            }
                            else
                            {
                                HasPreviousBooking = false;
                            }
                            PreviousBookingDetails.Clear();
                            PreviousBookingDetails = new ObservableCollection<PreviousBookings>(previousItems);
                            IsPreviousBookingLoad = false;
                            IsPreviousBookingsEnabled = true;
                        });
                    }
                    else
                    {
                        HasPreviousBooking = false;
                    }
                });
            }
            else
            {
                if (PopupNavigation.Instance.PopupStack.Count == 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        NetworkErrorPopup networkErrorPopup = new NetworkErrorPopup();
                        networkErrorPopup.ClosePopupAction = async () =>
                        {
                            await PopupNavigation.Instance.PopAllAsync();
                            LoadPreviousBookingsAsync();
                        };
                        PopupNavigation.Instance.PushAsync(networkErrorPopup);
                    });
                }
            }
        }
        public void NavigateViewBooking(Bookings selectedBooking)
        {
            Models.Booking.Booking booking;
            if (selectedBooking == null) return;

            var selectedBookingId = selectedBooking.Address;
            booking = ViewBooking.FirstOrDefault(b => b.Location.address.DisplayLine1 == selectedBooking.Address && b.SlotTimeFormattedDisplay == selectedBooking.Time);

            // Get the index of the selected booking
            //int selectedIndex = UpcomingBookings.IndexOf(selectedBooking);
            //Models.Booking.Booking booking = new Models.Booking.Booking();
            //booking = ViewBooking[selectedIndex];
            App.Current.MainPage.Navigation.PushAsync(new ViewBookingPage(booking));
        }

        private void OnViewPreviousBookingTapped(PreviousBookings selectedBooking)
        {
            if (selectedBooking == null)
                return;

            int index = PreviousBookingDetails.IndexOf(selectedBooking); // Assuming PreviousBookings is the name of the ObservableCollection or List you're using in the ViewModel
            Models.Booking.Booking booking = new Models.Booking.Booking();
            booking = PreviousBookingDetail[index];
            App.Current.MainPage.Navigation.PushAsync(new PreviousBookingPage(booking));
            // Do whatever you want with the index or the selectedBooking
        }

        public BookingsPageViewModel()
        {
            ViewPreviousBookingCommand = new Command<PreviousBookings>(OnViewPreviousBookingTapped); // replace YourBookingType with the type of your bookin
            ViewBookingClicked = new Command<Bookings>(NavigateViewBooking);
            ShowManuCommand = new Command(ShowMenu);
            // ViewBookingClicked = new Command(NavigateViewBooking);
            Entries = new ObservableCollection<ChartEntry>
            {
                new ChartEntry(200)
                {
                    Color = SKColor.Parse("#000000"),
                    Label = "January",
                    ValueLabel = "400"
                },
                new ChartEntry(150)
                {
                    Color = SKColor.Parse("#000000"),
                    Label = "March",
                    ValueLabel = "400"
                },
                new ChartEntry(300)
                {
                    Color = SKColor.Parse("#000000"),
                    Label = "October",
                    ValueLabel = "400"
                },
            };
        }
        public void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        public void NavigateViewBooking()
        {
            App.Current.MainPage.Navigation.PushAsync(new ViewBookingPage());
        }
    }
}
