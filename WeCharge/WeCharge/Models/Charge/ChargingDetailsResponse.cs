using System;
using static WeCharge.Models.Charge.Charger;

namespace WeCharge.Models.Charge
{
    public class ChargingDetailsResponse
    {
        public object ChargingStatus { get; set; }
        public string MaximumChargeCostForDisplay { get; set; }
        public int CurrentChargeRateKiloWattsHours { get; set; }
        public int MaximimChargeRateKiloWattsHours { get; set; }
        public string ChargeSoFarKilowattsDisplay { get; set; }
        public string ChargeSoFarDurationDisplay { get; set; }
        public string ChargeSoFarAmountDisplay { get; set; }
        public string RemainingToLimitKilowattsDisplay { get; set; }
        public string RemainingToLimitDurationDisplay { get; set; }
        public string RemainingToLimitAmountDisplay { get; set; }
        public string ChargePercentageDisplay { get; set; }
        public string ChargeSpeedDiplay { get; set; }
        public string ChargerTypeName { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }
    }
}
