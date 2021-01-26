#region Using namespaces

using System;
using System.Windows;

#endregion

namespace RSPO_UP_5.View
{
	public partial class NonLinearEquationWindow : Window
	{
		private readonly Action _closeAction;

		public NonLinearEquationWindow(Action closeAction)
		{
			InitializeComponent();
			_closeAction = closeAction;
		}

		private void NonLinearEquationWindow_OnClosed(object sender, EventArgs e)
		{
			_closeAction?.Invoke();
		}
	}
}