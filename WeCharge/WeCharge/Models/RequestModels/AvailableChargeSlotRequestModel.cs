using System;
namespace WeCharge.Models.RequestModels
{
    public class AvailableChargeSlotRequestModel
    {
        public string LocationID { get; set; } = "";
        public string CheckDateLocalISO { get; set; } = "";
        public int CheckDurationMinutes { get; set; } = 0;
    }
}

