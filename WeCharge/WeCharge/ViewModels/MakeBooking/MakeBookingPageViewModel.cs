using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCharge.CustomControls;
using WeCharge.Model.MakeBooking;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Theme;
using WeCharge.Views.Accounts;
using WeCharge.Views.MakeBooking;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WeCharge.ViewModels
{
    public class MakeBookingPageViewModel : BaseViewModel
    {
        ChargingLocationRequestModel chargingLocationRequest;
        ChargingLocationsResponse chargingLocationsResponse;
        public ICommand CheckAvailabilityClicked { get; private set; }
        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                if (_selectedPosition != value)
                {
                    _selectedPosition = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                _titleText = value;
                OnPropertyChanged();
            }
        }
        private bool isGridEnabled;
        public bool IsGridEnabled
        {
            get => isGridEnabled;
            set
            {
                isGridEnabled = value;
                OnPropertyChanged();
            }
        }

        private List<CustomPin> _pinLocations = new List<CustomPin>();
        public List<CustomPin> PinLocations
        {
            get => _pinLocations;
            set
            {
                _pinLocations = value;
                OnPropertyChanged();
            }
        }
        private CustomPin _selectedPin;
        public CustomPin SelectedPin
        {
            get => _selectedPin;
            set
            {
                _selectedPin = value;
                OnPropertyChanged();
            }
        }
        private MakeBooking selectedItem;
        public MakeBooking SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<MakeBooking> _bookingItems = new ObservableCollection<MakeBooking>(GetDefaultEmptyList());
        public ObservableCollection<MakeBooking> BookingItems
        {
            get => _bookingItems;
            set => SetProperty(ref _bookingItems, value);
        }

        private ObservableCollection<CarouselItem> _carouselItems = new ObservableCollection<CarouselItem>();
        public ObservableCollection<CarouselItem> CarouselItems
        {
            get => _carouselItems;
            set => SetProperty(ref _carouselItems, value);
        }
        public int Index { get; internal set; }

        static ObservableCollection<MakeBooking> GetDefaultEmptyList()
        {
            var list = new ObservableCollection<MakeBooking>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new MakeBooking() { Location = "            ", Address = "             ", City = "         ", IsBusy = true });
            }
            return list;
        }


        public async Task GetChargingLocationsAsync()
        {
            IsBusy = true;
            IsGridEnabled = false;
            PinLocations.Clear();
            CarouselItems.Clear();
            BookingItems.Clear();
            BookingItems = GetDefaultEmptyList();
            var LocationsList = new List<MakeBooking>();
            var CarouselItemsList = new List<CarouselItem>();
            //await Task.Delay(2000);
            //chargingLocationsResponse = await App.weChargeService.bookingsService.FindChargingLocations(chargingLocationRequest);
            chargingLocationsResponse = await App.weChargeService.bookingsService.FindChargingLocations(chargingLocationRequest);
            if (chargingLocationsResponse != null)
            {
                //chargingLocationsResponse = App.chargingLocationsResponses;
                foreach (Location location in chargingLocationsResponse.Locations)
                {
                    // Parse Latitude and Longitude from string to double
                    if (double.TryParse(location.address.Latitude, out double latitude) &&
                        double.TryParse(location.address.Longitude, out double longitude))
                    {
                        CustomPin customPin = new CustomPin
                        {
                            Position = new Position(latitude, longitude),
                            Label = location.Name,
                            Address = location.address.DisplayLine1,
                            Image = "icon.png"
                            // You can set other properties of CustomPin here if needed
                        };

                        PinLocations.Add(customPin);

                        CarouselItem carouselItem = new CarouselItem
                        {
                            Location = location.Name,
                            Address = location.address.DisplayLine1,
                            PostCode = location.address.AddressPostCode,
                            LevelInfo = location.ChargeDetailsDisplay,
                            Distance = location.DistanceFromUserDisplay,
                            Time = location.TimeFromUserDisplay,
                        };
                        CarouselItemsList.Add(carouselItem);
                        MakeBooking ListViewItem = new MakeBooking
                        {
                            LocationID = location.ID,
                            Location = location.Name,
                            Address = location.address.DisplayLine1,
                            City = location.address.AddressCity,
                            Icon = FontIcons.Charging,
                            LevelInfo = location.ChargeDetailsDisplay,
                            Distance = location.DistanceFromUserDisplay,
                            Time = location.TimeFromUserDisplay,
                            status = location.ChargingPartner.Status,
                            location = location
                        };
                        LocationsList.Add(ListViewItem);
                    }
                }
                CarouselItems = new ObservableCollection<CarouselItem>(CarouselItemsList);
                BookingItems.Clear();
                BookingItems = new ObservableCollection<MakeBooking>(LocationsList);
            }
            IsBusy = false;
            IsGridEnabled = true;
        }
        private string _selectedFilter;
        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    SortBookingItemsBasedOnSelection();
                    OnPropertyChanged();
                }
            }
        }

        public void SortBookingItemsByLocation()
        {
            var sortedItems = BookingItems.OrderBy(b => b.Location).ToList();
            ReplaceBookingItems(sortedItems);
        }

        public void SortBookingItemsByDistance()
        {
            // Assuming Distance is a string. Convert it to numeric type for ordering.
            var sortedItems = BookingItems.OrderBy(b => ConvertDistanceToNumeric(b.Distance)).ToList();
            ReplaceBookingItems(sortedItems);
        }

        private double ConvertDistanceToNumeric(string distance)
        {
            if (string.IsNullOrEmpty(distance))
                return double.MaxValue;

            // Splitting "8 miles" to extract the "8" part.
            var number = distance.Split(' ')[0];
            return double.TryParse(number, out double result) ? result : double.MaxValue;
        }

        private void ReplaceBookingItems(List<MakeBooking> sortedItems)
        {
            BookingItems.Clear();
            foreach (var item in sortedItems)
            {
                BookingItems.Add(item);
            }
        }

        public void SortBookingItemsBasedOnSelection()
        {
            if (SelectedFilter == "Distance from Location")
                SortBookingItemsByDistance();
            else if (SelectedFilter == "Location Name")
                SortBookingItemsByLocation();
        }
        public MakeBookingPageViewModel()
        {
            CheckAvailabilityClicked = new Command(NavigateToCheckAvailability);
            SortBookingItemsBasedOnSelection();
            // CarouselItems = new ObservableCollection<CarouselItem>();
        }
        public void NavigateToCheckAvailability()
        {
            Application.Current.MainPage.Navigation.PushAsync(new CheckAvailabilityPage());
        }
    }
}
