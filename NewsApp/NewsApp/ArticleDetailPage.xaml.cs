using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewsApp.Models;

namespace NewsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleDetailPage : ContentPage
    {
        private NewsArticle _article;
        public ArticleDetailPage(NewsArticle article)
        {
            InitializeComponent();
            _article = article;
            articlePageTitle.Text = _article.Title;
            articlesWebView.Source = _article.Url;
        }
       
    }
}