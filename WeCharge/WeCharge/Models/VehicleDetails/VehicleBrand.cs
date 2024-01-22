using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.VehicleDetails

{

    public class VehicleBrand
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public enum VehicleBrandStatus
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
