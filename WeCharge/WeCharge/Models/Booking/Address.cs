using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.Booking
{
    public class Address
    {
        public string ID { get; set; } = "";
        public string DisplayLine1 { get; set; } = "";
        public string DisplayLine2 { get; set; } = "";
        public string AddressLine1 { get; set; } = "";
        public string AddressLine2 { get; set; } = "";
        public string AddressLine3 { get; set; } = "";
        public string AddressCity { get; set; } = "";
        public string AddressState { get; set; } = "";
        public string AddressPostCode { get; set; } = "";
        public string AddressCountryName { get; set; } = "";
        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";
    }
}
