using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WeCharge.Models.Booking
{
    public class AvailableChargeSlot
    {
        public string ChargerID { get; set; }
        public string StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public string ListDisplayLabel { get; set; }
        //public IEnumerator GetEnumerator()
        //{
        //    // Implement your custom logic to return an enumerator
        //    // that allows iterating over Location objects.
        //    yield return this; // Replace this with your logic.
        //}

    }
    public class AvailableChargeSlotsResponse
    {
        public List<AvailableChargeSlot> AvailableChargeSlots { get; set; }
        public string LocationCurrentAvailabilityStatusText { get; set; }
        public string LocationCurrentAvailabilityStatusColour { get; set; }
        public string _Status { get; set; }
        public object _LotusStatusCode { get; set; }
        public object _LotusStatusDetails { get; set; }
        public IEnumerator GetEnumerator()
        {
            // Implement your custom logic to return an enumerator
            // that allows iterating over Location objects.
            yield return this; // Replace this with your logic.
        }

    }
    public enum LocationCurrentAvailabilityStatusColours
    {
        Green,
        Orange,
        Red
    }
}

