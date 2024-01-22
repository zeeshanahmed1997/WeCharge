using System;
namespace WeCharge.Models.Charge
{
	public class StartChargingResponse
	{
        public string ChargingStatus { get; set; }
        public string BookingStatus { get; set; }
        public string _Status { get; set; }
        public string _LotusStatusCode { get; set; }
        public string _LotusStatusDetails { get; set; }
    }
}

