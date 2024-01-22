using System;
using System.Collections.Generic;
using WeCharge.Models.VehicleDetails;
using WeCharge.Models.Charge;

namespace WeCharge.Models.General
{
    public class ReferenceDataResponse
    {
        public List<VehicleBrand> VehicleBrands { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
        public List<ChargerType> ChargerTypes { get; set; }
        public string _Status { get; set; }
        //public ResponseHeaders _ResponseHeaders { get; set; }
        public object _LotusStatusCode { get; set; }
        public object _LotusStatusDetails { get; set; }
    }
}

