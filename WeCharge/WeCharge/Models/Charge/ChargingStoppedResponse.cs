using System;
namespace WeCharge.Models.Charge
{
	public class ChargingStoppedResponse
	{
            public string ChargingStatus { get; set; }
            public string _Status { get; set; }
            public string _LotusStatusCode { get; set; }
            public string _LotusStatusDetails { get; set; }
    }
}

