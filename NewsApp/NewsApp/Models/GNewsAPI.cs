using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    class GNewsAPI
    {
        //private string timestamp;
        //private int articleCount;
        //private List<GNewsArticle> articles;

        public string TimeStamp { get; set; }
        public int ArticleCount { get; set; }
        public List<GNewsArticle> Articles { get; set; }
    }

    public class GNewsArticle
    { 

        //private string title;
        //private string url;
        //private string image;
        //private DateTime publishedAt;
        //private GNewsSource source;

        public string Title { get; set; }
        public string Description { get; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string PublishedAt { get; set; }
        public GNewsSource Source { get; set; }


    }

    public class GNewsSource
    {
        //private string name;
        //private string url;

        public string Name { get; set; }

        public string Url { get; set; }

    }
}
