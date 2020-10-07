using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class LoginWindowViewModel : ViewModelBase
    {
        private string _login = "";
        private string _password = "";
        private List<User> _users;
        public ICommand EnterCommand { get; }

        public string LoginText
        {
            get => _login;
            set => SetValue(ref _login, value);
        }

        public string PasswordText
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        private bool CanEnterButtonExecute() => LoginText.Length > 5 && PasswordText.Length > 7;

        private void OnEnterButtonExecuted()
        {
            var user = _users.SingleOrDefault(x => x.Login == LoginText);
            if (user != null)
            {
                if (user.Password == PasswordText)
                {
                    OpenChildForm(user.Role);
                }
            }
        }

        private void OpenChildForm(Role role)
        {
            Window w = null;
            switch (role)
            {
                case Role.Student:
                {
                    MainWindow mw = new MainWindow();
                    w = mw;
                    break;
                }

                case Role.Admin:
                {
                    //TODO: админ форма
                    break;
                }

                case Role.Teacher:
                {
                    //TODO: форма препода
                    break;
                }
            }
            w?.Show();
        }

        public LoginWindowViewModel()
        {
            _users = UsersProvider.GetUsersList();
            EnterCommand = new RelayCommand(OnEnterButtonExecuted, CanEnterButtonExecute);
        }
    }
}
