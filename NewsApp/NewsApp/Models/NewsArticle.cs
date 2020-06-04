using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public string Description { get; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
    }
}
