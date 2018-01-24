﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Teleta.Bari.XF
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new Teleta.Bari.XF.MainPage());
            MainPage = new NavigationPage(new Teleta.Bari.XF.LoginPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
