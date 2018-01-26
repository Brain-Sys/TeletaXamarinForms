using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Teleta.Bari.XF.Repository;
using System.Linq;
using Teleta.Bari.ViewModels.Messages;
using GalaSoft.MvvmLight.Messaging;
using Teleta.Bari.Reporting;
using Teleta.Bari.Interfaces;

namespace Teleta.Bari.ViewModels
{
    public class ArticlesViewModel : ViewModelBase
    {
        // Field
        private ObservableCollection<Article> articles;

        // Property
        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                base.RaisePropertyChanged();
            }
        }

        private ObservableCollection<Article> carrello;
        public ObservableCollection<Article> Carrello
        {
            get { return carrello; }
            set
            {
                carrello = value;
                base.RaisePropertyChanged();
            }
        }

        private Article articolo;
        public Article Articolo
        {
            get { return articolo; }
            set
            {
                articolo = value;
                base.RaisePropertyChanged();
                gotoArticleDetail();
            }
        }

        public RelayCommand AddNewArticleCommand { get; set; }
        public RelayCommand<Article> AddCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ClearArticlesCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }

        public ArticlesViewModel()
        {
            this.AddCommand = new RelayCommand<Article>(AddCommandExecute);
            this.AddNewArticleCommand = new RelayCommand(AddNewArticleCommandExecute);
            this.SaveCommand = new RelayCommand(SaveCommandExecute);
            this.ClearArticlesCommand = new RelayCommand(ClearArticlesCommandExecute);
            this.PrintCommand = new RelayCommand(PrintCommandExecute);
            this.Articles = new ObservableCollection<Article>(FakeRepository.Read());
            this.Carrello = new ObservableCollection<Article>();
        }

        private void PrintCommandExecute()
        {
            foreach (var item in this.Articles)
            {
                byte[] pdf = Report.Print(item, $"articolo{item.ID}.pdf");
            }
        }

        private void gotoArticleDetail()
        {
            NavigateMessage msg = new NavigateMessage("ArticleDetailPage");
            msg.Parameter = this.Articolo;
            Messenger.Default.Send<NavigateMessage>(msg);
        }

        private void ClearArticlesCommandExecute()
        {
            QuestionMessage msg = new QuestionMessage();
            msg.Cancel = "No";
            msg.Ok = "Sì";
            msg.Text = "Sei sicuro?";
            msg.Title = "Conferma!";
            //msg.Yes = cosaFareInCasoDiSì;
            msg.Yes = () =>
            {
                FakeRepository.Clear();
                this.Articles.Clear();
            };

            Messenger.Default.Send<QuestionMessage>(msg);
        }

        private void cosaFareInCasoDiSì()
        {
            this.Articles.Clear();
        }

        private void AddNewArticleCommandExecute()
        {
            Article a = new Article();
            a.ID = 0;
            a.Name = "nome articolo";
            a.Quantity = 1;
            this.Articles.Insert(0, a);
        }

        private void SaveCommandExecute()
        {
            bool ok = FakeRepository.Save(this.Articles.ToList());
        }

        private void AddCommandExecute(Article a)
        {
            if (a == null) return;

            if (!this.Carrello.Contains(a))
            {
                a.Quantity = 1;
                this.Carrello.Add(a);
            }
            else
            {
                int index = this.Carrello.IndexOf(a);
                this.Carrello[index].Quantity++;
            }

            // Calcolare totale carrello
        }
    }
}