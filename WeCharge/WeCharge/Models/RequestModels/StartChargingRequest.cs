using System;
namespace WeCharge.Models.RequestModels
{
	public class StartChargingRequest
	{
		public string BookingID { get; set; }
		public string ChargerID { get; set; }
        public int MaximumChargeCost { get; set; } = -1;
    }
}

