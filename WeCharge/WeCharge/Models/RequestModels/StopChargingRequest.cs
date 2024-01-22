using System;
namespace WeCharge.Models.RequestModels
{
	public class StopChargingRequest
	{
        public string BookingID { get; set; }
        public string ChargerID { get; set; }
    }
}

