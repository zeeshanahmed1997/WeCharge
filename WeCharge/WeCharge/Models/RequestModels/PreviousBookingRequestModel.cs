using System;
namespace WeCharge.Models.Booking.RequestModels
{
	public class PreviousBookingRequestModel
    {
        public string FromDateLocalISO { get; set; } = "";
        public string ToDateLocalISO { get; set; } = "";
    }
}

