using System;
namespace WeCharge.Models
{
    public class PreviousBookings
    {
        public string Station { get; set; }
        public string Energy { get; set; }
        public string Date { get; set; }
        public string Cost { get; set; }
        public bool IsBusy { get; set; }
    }
}

