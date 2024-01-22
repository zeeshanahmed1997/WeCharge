using System;
using System.Threading.Tasks;
using ApiServices.WebServices.RestService;
using WeCharge.APIServices.WebServices;
using WeCharge.Models.Authentication;
using WeCharge.APIServices.Authentication;
using Xamarin.Essentials;
using WeCharge.Models.Accounts;
using WeCharge.Models.Booking;
using WeCharge.Models.General;
using WeCharge.Models;
using WeCharge.Models.Booking.RequestModels;
using WeCharge.Models.RequestModels;

namespace recappt.APIServices.Authentication
{
    public class AuthenticationService : BasicService, IAuthenticationService
    {
        public WeChargeService Client { get; private set; }

        public AuthenticationService(WeChargeService client)
        {
            if (client == null)
                throw new ArgumentNullException("Client");
            this.Client = client;
        }

        public AuthenticationService()
        {
        }

        public async Task<AuthenticateUserResponse> Login(AuthenticationField authenticationField)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"EVCharge/MobileApp/authenticateuserbyemail/v1").ToString();

                var result = await CallApi<AuthenticateUserResponse, AuthenticationField>(new Uri(_url), Client, MethodType.POST, authenticationField);
                Preferences.Set("token", result.NextAuthToken);
                Preferences.Set("userName", result.FirstName + result.LastName);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ForgetPasswordResponse> ForgetPassword(ForgetPasswordRequest Email)
        {
            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"EVCharge/MobileApp/ForgotPassword/v1");

                var result = await CallApi<ForgetPasswordResponse, ForgetPasswordRequest>(new Uri(_url.ToString()), Client, MethodType.POST, Email);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ReferenceDataResponse> AuthenticationReferenceData()
        {

            try
            {
                var _baseUrl = this.Client.BaseUri.AbsoluteUri;
                var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/", StringComparison.Ordinal) ? "" : "/")), $"EVCharge/MobileApp/GetReferenceData/v1").ToString();

                var result = await CallApi<ReferenceDataResponse,AuthenticationField>(new Uri(_url), Client, MethodType.GET, null);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
