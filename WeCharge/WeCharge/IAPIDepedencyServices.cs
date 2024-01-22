using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace WeCharge
{
    public interface APIDependencyServices
    {
        string GetApiKey();
        string GetSalt();
        void GetPlatformSpecificHeaders(HttpRequestMessage request);
    }
}
