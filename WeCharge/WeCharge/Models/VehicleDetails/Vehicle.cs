using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.VehicleDetails
{
    /// <summary>
    /// Represents a single vehicle owned by a customer that will be used in bookings and charging.
    /// </summary>
    public class Vehicle
    {
        public string ID { get; set; } = "";
        public string BrandID { get; set; } = "";
        public string BrandOther { get; set; } = "";
        public string ModelID { get; set; } = "";
        public string ModelOther { get; set; } = "";
        public string LicensePlateNumber { get; set; } = "";
        public string ChargerTypeID { get; set; } = "";
        public string Status { get; set; } = "";
        public enum VehicleStatus
        {
            Active,

            /// <summary>
            /// The asset is no longer active and available for use,
            /// but it is not deleted.
            /// </summary>
            Archived
        }

    }

}
