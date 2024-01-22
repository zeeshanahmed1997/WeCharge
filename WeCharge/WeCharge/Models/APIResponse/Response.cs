using System;
namespace WeCharge.Models.APIResponse
{
    public class Response
    {
        public bool IsAuthenticated { get; set; } = false;
        public string Status { get; set; } = AuthenticationStatus.DefaultFail.ToString();
        public enum AuthenticationStatus
        {
            DefaultFail = 1,
            Success = 2,
            InvalidUsernameOrPassword = 3,
            AuthTokenNotFound = 4,
            AuthTokenExpired = 5
        }
        public string UserID { get; set; } = "";
        private string _ActiveAccountID = "";
        public string ActiveAccountID
        {
            get { return _ActiveAccountID; }
            set
            {
                _ActiveAccountID = value;
            }
        }
       // public AccessControl.AssignedAccessStructure CompleteAccessStructure { get; set; } = new AccessControl.AssignedAccessStructure();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string DisplayName { get; set; } = "";
        [Obsolete]
        public string NextAuthToken { get; set; } = "";

        internal void SetStatusSuccess()
        {
            throw new NotImplementedException();
        }
    }

}

