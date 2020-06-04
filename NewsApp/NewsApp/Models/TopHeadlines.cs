using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NewsApp.Models
{
    class TopHeadlines
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
}

}
