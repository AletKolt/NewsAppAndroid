using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace NewsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void newsArticlesCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var article = e.CurrentSelection.FirstOrDefault() as Models.NewsArticle;

            if (article == null)
                return;

            await Navigation.PushAsync(new ArticleDetailPage(article));

            ((CollectionView)sender).SelectedItem = null;

        }

        //private async void newsArticlesCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var article = e.CurrentSelection.FirstOrDefault() as Models.GNewsArticle;

        //    if (article == null)
        //        return;

        //    await Navigation.PushAsync(new GNewsAPIDetailPage(article));

        //    ((CollectionView)sender).SelectedItem = null;
        //}
    }
}
