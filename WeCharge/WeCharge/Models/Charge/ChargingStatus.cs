using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.ChargingStatus
{
    public class ChargingStatus
    {
        public string BookingID { get; set; } = "";
        public string ChargerID { get; set; } = "";

        public Statuses Status { get; set; } // Enum property

        public ChargingStatus()
        {
            Status = Statuses.Success; // Initialize the enum property in the constructor
        }

        public enum Statuses
        {
            Success,
            StartFailed
        }
    }
}
