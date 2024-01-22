using System;
using WeCharge.Services;
using WeCharge.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(BackgroundService))]
namespace WeCharge.Droid.Services
{
    public class BackgroundService : IBackgroundService
    {
        public void StartService()
        {
            MainApplication.StartService();
        }

        public void StopService()
        {
            MainApplication.StopService();
        }
    }
}

