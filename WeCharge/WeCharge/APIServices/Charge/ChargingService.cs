using System;
using System.Threading.Tasks;
using ApiServices.WebServices.RestService;
using WeCharge.APIServices.WebServices;
using WeCharge.Models.Booking;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.Charge;
using WeCharge.Models.RequestModels;

namespace WeCharge.APIServices.Charge
{
    public class ChargingService : BasicService, IChargingService
    {
        public WeChargeService Client { get; private set; }
        public ChargingService(WeChargeService client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            this.Client = client;
        }
        public ChargingService()
        {
        }
        public async Task<ChargeEstimateResponse> RequestChargeEstimate(ChargeEstimateRequest request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/RequestChargeEstimate/v1").ToString();

                var result = await CallApi<ChargeEstimateResponse, ChargeEstimateRequest>(new Uri(_url), Client, MethodType.GET, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<StartChargingResponse> StartCharging(StartChargingRequest request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/StartCharging/v1").ToString();

                var result = await CallApi<StartChargingResponse, StartChargingRequest>(new Uri(_url), Client, MethodType.POST, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ChargingDetailsResponse> GetChargingProgressDetails(ChargeEstimateRequest request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/GetChargingProgressDetails/v1").ToString();

                var result = await CallApi<ChargingDetailsResponse, ChargeEstimateRequest>(new Uri(_url), Client, MethodType.GET, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ChargingStoppedResponse> StopCharging(StopChargingRequest request)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/StopCharging/v1").ToString();

                var result = await CallApi<ChargingStoppedResponse, StopChargingRequest>(new Uri(_url), Client, MethodType.POST, request);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ChargingSummaryResponse> GetChargingSummary(ChargeSummaryRequest chargingSummaryRequest)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"/EVCharge/MobileApp/GetChargingSummary/v1").ToString();

                var result = await CallApi<ChargingSummaryResponse, ChargeSummaryRequest>(new Uri(_url), Client, MethodType.GET, chargingSummaryRequest);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

