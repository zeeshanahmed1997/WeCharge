using System;
using System.Collections.Generic;
using System.Text;
using WeCharge.Models.APIResponse;

namespace WeCharge.ApiService.EnPoints
{

    [API.ApiEndpoint(Route = "EVCharge/MobileApp/AuthenticateUserByEmail/v1", Verb = API.ApiEndpointAttribute.HttpVerb.Post)]
    public class AuthenticateUserByEmail
    {
        public Response Execute(Request request)
        {
            var response = new Response();
            response.SetStatusSuccess();
            return response;
        }
    }
}
