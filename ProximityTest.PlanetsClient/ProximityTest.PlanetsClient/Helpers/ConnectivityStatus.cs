using Xamarin.Essentials;

namespace ProximityTest.PlanetsClient.Helpers
{
    public static class ConnectivityStatus
    {
        public static bool IsConnected()
        {
            var current = Connectivity.NetworkAccess;

            return current == NetworkAccess.Internet;
        }
    }
}
