using System;
using System.Threading.Tasks;
using WeCharge.Models.Charge;
using WeCharge.Models.RequestModels;

namespace WeCharge.APIServices.Charge
{
	public interface IChargingService
	{
        Task<ChargeEstimateResponse> RequestChargeEstimate(ChargeEstimateRequest request);
        Task<StartChargingResponse> StartCharging(StartChargingRequest request);
        Task<ChargingDetailsResponse> GetChargingProgressDetails(ChargeEstimateRequest request);
        Task<ChargingStoppedResponse> StopCharging(StopChargingRequest request);
        Task<ChargingSummaryResponse> GetChargingSummary(ChargeSummaryRequest chargingSummaryRequest);
    }
}

