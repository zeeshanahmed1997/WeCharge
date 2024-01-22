using System;
using System.Threading.Tasks;
using WeCharge.Models.Authentication;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.RequestModels;

namespace WeCharge.APIServices.Bookings
{
	public interface IBookingService
	{
        Task<BookingResponse> GetUpcomingBookings();
        Task<BookingResponse> GetPreviousBookings(PreviousBookingRequestModel request);
        Task<ChargingLocationsResponse> FindChargingLocations(ChargingLocationRequestModel request);
        Task<BookingResponse> GetPendingBookings();
        Task<AvailableChargeSlotsResponse> CheckLocationAvailability(AvailableChargeSlotRequestModel availableChargeSlotRequestModel);
        Task<BookingResponseForbookCharger> BookCharger(BookChargerRequestModel bookChargerRequestModel);
        Task<ConfirmBookingResponse> ConfirmBooking(ConfirmBookingRequest BookingID);
        Task<CancelBookingResponse> CancelBooking(ConfirmBookingRequest BookingID);
    }
}

