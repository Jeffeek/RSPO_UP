using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_5.Model;
using RSPO_UP_5.View;

namespace RSPO_UP_5.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private string _login = String.Empty;
        private string _password = String.Empty;
        private List<User> _users;

        public ICommand LoginCommand { get; }

        public string Login
        {
            get => _login;
            set => SetValue(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        private bool CanLoginExecute() => Login.Length > 5 && Password.Length > 5;

        private void OnLoginExecuted()
        {
            Window window = null;
            var user = _users.SingleOrDefault(x => x.Login == Login && x.Password == Password);
            if (user == null)
                return;
            else
            {
                if (user.Role == UserRole.Teacher)
                {
                    window = new ChooseOperationWindow();
                }
                else
                {
                    
                }

                window?.Show();
                Application.Current.MainWindow?.Hide();
            }
        }

        private List<User> GetAllUsersFromFile()
        {
            List<User> users = null;
            using (var reader = new FileStream($"{Directory.GetCurrentDirectory()}//Files//users.json", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));
                users = serializer.ReadObject(reader) as List<User> ?? new List<User>();
            }

            return users;
        }

        public LoginWindowViewModel()
        {
            _users = GetAllUsersFromFile();
            LoginCommand = new RelayCommand(OnLoginExecuted, CanLoginExecute);
        }
    }
}
