using System;
namespace WeCharge.Models.Charge
{
	public class ChargingSummaryResponse
	{
        public string UnitsConsumedKilowattsDisplay { get; set; }
        public string ChargeDateDisplay { get; set; }
        public string ChargeDurationDisplay { get; set; }
        public string ChargeStartTimeDisplay { get; set; }
        public string ChargeEndTimeDisplay { get; set; }
        public string ChargeFeeServicesChargesAmountDisplay { get; set; }
        public string ChargeFeeSubTotalAmountDisplay { get; set; }
        public string ChargeFeeTaxAmountDisplay { get; set; }
        public string ChargeFeeGrandTotalAmountDisplay { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }
    }
}

