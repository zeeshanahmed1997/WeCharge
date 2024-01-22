using System;
namespace WeCharge.Models.RequestModels
{
	public class ConfirmBookingRequest
	{
            /// <summary>
            /// ID of the <see cref="Models.Booking"/> to confirm.
            /// </summary>
            public string BookingID { get; set; } = "";
    }
}

