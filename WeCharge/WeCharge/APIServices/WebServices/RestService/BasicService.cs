using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using WeCharge;
using WeCharge.APIServices.WebServices;
using WeCharge.Resources;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ApiServices.WebServices.RestService
{
    public class BasicService
    {
        public void AddHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Lotus-Agent-Platform", DeviceInfo.Platform.ToString());
            // Add the version
            request.Headers.Add("Lotus-Agent-Version", $"{VersionTracking.CurrentVersion} || {VersionTracking.CurrentBuild}");
            // Add environement
            request.Headers.Add("Lotus-Agent-Environment", $"{DeviceInfo.Platform} || {DeviceInfo.Version} || {DeviceInfo.Manufacturer} || {DeviceInfo.Model}");
            //request.Headers.Add("Lotus-Device-ID", string.IsNullOrEmpty(DeviceInfo.Name) ? "" : WsCall.StripUnicodeCharactersFromString(DeviceInfo.Name));

            request.Headers.Add(App.DateTimeHeaderKey, DateTime.Now.ToString(App.DateFormat));
            // Add DateTime offset header
            request.Headers.Add(App.DateTimeOffSetHeaderKey, DateTime.Now.ToString(App.UtcOffsetFormat));

            if(Preferences.ContainsKey("token"))
            {
                string token = Preferences.Get("token","null");
                request.Headers.Add("Lotus-User-AuthToken", token);
                request.Headers.Add("Cookie", "ARRAffinity=b5263b03750953481e3d9b75e540e38a0eaaad041c2728537674c6e27204a8d1; ARRAffinitySameSite=b5263b03750953481e3d9b75e540e38a0eaaad041c2728537674c6e27204a8d1");
            }
        }


        public async void CheckInternetConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert("", AppLanguage.no_internet_alert, AppLanguage.okay);
            }
        }
        public async Task<T> CallApi<T, U>(Uri Url, WeChargeService Client, MethodType methodType, U RequestContent)
        {
            while(App.IsApiBusy)
            {

            }
            try
            {
                App.IsApiBusy = true;
                Client.RenewHttpClient();
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                HttpResponseMessage _httpResponse = null;
                Client.HttpClient.Timeout = TimeSpan.FromSeconds(30);
                AddHeaders(_httpRequest);
                _httpRequest.Method = new HttpMethod(methodType == MethodType.GET ? "GET" : "POST");
                _httpRequest.RequestUri = Url;
                string _requestContent = null;
                if (RequestContent != null)
                {
                    _requestContent = JsonConvert.SerializeObject(RequestContent);
                    _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                    _httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

                }

                _httpResponse = await Client.HttpClient.SendAsync(_httpRequest);
                string responseContent = null;
                responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (responseContent == "" && _httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    responseContent = "{IsSuccess: true}";
                App.IsApiBusy = false;
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                App.IsApiBusy = false;
                return default(T);
            }
        }
        public enum MethodType
        {
            GET,
            POST
        }

    }
}
