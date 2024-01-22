
using System;
using System.Collections.Generic;
using System.Text;
using WeCharge.APIServices.Authentication;
using WeCharge.APIServices.Bookings;
using WeCharge.APIServices.Charge;

namespace WeCharge.APIServices.WebServices
{
    public interface IWeChargeService
    {
        Uri BaseUri { get; set; }
        //IPharmacyService Pharmacy { get; }
        IAuthenticationService authentication { get; }
        IBookingService bookingsService { get; }
        IChargingService chargingService { get; }
        void RenewHttpClient();
        void UpdateToken(string token);
    }
}
