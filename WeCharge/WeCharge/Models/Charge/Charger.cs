using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace WeCharge.Models.Charge
{

    /// <summary>
    /// Represents a single EV charger at a <see cref="Location"/> that <see cref="Customer"/>s can charge their car from.
    /// At the start this is interchargeable for "Bay". However, I am aware that in the future we may need to separately define a 
    /// "Bay" and link it to a charger(s).
    /// </summary>
    public class Charger
    {
        public string ID { get; set; } = "";
        public string LocationID { get; set; } = "";
        public Location Location { get; set; } = new Location();
        public int BayNumber { get; set; }
        public string TypeOfChargerID { get; set; } = "";
        public string CostRateDisplay { get; set; } = "";
        public string Status { get; set; } = "";
        public enum ChargerStatus
        {
            /// <summary>
            /// The charger is online and available for charge booking.
            /// </summary>
            Online,

            /// <summary>
            /// The asset is no longer active and available for use,
            /// but it is not deleted.
            /// </summary>
            Archived
        }

        public string ChargerLevelsSummary { get; set; } = "";

    }
}
