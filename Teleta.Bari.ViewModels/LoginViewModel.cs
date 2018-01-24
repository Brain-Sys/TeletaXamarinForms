using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using Teleta.Bari.ViewModels.Messages;
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

        public RelayCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand(ValidateUser);

            Username = "teleta";
            Password = "bari";
            Remember = true;
        }

        private void ValidateUser()
        {
            // F11 Step Into
            // F10 Step Over
            bool ok = AuthEngine.Validate(this.Username, this.Password);

            if (ok)
            {
                // Navigazione verso la pagina X
                Message = "Login riuscito";
                Messenger.Default.Send<NavigateMessage>(
                    new NavigateMessage("MenuPage"));
            }
            else
            {
                // MessageBox
                Message = "Login fallito";
                ShowMessage msg = new ShowMessage();
                msg.Title = "Login";
                msg.Text = Message;
                Messenger.Default.Send<ShowMessage>(msg);
            }
        }
    }
}