using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teleta.Bari.XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesPage : TabbedPage
    {
        public ArticlesPage ()
        {
            InitializeComponent();
        }
    }
}