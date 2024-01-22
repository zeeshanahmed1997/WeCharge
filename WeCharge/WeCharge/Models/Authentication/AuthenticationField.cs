using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.Authentication
{
    public class AuthenticationField
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
