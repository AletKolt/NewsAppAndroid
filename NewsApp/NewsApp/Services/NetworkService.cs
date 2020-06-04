using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsApp.Services
{
    class NetworkService
    {
        public static bool ExistsInternetConnection()
        {
            var current = Connectivity.NetworkAccess;
            switch (current)
            {
                case NetworkAccess.Internet:
                    return true;
                case NetworkAccess.ConstrainedInternet:
                    return true;
                case NetworkAccess.None:
                    return false;
                default:
                    return false;

            }

        }


    }
}
