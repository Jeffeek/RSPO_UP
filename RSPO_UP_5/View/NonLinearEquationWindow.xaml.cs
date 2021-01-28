#region Using namespaces

using System;

#endregion

namespace RSPO_UP_5.View
{
	public partial class NonLinearEquationWindow
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