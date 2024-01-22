using System;
namespace WeCharge.Models
{
    public class Bookings
    {
        public string Address { get; set; }
        public string LevelInfo { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool IsBusy { get; set; }
        public string BookingID { get; set; }
    }
}

