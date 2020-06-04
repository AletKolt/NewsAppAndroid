using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NewsApp;
using Xamarin.Essentials;
using NewsApp.Services;
using NewsApp.Models;

namespace NewsApp.Triggers
{
    class OnMainPageAppearingTrigger : TriggerAction<ContentPage>
    {
        RestServices restServices;
        TopHeadlines topHeadlines;
        protected override async void Invoke(ContentPage contentPage)
        {
            switch (NetworkService.ExistsInternetConnection())
            {
                case true:
                    //await contentPage.DisplayAlert("Internet Connection", "You are connected", "OK");
                    restServices = new RestServices();
                    topHeadlines = await restServices.GetTopHeadlines();
                    
                    break;
                case false:
                    await contentPage.DisplayAlert("Internet Connection", "You are NOT connected. Please, get a connection", "OK");
                    break;
            }
        }

        }
}
