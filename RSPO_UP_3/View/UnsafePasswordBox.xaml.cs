#region Using namespaces

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#endregion

namespace RSPO_UP_3.View
{
	public partial class UnsafePasswordBox : UserControl
	{
		public static readonly DependencyProperty PasswordProperty =
			DependencyProperty.Register("Password", typeof(string), typeof(UnsafePasswordBox),
			                            new FrameworkPropertyMetadata(string.Empty,
			                                                          FrameworkPropertyMetadataOptions
				                                                          .BindsTwoWayByDefault,
			                                                          PasswordPropertyChanged, null, false,
			                                                          UpdateSourceTrigger.PropertyChanged));

		private bool _isPasswordChanging;

		public UnsafePasswordBox()
		{
			InitializeComponent();
		}

		public string Password
		{
			get => (string) GetValue(PasswordProperty);
			set => SetValue(PasswordProperty, value);
		}

		private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is UnsafePasswordBox passwordBox) passwordBox.UpdatePassword();
		}

		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			_isPasswordChanging = true;
			Password = PasswordBox.Password;
			_isPasswordChanging = false;
		}

		private void UpdatePassword()
		{
			if (!_isPasswordChanging) PasswordBox.Password = Password;
		}
	}
}