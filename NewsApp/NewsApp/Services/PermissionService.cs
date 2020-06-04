using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NewsApp.Services
{
    class PermissionService
    {
        public PermissionService()
        {

        }

        public PermissionStatus PermissionStatus { get; set; }

        public async Task<PermissionStatus> CheckAndRequestNetworkStatePermission()
        {
            PermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if(PermissionStatus != PermissionStatus.Granted)
            {
                PermissionStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            //You could prompt user to turn on in settings
            return PermissionStatus;
        }


    }
}
