using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Plugin.TextToSpeech.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Xml;
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

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                base.RaisePropertyChanged();
            }
        }


        public RelayCommand SpeakCommand { get; set; }
        public RelayCommand DownloadCommand { get; set; }
        public RelayCommand ScanBarcodeCommand { get; set; }

        public ArticleDetailViewModel()
        {
            this.Date = new DateTime(2000, 01, 01);
            this.SpeakCommand = new RelayCommand(SpeakCommandExecute);
            this.DownloadCommand = new RelayCommand(DownloadCommandExecute);
            this.ScanBarcodeCommand = new RelayCommand(ScanBarcodeCommandExecute);
            network = new HttpClient();
        }

        private async void ScanBarcodeCommandExecute()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
            {
                Debug.WriteLine("Scanned Barcode: " + result.Text);
            }
        }

        private async void DownloadCommandExecute()
        {
            string data = this.Date.ToString("yyyyMMdd");
            string uri = "";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("DataLimite", data),
                new KeyValuePair<string, string>("ADB", "ADB_DEMO_TPICK_MASTER")
            });

            HttpResponseMessage response = await network.PostAsync(uri, content);
            string xml = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(xml))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string json = doc.InnerText;

                JsonSerializerSettings sett = new JsonSerializerSettings();                
                Articolo[] crArticoli = JsonConvert.DeserializeObject<Articolo[]>(json, sett);
            }
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