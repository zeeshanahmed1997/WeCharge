using System;
namespace WeCharge.Services
{
    public interface IGpsDependencyService
    {
        void OpenSettings();
        bool IsGpsEnable();
    }
}

