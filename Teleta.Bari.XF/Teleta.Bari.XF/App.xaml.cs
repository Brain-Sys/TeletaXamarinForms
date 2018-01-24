using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleta.Bari.ViewModels.Messages;
using Xamarin.Forms;

namespace Teleta.Bari.XF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Messenger.Default.Register<ShowMessage>(this, showMsg);
            Messenger.Default.Register<NavigateMessage>(this, navigate);

            //MainPage = new NavigationPage(new Teleta.Bari.XF.MainPage());
            MainPage = new NavigationPage(new Teleta.Bari.XF.LoginPage());
        }

        private async void navigate(NavigateMessage obj)
        {
            string pageName = "Teleta.Bari.XF." + obj.DestinationPage;
            Type type = Type.GetType(pageName);

            if (type != null)
            {
                Page page = Activator.CreateInstance(type) as Page;

                if (page != null)
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(page);
                }
            }
        }

        private async void showMsg(ShowMessage obj)
        {
            await Application.Current.MainPage.DisplayAlert
                (obj.Title, obj.Text, obj.Ok);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
