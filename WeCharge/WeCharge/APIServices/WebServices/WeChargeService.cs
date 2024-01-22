using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Plugin.Connectivity;
using WeCharge.Resources;
using WeCharge.APIServices.Authentication;
using recappt.APIServices.Authentication;
using WeCharge.APIServices.Bookings;
using WeCharge.APIServices.Charge;

namespace WeCharge.APIServices.WebServices
{
    public class WeChargeService : IWeChargeService
    {
        public WeChargeService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient = new HttpClient
              (
                  handler
                  , false)
            {
                BaseAddress = new Uri(WebServiceConfig.BaseUrl),

                MaxResponseContentBufferSize = 9999999
            };
            HttpClient.Timeout = TimeSpan.FromSeconds(30);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Initialize();
        }
        public virtual IAuthenticationService authentication { get; private set; }
        public IBookingService bookingsService { get; private set; }
        public IChargingService chargingService { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public Uri BaseUri { get; set; }

        //public virtual IPharmacyService Pharmacy { get; private set; }
        private void Initialize()
        {
            this.BaseUri = new Uri(WebServiceConfig.BaseUrl);
            //this.Pharmacy = new PharmacyService(this);
            this.authentication = new AuthenticationService(this);
            this.bookingsService = new BookingService(this);
            this.chargingService = new ChargingService(this);
        }

        public void UpdateToken(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        public void RenewHttpClient()
        {
            this.BaseUri = new Uri(WebServiceConfig.BaseUrl);
            var authorization = HttpClient.DefaultRequestHeaders.Authorization;
            HttpClientHandler handler = new HttpClientHandler();

            HttpClient = new HttpClient
              (
                  handler
                  , false)
            {
                BaseAddress = new Uri(WebServiceConfig.BaseUrl),

                MaxResponseContentBufferSize = 9999999
            };
            HttpClient.Timeout = TimeSpan.FromSeconds(30);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Authorization = authorization;

        }

    }
}
