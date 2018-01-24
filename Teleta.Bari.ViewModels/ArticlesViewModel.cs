using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.ViewModels
{
    public class ArticlesViewModel : ViewModelBase
    {
        FakeRepository repo = new FakeRepository();

        private List<Article> articles;
        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value;
                base.RaisePropertyChanged();
            }
        }

        private List<Article> carrello;
        public List<Article> Carrello
        {
            get { return carrello; }
            set { carrello = value;
                base.RaisePropertyChanged();
            }
        }

        private Article articolo;
        public Article Articolo
        {
            get { return articolo; }
            set { articolo = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }

        public ArticlesViewModel()
        {
            this.AddCommand = new RelayCommand(AddCommandExecute);
            this.Articles = repo.Read();
            this.Carrello = new List<Article>();
        }

        private void AddCommandExecute()
        {
            this.Carrello.Add(this.Articolo);
        }
    }
}