using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;



using WeCharge.Models.Charge;

using Xamarin.Forms.Maps;

namespace WeCharge.Models.Booking
{
    public class ChargingLocationsResponse
    {
        public List<Location> Locations { get; set; }
        public string _Status { get; set; }
        public object _LotusStatusCode { get; set; }
        public object _LotusStatusDetails { get; set; }
        //public IEnumerator GetEnumerator()
        //{
        //    // Implement your custom logic to return an enumerator
        //    // that allows iterating over Location objects.
        //    yield return this; // Replace this with your logic.
        //}
    }

    public class Location
    {
        public string ID { get; set; } = "";
        public string ChargingPartnerID { get; set; } = "";
        public ChargingPartner ChargingPartner { get; set; } = new ChargingPartner();
        public string Name { get; set; } = "";
        public Address address { get; set; } = new Address();
        public string CustomerGuidance { get; set; } = "";
        public int NumberOfBays { get; set; } = 0;
        public string Status { get; set; } = "";
        public enum LocationStatus
        {
            Active,
            Archived
        }
        public string CurrentAvilabilityStatus { get; set; } = "";
        public enum CurrentAvilabilityStatuses
        {
            AvailableNow,
            Offline,
            NotAvailable

        }
        public string LocationCurrentAvailabilityStatusText { get; set; } = "";
        /// <summary>
        /// The colour of the status indicator representing the current availability status of the location.<br></br>
        /// See <see cref="LocationCurrentAvailabilityStatusColours"/>.
        /// </summary>
        public string LocationCurrentAvailabilityStatusColour { get; set; } = "";
        /// <summary>
        /// Valid colour values for <see cref="LocationCurrentAvailabilityStatusColour"/>.
        /// </summary>
        public enum LocationCurrentAvailabilityStatusColours
        {
            Green,
            Orange,
            Red
        }
        public string LocatonDisplayName { get; set; } = "";
        public string AddressLine1Display { get; set; } = "";
        public string AddressLine2Display { get; set; } = "";
        public string DistanceFromUserDisplay { get; set; } = "";
        public string TimeFromUserDisplay { get; set; } = "";
        public string ChargeDetailsDisplay { get; set; } = "";

        public IEnumerator GetEnumerator()
        {
            // Implement your custom logic to return an enumerator
            // that allows iterating over Location objects.
            yield return this; // Replace this with your logic.
        }

        public static implicit operator Location(Xamarin.Essentials.Location v)
        {
            throw new NotImplementedException();
        }
    }

    public class CarouselItem
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string LevelInfo { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        public Position Position { get; internal set; }
    }
}
