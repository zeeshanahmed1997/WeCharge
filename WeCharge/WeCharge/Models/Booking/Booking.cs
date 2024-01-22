
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using WeCharge.Models.Charge;
namespace WeCharge.Models.Booking
{
    /// <summary>
    /// Represents a booking for a single charge for a user.
    /// </summary>
    ///
    public class ConfirmBookingResponse
    {
        public string Status { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }

    }
    public class CancelBookingResponse
    {
        public string Status { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }

    }
    public class BookingResponse
    {
        public string BookingID { get; set; }
        public List<Booking> Bookings { get; set; }
        public string Status { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }
    }
    public class BookingResponseForbookCharger
    {
        public string BookingID { get; set; }
        public Booking Booking { get; set; }
        public string Status { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }
    }
    public class Booking
    {
        public string ID { get; set; } = "";
        public string ForCustomerID { get; set; } = "";
        public DateTime DateTimeLocalISO { get; set; }
        public string ReferenceCode { get; set; } = "";
        public string DateTimeLocalFormattedDisplay { get; set; } = "";
        public string SlotTimeFormattedDisplay { get; set; } = "";
        public string SlotStartTimeFormattedDisplay { get; set; } = "";
        public string SlotEndTimeFormattedDisplay { get; set; } = "";
        public string DurationDisplay { get; set; } = "";
        public int DurationMinutes { get; set; } = 0;
        public string DateUTCOffset { get; set; } = "";
        public string LocationID { get; set; }
        public Location Location { get; set; } = new Location();
        public string SlotAddressFormattedDisplay { get; set; } = "";
        public string ChargerID { get; set; } = "";
        public Charger Charger { get; set; } = new Charger();
        public string ChargeCurrencyID { get; set; } = "";
        public string ChargeSubTotalDisplay { get; set; }
        public string ChargeCurrencyDisplaySymbol { get; set; } = "$";
        public decimal EstimatedChargeLevelKiloWatts { get; set; } = 0;
        public int EstimatedChargeDurationMinutes { get; set; } = 0;
        public decimal EstimatedPaymentAmountExTax { get; set; } = 0;
        public decimal TrackedChargeLevelKiloWatts { get; set; } = 0;
        public int TrackedChargeDurationMinutes { get; set; } = 0;
        public string ChargeTaxDisplay { get; set; } = "";
        public decimal TrackedPaymentAmountExTax { get; set; } = 0;
        public decimal RemainingChargeLevelKiloWatts { get; set; } = 0;
        public int RemainingChargeDurationMinutes { get; set; } = 0;
        public string ChargeServiceChargesDisplay { get; set; } = "";
        public decimal RemainingPaymenteAmountExTax { get; set; } = 0;
        public string Status { get; set; } = "";
        public string ChargeTotalAmountIncTaxDisplay { get; set; } = "";
        public string ProvisionalBookingExpiryUTCISO { get; set; } = "";
        public string ChargerLevelsSummary { get; set; } = "";
        public decimal ChargeTotalAmountIncTax { get; set; } = 0;
        public decimal ChargeKiloWattsConsumed { get; set; } = 0;
        public string ChargeKiloWattsConsumedDisplay { get; set; } = "";

    }

        //public string ID { get; set; } = "";
        //public string ForCustomerID { get; set; } = "";
        //public string DateTimeLocalISO { get; set; }
        //public string DateTimeLocalFormattedDisplay { get; set; } = "";
        //public string SlotTimeFormattedDisplay { get; set; } = "";
        //public int DurationMinutes { get; set; } = 0;
        //public string DateUTCOffset { get; set; } = "";
        //public string LocationID { get; set; } = "";
        //public Location Location { get; set; } = new Location();
        //public string SlotAddressFormattedDisplay { get; set; } = "";
        //public string ChargerID { get; set; } = "";
        //public Charger Charger { get; set; } = new Charger();
        //public string ChargeCurrencyID { get; set; } = "";
        //public string ChargeCurrencyDisplaySymbol { get; set; } = "$";
        //public decimal EstimatedChargeLevelKiloWatts { get; set; } = 0;
        //public int EstimatedChargeDurationMinutes { get; set; } = 0;
        //public decimal EstimatedPaymentAmountExTax { get; set; } = 0;
        //public decimal TrackedChargeLevelKiloWatts { get; set; } = 0;
        //public int TrackedChargeDurationMinutes { get; set; } = 0;
        //public decimal TrackedPaymentAmountExTax { get; set; } = 0;
        //public decimal RemainingChargeLevelKiloWatts { get; set; } = 0;
        //public int RemainingChargeDurationMinutes { get; set; } = 0;
        //public decimal RemainingPaymenteAmountExTax { get; set; } = 0;
        //public string Status { get; set; } = "";

        public enum BookingStatus
        {
            /// <summary>
            /// A booking that is waiting to be confirmed by the user in the UI.<br></br>
            /// Currently holding the slot for the user so other users cannot book over the slot.<br></br>
            /// Next status once confirmed is <see cref="Booked"/>.
            /// If the user does n
            /// </summary>
            Provisional,



            /// <summary>
            /// Booked and ready to start charging
            /// </summary>
            Booked,



            /// <summary>
            /// Charging has been started and is in progress.
            /// </summary>
            Charging,



            /// <summary>
            /// Charging was started and is not finished (at whatever stage, and however triggered, after starting).
            /// </summary>
            ChargeFinished,



            /// <summary>
            /// User had a booking but but never started the charge.
            /// </summary>
            ChargeMissed,



            /// <summary>
            /// The booking was cancelled before charging started.
            /// </summary>
            CancelledBeforeCharge,
        }
}
