using System;
using System.Threading.Tasks;
using WeCharge.APIServices.WebServices;
using static ApiServices.WebServices.RestService.BasicService;
using WeCharge.Models.Authentication;
using ApiServices.WebServices.RestService;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.RequestModels;

namespace WeCharge.APIServices.Bookings
{
	public class BookingService:BasicService,IBookingService
	{
        public WeChargeService Client { get; private set; }
        public BookingService(WeChargeService client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            this.Client = client;
        }
        public BookingService()
        {

        }
        public async Task<BookingResponse> GetUpcomingBookings()
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/GetUpcomingBookings/v1").ToString();

                var result = await CallApi<BookingResponse, AuthenticationField>(new Uri(_url), Client, MethodType.GET, null);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<BookingResponse> GetPreviousBookings(PreviousBookingRequestModel request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/GetPreviousBookings/v1").ToString();

                var result = await CallApi<BookingResponse, PreviousBookingRequestModel>(new Uri(_url), Client, MethodType.GET, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ChargingLocationsResponse> FindChargingLocations(ChargingLocationRequestModel request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/FindChargingLocations/v1").ToString();

                var result = await CallApi<ChargingLocationsResponse, ChargingLocationRequestModel>(new Uri(_url), Client, MethodType.GET, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<BookingResponse> GetPendingBookings()
        { 
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/GetPendingBookings/v1").ToString();

                var result = await CallApi<BookingResponse, ChargingLocationRequestModel>(new Uri(_url), Client, MethodType.GET, null);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<AvailableChargeSlotsResponse> CheckLocationAvailability(AvailableChargeSlotRequestModel availableChargeSlotRequestModel)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/CheckLocationAvailabilityForBooking/v1").ToString();

                var result = await CallApi<AvailableChargeSlotsResponse, AvailableChargeSlotRequestModel>(new Uri(_url), Client, MethodType.GET, availableChargeSlotRequestModel);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<BookingResponseForbookCharger> BookCharger(BookChargerRequestModel bookChargerRequestModel)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/BookCharger/v1").ToString();

                var result = await CallApi<BookingResponseForbookCharger, BookChargerRequestModel>(new Uri(_url), Client, MethodType.POST, bookChargerRequestModel);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ConfirmBookingResponse> ConfirmBooking(ConfirmBookingRequest BookingID)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/ConfirmBooking/v1").ToString();

                var result = await CallApi<ConfirmBookingResponse, ConfirmBookingRequest>(new Uri(_url), Client, MethodType.POST, BookingID);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<CancelBookingResponse> CancelBooking(ConfirmBookingRequest BookingID)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/CancelBooking/v1").ToString();

                var result = await CallApi<CancelBookingResponse, ConfirmBookingRequest>(new Uri(_url), Client, MethodType.POST, BookingID);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

