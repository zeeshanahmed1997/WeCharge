using System;
namespace WeCharge.Models.RequestModels
{
	public class ForgetPasswordRequest
	{
            /// <summary>
            /// The email address of a Lotus user to perform a forgot password reset for.
            /// </summary>
            public string Email { get; set; } = "";
    }
}

