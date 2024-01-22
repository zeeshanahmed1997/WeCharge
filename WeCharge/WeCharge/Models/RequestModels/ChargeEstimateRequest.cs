using System;
namespace WeCharge.Models.RequestModels
{
	public class ChargeEstimateRequest
	{
		public string BookingID { get; set; }
		public string ChargerID { get; set; }
		public string SlotStartTime { get; set; }
		public string CostRateDisplay { get; set; }
		public string LocaionName { get; set; }
		public int BayNumber { get; set; }

    }
}

