using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.Charge
{
    public class ChargerType
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public enum ChargerTypeStatus
        {
            Active,
            Archived
        }
    }

}
