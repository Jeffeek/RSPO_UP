using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class LoginWindowViewModel : ViewModelBase
    {
        private string _login;
        private string _password;

        public string LoginText
        {
            get => _login;
            set => SetValue(ref _login, value);
        }

        public string PasswordText
        {
            get => _login;
            set => SetValue(ref _password, value);
        }
    }
}
