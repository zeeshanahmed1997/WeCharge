using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.VehicleDetails
{
    public class VehicleModel
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public enum VehicleModelStatus
        {
            Active,
            Archived
        }


    }
}
