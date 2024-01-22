using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using WeCharge.Views.Popup;
using Xamarin.Essentials;

public static class NetworkHelper
{
    private static bool isConnected; // Track connectivity status

    public static bool IsConnected => isConnected; // Property to check connectivity status

    public static void CallConnectivityChangedHandler()
    {
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        UpdateConnectivityStatus();
    }

    public static void UnsubscribeFromConnectivityChanged()
    {
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
    }

    public static bool UpdateConnectivityStatus()
    {
        isConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
        return isConnected;
    }

    public static async Task ShowPopupAsync()
    {
            await PopupNavigation.Instance.PushAsync(new InternetConnectionPopup());
            await delayedWork();
    }

    private static async Task delayedWork()
    {
        await Task.Delay(5000);
        await doMyDelayedWork();
    }

    private static async Task doMyDelayedWork()
    {
        await PopupNavigation.Instance.PopAsync(); // Remove all popups
    }

    private static async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        UpdateConnectivityStatus();
        await ShowPopupAsync();
    }
}
