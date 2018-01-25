using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.ViewModels;
using Teleta.Bari.XF.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teleta.Bari.XF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticleDetailPage : ContentPage
	{
		public ArticleDetailPage ()
		{
			InitializeComponent ();
		}

        public ArticleDetailPage(Article article) : this()
        {
            var vm = this.Resources["viewmodel"] as ArticleDetailViewModel;
            vm.Article = article;
        }
    }
}