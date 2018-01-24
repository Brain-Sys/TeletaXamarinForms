using GalaSoft.MvvmLight;
using System;
using Teleta.Bari.XF.Auth;

namespace Teleta.Bari.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value;
                base.RaisePropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;
                base.RaisePropertyChanged();
            }
        }

        private bool remember;
        public bool Remember
        {
            get { return remember; }
            set { remember = value;
                base.RaisePropertyChanged();
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value;
                base.RaisePropertyChanged();
            }
        }

        public LoginViewModel()
        {
            Username = "pippo";
            Password = "pluto";
            Remember = true;
        }

        public void ValidateUser()
        {
            // F11 Step Into
            // F10 Step Over
            bool ok = AuthEngine.Validate(this.Username, this.Password);

            if (ok)
            {
                Message = "Login riuscito";
            }
            else
            {
                Message = "Login fallito";
            }
        }
    }
}