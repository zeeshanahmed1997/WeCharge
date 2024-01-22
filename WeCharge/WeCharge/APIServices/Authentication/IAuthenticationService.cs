using System;
using System.Threading.Tasks;

using WeCharge.Models.Accounts;
using WeCharge.Models.Authentication;
using WeCharge.Models.General;
using WeCharge.Models.RequestModels;

namespace WeCharge.APIServices.Authentication
{
	public interface IAuthenticationService
	{
		Task<AuthenticateUserResponse>Login(AuthenticationField authenticationField);
		Task<ForgetPasswordResponse> ForgetPassword(ForgetPasswordRequest Email);
		Task<ReferenceDataResponse> AuthenticationReferenceData(); 

    }
}

