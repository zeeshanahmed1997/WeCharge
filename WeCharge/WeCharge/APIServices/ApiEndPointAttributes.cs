using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.API
{
    public class ApiEndpointAttribute : Attribute
    {
        public string Route { get; set; } = "";


        public HttpVerb Verb { get; set; } = HttpVerb.Get;

        public enum HttpVerb
        {
            Get,
            Post
        }
    }
}
