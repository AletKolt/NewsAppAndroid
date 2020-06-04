using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android.Net;
using NewsApp.Models;

namespace NewsApp.Services
{
    class RestServices
    {
        HttpClient client;

        public RestServices()
        {
            client = new HttpClient(new AndroidClientHandler());
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                "application/json"));
        }

        public async Task<TopHeadlines> GetTopHeadlines()
        {
            string uri = "https://newsapi.org/v2/top-headlines?country=us&apiKey=2857184ef1a34788b667e0dc3991c7a7";
            string returnJSONString = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<TopHeadlines>(returnJSONString);
        }

        public async Task<GNewsAPI> GetGNewsLocalNGHeadlines()
        {
            string uri = "https://gnews.io/api/v3/top-news?country=ng&token=72dd619cbd513c6ea0661387e389f7c2";
            string returnJSONString = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<GNewsAPI>(returnJSONString);
        }

        public async Task<List<NewsArticle>> BindAllNewsHeadlines()
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            GNewsAPI gNewsAPIHeadlines = await GetGNewsLocalNGHeadlines();
            TopHeadlines newsAPIHeadlines = await GetTopHeadlines();
            if (gNewsAPIHeadlines != null)
            {
                foreach (GNewsArticle headline in gNewsAPIHeadlines.Articles)
                {
                    newsArticles.Add(
                        new NewsArticle
                        {
                            Source = headline.Source.Name,
                            Title = headline.Title,
                            PublishedAt = headline.PublishedAt,
                            Url = headline.Url,
                            UrlToImage = headline.Image
                        }
                    );
                }
            }
            if (newsAPIHeadlines != null)
            {
                foreach (Article topheadline in newsAPIHeadlines.Articles)
                {

                    newsArticles.Add(
                        new NewsArticle
                        {
                            Author = topheadline.Author,
                            Source = topheadline.Source.Name,
                            Title = topheadline.Title,
                            PublishedAt = topheadline.PublishedAt.ToShortDateString(),
                            Url = topheadline.Url,
                            UrlToImage = topheadline.UrlToImage
                        }
                    );
                }
            }
            
            return newsArticles;
                
        }
    }
}
