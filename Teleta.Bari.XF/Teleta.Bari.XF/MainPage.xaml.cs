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

            //Device.OnPlatform()

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
                // Risorsa globale (App.xaml)
                Style s1 = Application.Current.Resources["btnBase"] as Style;
                s1.Setters[0].Value = new Color(56, 255, 0);
                this.btnLogin.BackgroundColor = new Color(56, 255, 0);

                Style s2 = this.Resources["Xamarin.Forms.Label"] as Style;

                // MessageBox di errore
                await this.DisplayAlert("Login", "Login fallito!", "Ok");
            }
        }
    }
}
