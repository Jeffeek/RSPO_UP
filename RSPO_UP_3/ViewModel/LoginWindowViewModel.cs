﻿#region Using namespaces

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;
using RSPO_UP_3.ViewModel.Base;

#endregion

namespace RSPO_UP_3.ViewModel
{
	internal class LoginWindowViewModel : ViewModelBase
	{
		public LoginWindowViewModel()
		{
			_users = UsersProvider.GetUsersList();
			RegistrationViewModel = new RegistrationViewModel(_users);
			EnterCommand = new RelayCommand(OnEnterButtonExecuted, CanEnterButtonExecute);
		}

		#region commands

		public ICommand EnterCommand { get; }

		#endregion

		private void OpenChildForm(Role role)
		{
			Window w = null;
			switch (role)
			{
				case Role.Student:
				{
					w = new MainWindow();
					break;
				}

				case Role.Admin:
				{
					w = new AdminWindow();
					break;
				}

				case Role.Teacher:
				{
					w = new TeacherWindow();
					break;
				}
			}

			w?.ShowDialog();
			Application.Current.Shutdown();
		}

		#region fields

		private string _login = string.Empty;
		private string _password = string.Empty;
		private RegistrationViewModel _registrationViewModel;
		private readonly List<User> _users;

		#endregion

		#region props

		public RegistrationViewModel RegistrationViewModel
		{
			get => _registrationViewModel;
			set => SetValue(ref _registrationViewModel, value);
		}

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

		#endregion

		#region command methods

		private bool CanEnterButtonExecute() => LoginText.Length >= 5 && PasswordText.Length >= 7;

		private void OnEnterButtonExecuted()
		{
			var user = _users.SingleOrDefault(x => x.Login == LoginText);
			if (user != null)
			{
				if (user.Password == PasswordText)
				{
					UsersProvider.AddNewEntrance(user.Id);
					OpenChildForm(user.Role);
				}
				else
				{
					MessageBox.Show("Password is wrong!",
					                "Bad pass",
					                MessageBoxButton.OK,
					                MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show($"User with login {LoginText} is not exists!",
				                "Bad login",
				                MessageBoxButton.OK,
				                MessageBoxImage.Error);
			}

			LoginText = string.Empty;
			PasswordText = string.Empty;
		}

		#endregion
	}
}