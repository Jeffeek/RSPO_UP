#region Using namespaces

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_5.Model;
using RSPO_UP_5.View;

#endregion

namespace RSPO_UP_5.ViewModel
{
	public class LoginWindowViewModel : ViewModelBase
	{
		private readonly List<User> _users;
		private string _login = string.Empty;
		private string _password = string.Empty;

		public LoginWindowViewModel()
		{
			_users = GetAllUsersFromFile();
			LoginCommand = new RelayCommand(OnLoginExecuted, CanLoginExecute);
		}

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

			if (user.Role == UserRole.Teacher)
				window = new ChooseOperationWindow();

			window?.Show();
			Application.Current.MainWindow?.Hide();
		}

		private List<User> GetAllUsersFromFile()
		{
			List<User> users;
			using (var reader = new FileStream($"{Directory.GetCurrentDirectory()}//Files//users.json",
			                                   FileMode.OpenOrCreate))
			{
				var serializer = new DataContractJsonSerializer(typeof(List<User>));
				users = serializer.ReadObject(reader) as List<User> ?? new List<User>();
			}

			return users;
		}
	}
}