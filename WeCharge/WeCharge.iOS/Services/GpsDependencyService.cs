using System;
using CoreLocation;
using Foundation;
using WeCharge.iOS.Services;
using UIKit;
using WeCharge.Services;

[assembly: Xamarin.Forms.Dependency(typeof(GpsDependencyService))]

namespace WeCharge.iOS.Services
{
    public class GpsDependencyService : IGpsDependencyService
    {
        public bool IsGpsEnable()
        {
            if (CLLocationManager.Status == CLAuthorizationStatus.Denied)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void OpenSettings()
        {
            var WiFiURL = new NSUrl("prefs:root=WIFI");

            if (UIApplication.SharedApplication.CanOpenUrl(WiFiURL))
            {   //> Pre iOS 10
                UIApplication.SharedApplication.OpenUrl(WiFiURL);
            }
            else
            {   //> iOS 10
                UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=WIFI"));
            }
        }
    }
}
