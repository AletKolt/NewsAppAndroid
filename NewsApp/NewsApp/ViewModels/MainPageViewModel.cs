using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NewsApp.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Threading;
using NewsApp.Services;
using System.Diagnostics;

namespace NewsApp.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private int count = 0;
        private bool isrefreshing = true;
        private List<NewsArticle> newsArticles;
        private string connectionState = string.Empty;
        private string apiResults = string.Empty;
        private List<GNewsArticle> gNewsArticles;
        private string connectionStateTextColor;
        private string connectionStateFrameBackgroundColor;
        private bool connectionStateFrameIsVisible;
        private string connectionStateText;
        RestServices restServices;
        PermissionService permissionService;


        #region Initiate Commands
        public ICommand TypeCommand { get; }
        public ICommand NewsArticlesCommand { get; }
        public ICommand SelectionChangedCommand { get; }
        #endregion Initiate Commands

        #region SetBindingProperties
        public string DisplayCount => $"{count}";
        public bool IsRefreshing => isrefreshing;
        public string ConnectionState => $"Connection state is: {connectionState}";
        public string APIResults => $"The 4th Articles Content is: {apiResults}";
        public List<NewsArticle> NewsArticles => newsArticles;
        public string ConnectionStateFrameBackgroundColor => connectionStateFrameBackgroundColor;
        public string ConnectionStateTextColor => connectionStateTextColor;
        public bool ConnectionStateFrameIsVisible => connectionStateFrameIsVisible;
        public string ConnectionStateText => connectionStateText;
        #endregion SetBindingProperties


        public MainPageViewModel()
        {
            TypeCommand = new Command(IncreaseCount);
            NewsArticlesCommand = new Command(GetTopHeadlines);
            restServices = new RestServices();
            permissionService = new PermissionService();
            //be sure to unsubscribe from this event when finished
            //ConnectionBoxViewVariables("White", "Red", false, "Internet Connection Lost");
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            if (NetworkService.ExistsInternetConnection())
            {
                OnPropertyChanged(nameof(IsRefreshing));
                //GetTopHeadlines();
                
            }
            else
            {
                //internet connection does not exist
                connectionState = "DISCONNECTED";
                ConnectionBoxViewVariables("White", "Red", true, "Internet Connection Lost");
            }
            
        }

        public async void GetTopHeadlines()
        {
            if (NetworkService.ExistsInternetConnection())
            {
                connectionState = "CONNECTED";
                //get the list of TopHeadlines
                //topHeadlines = await restServices.GetTopHeadlines();
                //gNewsAPI = await restServices.GetGNewsLocalNGHeadlines();
                newsArticles = await restServices.BindAllNewsHeadlines();
                if (newsArticles != null)
                {
                    OnPropertyChanged(nameof(NewsArticles));
                }
                //if (gNewsAPI != null)
                //{
                //    gNewsArticles = gNewsAPI.Articles;
                //    OnPropertyChanged(nameof(GNewsArticles));
                //}

                //if (topHeadlines != null)
                //{
                //    articles = topHeadlines.Articles;
                //    OnPropertyChanged(nameof(Articles));
                //}

                isrefreshing = false;
                OnPropertyChanged(nameof(IsRefreshing));

            }
            else
            {
                //internet connection does not exist
                connectionState = "DISCONNECTED";
                ConnectionBoxViewVariables("White", "Red", true, "Internet Connection Lost");
            }
            OnPropertyChanged(nameof(ConnectionState));
            OnPropertyChanged(nameof(APIResults));
        }

        void IncreaseCount()
        {
            //await permissionService.CheckAndRequestNetworkStatePermission();
            count++;
            OnPropertyChanged(nameof(DisplayCount));
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            //be sure to unsubscribe from this event when finished
            //handle all the
            switch (NetworkService.ExistsInternetConnection())
            {
                case true:
                    //internet is here
                    connectionState = "CONNECTED";
                    ConnectionBoxViewVariables("White", "Green", true, "Internet Connection is Back");
                    OnPropertyChanged(nameof(ConnectionState));
                    break;

                case false:
                    //internet is away
                    connectionState = "DISCONNECTED";
                    ConnectionBoxViewVariables("White", "Red", true, "Internet Connection Lost");
                    OnPropertyChanged(nameof(ConnectionState));
                    break;
            }

        }

        void ConnectionBoxViewVariables(string foreground, string background, bool isVisible, string connectionText)
        {
            connectionStateTextColor = foreground;
            connectionStateFrameBackgroundColor = background;
            connectionStateFrameIsVisible = isVisible;
            connectionStateText = connectionText;
            OnPropertyChanged(nameof(ConnectionStateTextColor));
            OnPropertyChanged(nameof(ConnectionStateFrameBackgroundColor));
            OnPropertyChanged(nameof(ConnectionStateFrameIsVisible));
            OnPropertyChanged(nameof(ConnectionStateText));
        }
    }


}
