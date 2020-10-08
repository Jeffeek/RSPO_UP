using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class RegistrationViewModel : ViewModelBase
    {
        private string _name = String.Empty;
        private string _password = String.Empty;
        private string _repeatPassword = String.Empty;
        private string _login = String.Empty;

        public string NameText
        {
            get => _name;
            set => SetValue(ref _name, value);
        }

        public string PasswordText
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        public string RepeatPasswordText
        {
            get => _repeatPassword;
            set => SetValue(ref _repeatPassword, value);
        }

        public string LoginText
        {
            get => _login;
            set => SetValue(ref _login, value);
        }
    }
}
