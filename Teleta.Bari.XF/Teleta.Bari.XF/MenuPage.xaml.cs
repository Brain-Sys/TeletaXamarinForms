using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.XF.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teleta.Bari.XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : CarouselPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void Load_Clicked(object sender, EventArgs e)
        {
            string endpoint = "http://www.mioserver.com";

            string platform = Device.RuntimePlatform;

            Device.OnPlatform(
                () => { endpoint += "/ios"; },
                () => { endpoint += "/android"; },
                () => { endpoint += "/windows"; });

            await this.DisplayAlert("Url", endpoint, "OK");

            var list = FakeRepository.Read();
            this.lstArticles.ItemsSource = list;
        }

        private async void Order_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Article a = btn.BindingContext as Article;
                await this.DisplayAlert("Conferma!", a.ToString(), "OK");
                a.Name = a.Name + DateTime.Now.Second.ToString();
            }
        }

        private void lstArticles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var i1 = e.SelectedItem;
            var i2 = this.lstArticles.SelectedItem;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Tap = 2
        }
    }
}