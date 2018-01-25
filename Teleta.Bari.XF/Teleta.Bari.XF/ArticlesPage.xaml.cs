using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.Interfaces;
using Teleta.Bari.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teleta.Bari.XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesPage : TabbedPage
    {
        public ArticlesPage()
        {
            InitializeComponent();
            var vm = this.Resources["viewmodel"] as ArticlesViewModel;

            IPath p = DependencyService.Get<IPath>();
            vm.Repo.ConnectionString = p.GetLocalPath();
        }
    }
}