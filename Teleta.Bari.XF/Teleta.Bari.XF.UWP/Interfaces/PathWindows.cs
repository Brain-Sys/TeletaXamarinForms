using System.IO;
using Teleta.Bari.Interfaces;
using Teleta.Bari.XF.Repository;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Teleta.Bari.XF.UWP.Interfaces.PathWindows))]
namespace Teleta.Bari.XF.UWP.Interfaces
{
    public class PathWindows : IPath
    {
        public string GetLocalPath()
        {
            string str = ApplicationData.Current.LocalFolder.Path;
            return str;
        }
    }
}