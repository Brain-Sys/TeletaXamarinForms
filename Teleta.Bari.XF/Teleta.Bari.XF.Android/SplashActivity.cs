using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Teleta.Bari.XF.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        public SplashActivity()
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(5000);
            this.StartActivity(typeof(MainActivity));
        }
    }
}