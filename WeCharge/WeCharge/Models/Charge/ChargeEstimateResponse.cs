using System;
namespace WeCharge.Models.Charge
{
	public class ChargeEstimateResponse
	{
        public string EnergyRequiredDisplay { get; set; }
        public string TotalCostDisplay { get; set; }
        public string TimeDisplay { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }

        public static implicit operator ChargeEstimateResponse(ChargingSummaryResponse v)
        {
            throw new NotImplementedException();
        }
    }
}

