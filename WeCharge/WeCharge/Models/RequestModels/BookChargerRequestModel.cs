using System;
namespace WeCharge.Models.RequestModels
{
    public class BookChargerRequestModel
    {
        public string ChargerID { get; set; }
        public string LocationID { get; set; }
        public string DateLocalISO { get; set; }
        public int DurationMinutes { get; set; }
        public string StartTime { get; set; }
    }

}

