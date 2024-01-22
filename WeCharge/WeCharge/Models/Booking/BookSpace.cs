using System;
namespace WeCharge.Models.Booking
{
	public class BookSpace
	{
        //public BookingResponseForbookCharger bookingResponseForBookCharger { get; set; }
        public string BookingID { get; set; }
        public Booking Booking { get; set; }
        public string ChargerID { get; set; }
		public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }
        public string Distance { get; set; }
        public string RemainingTime { get; set; }
        public DateTime Date { get; set; }
        public int selectedDurationMinutes { get; set; }
        public string selectedStartTime { get; set; }
       // public Model.MakeBooking.MakeBooking location { get; set; } = new Model.MakeBooking.MakeBooking();

    }
}

