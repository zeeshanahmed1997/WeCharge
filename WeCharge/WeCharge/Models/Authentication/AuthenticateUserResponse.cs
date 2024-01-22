using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.Authentication
{
    /// <summary>
    /// The model representing response from any authentication request.
    /// </summary>
    public class AuthenticateUserResponse
    {
        public AuthenticateUserResponse()
        {
            //this.UserRoles = new List<UserRole>();
        }


        /// <summary>
        /// Set to true to indicate the user successfully authenticated
        /// </summary>
        public bool IsAuthenticated { get; set; } = false;

        public AuthenticationStatus Status { get; set; } = AuthenticationStatus.DefaultFail;

        /// <summary>
        /// The Lotus ID of the User.
        /// </summary>
        public string UserID { get; set; } = string.Empty;





        /// <summary>
        /// The ID of the Lotus Account the user is actively logged into.
        /// </summary>
        public string ActiveAccountID { get; set; } = string.Empty;





        ///// <summary>
        ///// Roles the user has within the active account.
        ///// </summary>
        //public List<UserRole> UserRoles { get; set; }





        /// <summary>
        /// The user's first name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;





        /// <summary>
        /// The user's last name/surname/family name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;





        /// <summary>
        /// Full display name of the user.
        /// </summary>
        [JsonProperty("UserDisplayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty("UserEmailAddress")]
        public string EmailAddress { get; set; } = string.Empty;






        //TODO: 3 Dec 2020. Value is populated by the API but currently not actively used by agents.
        /// <summary>
        /// A refreshed
        /// </summary>
        public string NextAuthToken { get; set; } = string.Empty;



        /// <summary>
        /// Status of the authentication
        /// </summary>
        public enum AuthenticationStatus
        {
            /// <summary>
            /// The default authentication failure status if no specific status given.
            /// </summary>
            DefaultFail = 1,


            /// <summary>
            /// Successfilly authenticated
            /// </summary>
            Success = 2,


            /// <summary>
            /// User or password is not found.
            /// This `UserNotFound` or `InvalidPassword` is originally set, 
            /// then replace with this value when returning to client.
            /// </summary>
            InvalidUsernameOrPassword = 3,


            /// <summary>
            /// Suppplied auth token was not found.
            /// </summary>
            AuthTokenNotFound = 4,


            /// <summary>
            /// Suppplied auth token has expired.
            /// </summary>
            AuthTokenExpired = 5
        }
        [JsonProperty("AccountGeoFencingStatus")]
        public string AccountGeoFencingStatus { get; set; }
        public bool AccountGeoFencingStatusBool
        {
            get
            {
                return AccountGeoFencingStatus == "Enabled";
            }
        }



    }
}
