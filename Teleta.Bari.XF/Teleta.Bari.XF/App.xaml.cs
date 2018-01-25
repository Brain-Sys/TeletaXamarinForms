using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleta.Bari.Interfaces;
using Teleta.Bari.ViewModels.Messages;
using Teleta.Bari.XF.Repository;
using Xamarin.Forms;

namespace Teleta.Bari.XF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IPath p = DependencyService.Get<IPath>();
            FakeRepository.ConnectionString = p.GetLocalPath();
            FakeRepository.StartDb();

            Messenger.Default.Register<ShowMessage>(this, showMsg);
            Messenger.Default.Register<NavigateMessage>(this, navigate);
            Messenger.Default.Register<QuestionMessage>(this, askToTheUser);

            //MainPage = new NavigationPage(new Teleta.Bari.XF.MainPage());
            MainPage = new NavigationPage(new Teleta.Bari.XF.LoginPage());
        }

        private async void askToTheUser(QuestionMessage obj)
        {
            bool accept = await Application.Current.MainPage.DisplayAlert
                (obj.Title, obj.Text, obj.Ok, obj.Cancel);

            if (accept)
            {
                obj.Yes?.Invoke();
            }
            else
            {
                obj.No?.Invoke();
            }
        }

        private async void navigate(NavigateMessage obj)
        {
            string pageName = "Teleta.Bari.XF." + obj.DestinationPage;
            Type type = Type.GetType(pageName);

            if (type != null)
            {
                Page page = null;

                if (obj.Parameter == null)
                {
                    // Ctor parameter-less
                    page = Activator.CreateInstance(type) as Page;
                }
                else
                {
                    // Cerca un ctor che abbia un parametro in input
                    page = Activator.CreateInstance(type, obj.Parameter) as Page;
                }

                if (page != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(page);
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
