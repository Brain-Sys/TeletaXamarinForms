﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.ViewModels
{
    public class ArticlesViewModel : ViewModelBase
    {
        // Field
        private List<Article> articles;

        // Property
        public List<Article> Articles
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
            }
        }

        public RelayCommand<Article> AddCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public ArticlesViewModel()
        {
            this.AddCommand = new RelayCommand<Article>(AddCommandExecute);
            this.SaveCommand = new RelayCommand(SaveCommandExecute);
            this.Articles = FakeRepository.Read();
            this.Carrello = new ObservableCollection<Article>();
        }

        private void SaveCommandExecute()
        {
            bool ok = FakeRepository.Save(this.Articles);
        }

        private void AddCommandExecute(Article a)
        {
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