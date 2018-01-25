using Android.OS;
using System.IO;
using Teleta.Bari.Interfaces;
using Teleta.Bari.XF.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof(Teleta.Bari.XF.Droid.Interfaces.PathAndroid))]
namespace Teleta.Bari.XF.Droid.Interfaces
{
    public class PathAndroid : IPath
    {
        public string GetLocalPath()
        {
            string str = (string)Android.OS.Environment.ExternalStorageDirectory + "/";

            return str;
        }
    }
}