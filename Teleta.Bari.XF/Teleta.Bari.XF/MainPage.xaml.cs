using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.XF.Auth;
using Xamarin.Forms;

namespace Teleta.Bari.XF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

#if DEBUG
            this.Username.Text = "teleta";
            this.Password.Text = "bari";
#endif

            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                this.Remember.IsVisible = true;
            }
        }

        private async void faiLogin(object sender, EventArgs args)
        {
            // X
            var esito = await Task.Run<bool>(() => { return true; });

            // X + n secondi
            if (esito == true) { }

            bool ok = AuthEngine.Validate
                (this.Username.Text, this.Password.Text);

            if (ok)
            {
                // Nuova pagina
                // await this.Navigation.PushAsync(new MainMenuPage());
                await this.Navigation.PushModalAsync(new MenuPage());
            }
            else
            {
                // MessageBox di errore
                await this.DisplayAlert("Login", "Login fallito!", "Ok");
            }
        }
    }
}
