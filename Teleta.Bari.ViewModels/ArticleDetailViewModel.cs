using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.TextToSpeech.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.ViewModels
{
    public class ArticleDetailViewModel : ViewModelBase
    {
        private HttpClient network;

        private Article article;
        public Article Article
        {
            get { return article; }
            set
            {
                article = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand SpeakCommand { get; set; }
        public RelayCommand DownloadCommand { get; set; }

        public ArticleDetailViewModel()
        {
            this.SpeakCommand = new RelayCommand(SpeakCommandExecute);
            this.DownloadCommand = new RelayCommand(DownloadCommandExecute);
            network = new HttpClient();
        }

        private void DownloadCommandExecute()
        {
            string uri = "http://tsdemo.dnsalias.org:5515/ws_logistica.asmx?op=WS_TSP_Arca_Get_AR_JSON";
            network.PostAsync(uri);
        }

        private async void SpeakCommandExecute()
        {
            var tts = Plugin.TextToSpeech.CrossTextToSpeech.Current;
            IEnumerable<CrossLocale> lang = await tts.GetInstalledLanguages();
            await tts.Speak("Stai vedendo il dettaglio di " + this.Article.Name,
                speakRate: 1.8F, pitch: 0.3F);
        }
    }
}