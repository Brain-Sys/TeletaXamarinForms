using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teleta.Bari.XF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var vm = this.Resources["viewmodel"] as LoginViewModel;
            vm.ValidateUser();
        }
    }
}