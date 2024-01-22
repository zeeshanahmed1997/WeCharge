using System;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
namespace WeCharge.Models.Booking.RequestModels
{
    public class ChargingLocationRequestModel
    {
        public string SearchAddressFull { get; set; }
        public string MapCentrePointLatitude { get; set; }
        public string MapCentrePointLongitude { get; set; }
        public string MapCentreZoomLevel { get; set; }
        public string UserCurrentLatitude { get; set; }
        public string UserCurrentLongitude { get; set; }
        public ChargingLocationRequestModel()
        {
           
        }

        public async Task GetUserLocation()
        {
             await getCurrentLocation();
        }
        public async Task getCurrentLocation()
        {

           try
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));
                    if (location != null)
                    {
                        UserCurrentLatitude = location.Latitude.ToString();
                        UserCurrentLongitude = location.Longitude.ToString();
                    }
                    else
                    {

                        // Handle the case when location is null
                        // You can log this situation, show a message, or set default values
                    }
                }
                catch (FeatureNotEnabledException)
                {
                    UserCurrentLatitude = 0.0.ToString();
                    UserCurrentLongitude = 0.0.ToString();
                    // Location services are not enabled.
                    // Handle accordingly, for example, setting default values, showing an alert, etc.
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    // You can log this exception, show a message, or take other appropriate actions
                }



        }

    }
}

