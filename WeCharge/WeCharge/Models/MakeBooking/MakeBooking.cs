using System;
using System.Collections.Generic;
using WeCharge.Models.Booking;

namespace WeCharge.Model.MakeBooking
{
    public class MakeBooking
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Icon { get; set; }
        public string LevelInfo { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        public string LocationID { get; set; }
        public bool IsBusy { get; set; }
        public string status { get; set; }
        public Location location { get; set; }
    }
}

