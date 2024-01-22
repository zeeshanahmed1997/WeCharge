using System;
using System.Collections.Generic;
using System.Text;
using WeCharge.Models.Booking;
using WeCharge.Models.Charge;

namespace WeCharge.Models.Charge
{
    public class ChargingPartner
    {
        public string ID { get; set; } = "";
        public string ClientName { get; set; } = "";
        public Address Address { get; set; } = new Address();

        public string Status { get; set; } = "";
        public enum ChargingPartnerStatus
        {
            Active,
            Archived
        }

    }
}
