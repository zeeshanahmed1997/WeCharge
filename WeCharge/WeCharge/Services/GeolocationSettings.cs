using System;
using Xamarin.Forms;

namespace WeCharge.Services
{
    public static class GeolocationSettings
    {
        public static bool IsGpsEnable()
        {
            return DependencyService.Get<IGpsDependencyService>().IsGpsEnable();
        }

        public static void OpenSettings()
        {
            DependencyService.Get<IGpsDependencyService>().OpenSettings();
        }
    }
}

