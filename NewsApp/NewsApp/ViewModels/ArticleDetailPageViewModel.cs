using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewsApp.ViewModels
{
    class ArticleDetailPageViewModel : INotifyPropertyChanged
    {
        private Article _article;

        public Article Article => _article;
        public string Title => _article.Title;
        public string Url => _article.Url;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
